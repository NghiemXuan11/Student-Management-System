using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PUBLIC;
using BUL;
using System.IO;
namespace Interface
{
    public partial class NhapCauHoi : Form
    {
        public NhapCauHoi()
        {
            InitializeComponent();
        }
        private void ReadOnly_ThongTinGiaoVien()
        {
            txttengv.ReadOnly = true;
            txtmasogv.ReadOnly = true;
            txtdaymon.ReadOnly = true;
            txtgioitinh.ReadOnly = true;
        }
        private string _magiaovien;

        public string Magiaovien
        {
            get { return _magiaovien; }
            set { _magiaovien = value; }
        }
        GIAOVIEN_BUL giaovien_bul = new GIAOVIEN_BUL();
       
        private void NhapCauHoi_Load(object sender, EventArgs e)
        {
            dg_thongtingiaovien.Hide();
            ReadOnly_ThongTinGiaoVien();
            GIAOVIEN_PUBLIC giaovien_public = new GIAOVIEN_PUBLIC();
            giaovien_public.MAGV = Magiaovien;
            dg_thongtingiaovien.DataSource=giaovien_bul.load_giaovien_voidieukien(giaovien_public);
            CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
            cauhoi_public.MAMONHOC = mamonhoc;
            dg_cauhoi.DataSource = cauhoi_pul.load_cauhoi_insert(cauhoi_public);
            dinhdangluoi();
        }    
        byte[] bytehinh;
        private string mamonhoc;
        private void dg_thongtingiaovien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = e.RowIndex;
                txttengv.Text = dg_thongtingiaovien.Rows[dong].Cells[0].Value.ToString();
                txtmasogv.Text = dg_thongtingiaovien.Rows[dong].Cells[1].Value.ToString();
                txtdaymon.Text = dg_thongtingiaovien.Rows[dong].Cells[2].Value.ToString();
                txtgioitinh.Text = dg_thongtingiaovien.Rows[dong].Cells[3].Value.ToString();
                mamonhoc = dg_thongtingiaovien.Rows[dong].Cells[4].Value.ToString();
                //
                bytehinh = (byte[])(dg_thongtingiaovien.Rows[dong].Cells[5].Value);
                MemoryStream ms = new MemoryStream(bytehinh);
                hinhgv.Image = new Bitmap(ms);
            }
            catch
            { }
        }
        CAUHOI_BUL cauhoi_pul = new CAUHOI_BUL();    
        private void btnhap_Click(object sender, EventArgs e)
        {
            if (txtnoidungcauhoi.TextLength == 0)
            {
                MessageBox.Show("Nội dung câu hỏi không được bỏ trống.","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (rd1.Checked == false && rd2.Checked == false && rd3.Checked == false && rd4.Checked == false)
            {
                MessageBox.Show("Chưa chọn đáp án đúng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtmadecauhoi.Text == "")
            {
                MessageBox.Show("Chưa điền mã đề thi cho câu hỏi.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {               
                        CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                        cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                        cauhoi_public.DA1 = txt1.Text;
                        cauhoi_public.DA2 = txt2.Text;
                        cauhoi_public.DA3 = txt3.Text;
                        cauhoi_public.DA4 = txt4.Text;
                        if (rd1.Checked == true)
                        {
                            cauhoi_public.DA = txt1.Text;
                            cauhoi_public.DAPAN = "1";
                        }
                        else if (rd2.Checked == true)
                        {
                            cauhoi_public.DA = txt2.Text;
                            cauhoi_public.DAPAN = "2";
                        }
                        else if (rd3.Checked == true)
                        {
                            cauhoi_public.DA = txt3.Text;
                            cauhoi_public.DAPAN = "3";
                        }
                        else if (rd4.Checked == true)
                        {
                            cauhoi_public.DA = txt4.Text;
                            cauhoi_public.DAPAN = "4";
                        }
                        cauhoi_public.MAMONHOC = mamonhoc;
                        cauhoi_public.MADETHI = txtmadecauhoi.Text;
                        cauhoi_pul.insert_cauhoi(cauhoi_public);
                        txtnoidungcauhoi.Clear();
                        txt1.Clear();
                        txt2.Clear();
                        txt3.Clear();
                        txt4.Clear();
                        NhapCauHoi_Load(sender, e);                  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btchambai_Click(object sender, EventArgs e)
        {
            DNPHIEUCHAMDIEM CHAMBAI = new DNPHIEUCHAMDIEM();
            CHAMBAI.ShowDialog();
        }
        DSNOPBAI_BUL dsnopbai_bul = new DSNOPBAI_BUL();
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbtrangthaicauhoi.Text = dsnopbai_bul.demtongdsnopbai().ToString();
        }
    
        private void dinhdangluoi()
        {
            dg_cauhoi.ReadOnly = true;
            dg_cauhoi.Columns[0].HeaderText = "Nội dung";
            dg_cauhoi.Columns[1].HeaderText = "Đáp án 1";
            dg_cauhoi.Columns[2].HeaderText = "Đáp án 2";
            dg_cauhoi.Columns[3].HeaderText = "Đáp án 3";
            dg_cauhoi.Columns[4].HeaderText = "Đáp án 4";
            dg_cauhoi.Columns[5].Visible = false;
            dg_cauhoi.Columns[6].HeaderText = "Tên môn";
            dg_cauhoi.Columns[7].HeaderText = "Đáp án đúng(1,2,3,4)";
            dg_cauhoi.Columns[8].HeaderText = "Mã đề";
        }
        private string noidungold = "";
        private void dg_cauhoi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;          
            txtnoidungcauhoi.Text=dg_cauhoi.Rows[dong].Cells[0].Value.ToString();
            noidungold = dg_cauhoi.Rows[dong].Cells[0].Value.ToString();
            txt1.Text=dg_cauhoi.Rows[dong].Cells[1].Value.ToString();
            txt2.Text=dg_cauhoi.Rows[dong].Cells[2].Value.ToString();
            txt3.Text=dg_cauhoi.Rows[dong].Cells[3].Value.ToString();
            txt4.Text=dg_cauhoi.Rows[dong].Cells[4].Value.ToString();
            if (dg_cauhoi.Rows[dong].Cells[7].Value.ToString() == "1")
            {
                rd1.Checked = true;               
            }
            else if (dg_cauhoi.Rows[dong].Cells[7].Value.ToString() == "2")
            {
                rd2.Checked = true;
            }
            else if (dg_cauhoi.Rows[dong].Cells[7].Value.ToString() == "3")
            {
                rd3.Checked = true;
            }
            else if (dg_cauhoi.Rows[dong].Cells[7].Value.ToString() == "4")
            {
                rd4.Checked = true;
            }
            txtmadecauhoi.Text = dg_cauhoi.Rows[dong].Cells[8].Value.ToString();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
            cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
            cauhoi_pul.delete_cauhoi(cauhoi_public);
            cauhoi_pul.delete_cauhoiDACHON(cauhoi_public);
            NhapCauHoi_Load(sender, e);
        }

        private void btlui_Click(object sender, EventArgs e)
        {
            try
            {
                int lui = dg_cauhoi.CurrentRow.Index - 1;
                if (lui != dg_cauhoi.Rows.Count + 1)
                {
                    dg_cauhoi.CurrentCell = dg_cauhoi.Rows[lui].Cells[dg_cauhoi.CurrentCell.ColumnIndex];
                }
            }
            catch
            { }         
        }

        private void bttoi_Click(object sender, EventArgs e)
        {
            try
            {
                int toi = dg_cauhoi.CurrentRow.Index + 1;
                if (toi != dg_cauhoi.Rows.Count - 1)
                {
                    dg_cauhoi.CurrentCell = dg_cauhoi.Rows[toi].Cells[dg_cauhoi.CurrentCell.ColumnIndex];
                }
            }
            catch
            { }       
        }

        private void bttest_Click(object sender, EventArgs e)
        {
            LamBaiTracNghiem lb = new LamBaiTracNghiem();
            lb.MAMONHOC = mamonhoc;
            lb.MADETHI = txtmadecauhoi.Text;
            lb.ShowDialog();
        }

        private void lbtrangthaicauhoi_Click(object sender, EventArgs e)
        {

        }
        MONHOC_BUL monhoc_bul = new MONHOC_BUL();
        private void txtmadecauhoi_Click(object sender, EventArgs e)
        {
            MONHOC_PUBLIC monhoc_public = new MONHOC_PUBLIC();
            txtmadecauhoi.DataSource = monhoc_bul.load_made();
            txtmadecauhoi.DisplayMember = "madethi";
        }         
    }
}
