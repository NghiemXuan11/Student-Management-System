using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BUL;
using PUBLIC;
namespace Interface
{
    public partial class LamBaiTracNghiem : Form
    {
        public LamBaiTracNghiem()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private int _phut;

        public int Phut
        {
            get { return _phut; }
            set { _phut = value; }
        }
        public int giay = 1;
        private string _mathisinh;

        public string Mathisinh
        {
            get { return _mathisinh; }
            set { _mathisinh = value; }
        }
        private string _tenmonthi;

        public string Tenmonthi
        {
            get { return _tenmonthi; }
            set { _tenmonthi = value; }
        }
        private int _thoigianthi;

        public int Thoigianthi
        {
            get { return _thoigianthi; }
            set { _thoigianthi = value; }
        }
        private string _MAMONHOC;

        public string MAMONHOC
        {
            get { return _MAMONHOC; }
            set { _MAMONHOC = value; }
        }
        private string _MADETHI;

        public string MADETHI
        {
            get { return _MADETHI; }
            set { _MADETHI = value; }
        }
        THISINH_BUL thisinh_pul = new THISINH_BUL();
        CAUHOI_BUL cauhoi_pul = new CAUHOI_BUL();
        private void ReadOnly()
        {
            txt1.ReadOnly = true;
            txt2.ReadOnly = true;
            txt3.ReadOnly = true;
            txt4.ReadOnly = true;
            txtnoidungcauhoi.ReadOnly = true;
        }
        private void RefreshRd()
        {
            rd1.Checked = false;
            rd1.ForeColor = Color.Black;
            rd2.Checked = false;
            rd2.ForeColor = Color.Black;
            rd3.Checked = false;
            rd3.ForeColor = Color.Black;
            rd4.Checked = false;
            rd4.ForeColor = Color.Black;
        }
        private void RefreshDG()
        {
            CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
            cauhoi_public.MAMONHOC = MAMONHOC;
            cauhoi_public.MADETHI = MADETHI;
            bindingSource1.DataSource = cauhoi_pul.load_cauhoidachon(cauhoi_public);
            dg_loadcauhoidachon.DataSource = bindingSource1;
        }
        //tắt nút close
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private void LamBaiTracNghiem_Load(object sender, EventArgs e)
        {
            ReadOnly();            
            dg_thongtinthisinh.Hide();
            dg_cauhoi.Hide();
            dg_loadcauhoidachon.Hide();
            lbphut.Text = Phut.ToString();
            lbgiay.Text = giay.ToString();
            THISINH_PUBLIC ts_public=new THISINH_PUBLIC();
            CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
            cauhoi_public.MAMONHOC = MAMONHOC;
            cauhoi_public.MADETHI = MADETHI;
            ts_public.MATS=Mathisinh;
            dg_thongtinthisinh.DataSource = thisinh_pul.load_thisinh_voidieukien(ts_public);
            dg_cauhoi.DataSource = cauhoi_pul.load_cauhoi(cauhoi_public);
            dg_loadcauhoidachon.DataSource = cauhoi_pul.load_cauhoidachon(cauhoi_public);
            tongsocau = dg_cauhoi.Rows.Count-1;
            groupBoxCauhoi.Text = "Nội dung câu hỏi: Câu 1/" + tongsocau.ToString();
            txtthimon.Text = Tenmonthi;
            lbmadethi.Text = MADETHI;
        }      
        private void timer1_Tick(object sender, EventArgs e)
        {
            giay = giay - 1;
            lbgiay.Text = giay.ToString();
            if (giay == 0)
            {
                Phut=Phut-1;
                lbphut.Text = Phut.ToString();
                giay = 60;
            }
            if (Phut == 0)
            {
                timer1.Stop();
                MessageBox.Show("Hết thời gian làm bài.","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                lbphut.Text = "00";
                lbgiay.Text = "00";
                btnopbai_Click(sender, e);
            }
        }
        byte[] bytehinh;
        private void dg_thongtinthisinh_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = e.RowIndex;
                txttents.Text = dg_thongtinthisinh.Rows[dong].Cells[0].Value.ToString();
                txtmaso.Text = dg_thongtinthisinh.Rows[dong].Cells[1].Value.ToString();
                txtgioitinh.Text = dg_thongtinthisinh.Rows[dong].Cells[2].Value.ToString();
                bytehinh = (byte[])(dg_thongtinthisinh.Rows[dong].Cells[3].Value);
                MemoryStream ms = new MemoryStream(bytehinh);
                hinhgv.Image = new Bitmap(ms);
            }
            catch
            { }
        }

        private void dg_cauhoi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtnoidungcauhoi.Text = dg_cauhoi.Rows[dong].Cells[0].Value.ToString();
            txt1.Text = dg_cauhoi.Rows[dong].Cells[1].Value.ToString();
            txt2.Text = dg_cauhoi.Rows[dong].Cells[2].Value.ToString();
            txt3.Text = dg_cauhoi.Rows[dong].Cells[3].Value.ToString();
            txt4.Text = dg_cauhoi.Rows[dong].Cells[4].Value.ToString();
        }
        int socau = 1,tongsocau=0,socaudung=0,socausai=0;
        private void check_cauhoi()
        {
            if (rd1.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public=new CAUHOI_PUBLIC();               
                cauhoi_public.NOIDUNG=txtnoidungcauhoi.Text;               
                cauhoi_public.DA = "1";
                cauhoi_pul.update_cauhoidachonRD(cauhoi_public);
            }
            else if (rd2.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                cauhoi_public.DA = "2";
                cauhoi_pul.update_cauhoidachonRD(cauhoi_public);
            }
            else if (rd3.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                cauhoi_public.DA = "3";
                cauhoi_pul.update_cauhoidachonRD(cauhoi_public);
            }
            else if (rd4.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                cauhoi_public.DA = "4";
                cauhoi_pul.update_cauhoidachonRD(cauhoi_public);
            }
        }
        private void check_caudungsai()
        {
            if (rd1.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                cauhoi_public.DA = txt1.Text;
                cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                int checkcaudung = cauhoi_pul.check_caudung(cauhoi_public);              
                if (socaudung + socausai == tongsocau)
                { }
                else
                {
                    if (checkcaudung == 1)
                    {
                        socaudung = socaudung + 1;
                    }
                    else if (checkcaudung == 0)
                    {
                        socausai = socausai + 1;
                    }
                }
            }
            else if (rd2.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                cauhoi_public.DA = txt2.Text;
                cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                int checkcaudung = cauhoi_pul.check_caudung(cauhoi_public);               
                if (socaudung + socausai == tongsocau)
                { }
                else
                {
                    if (checkcaudung == 1)
                    {
                        socaudung = socaudung + 1;
                    }
                    else if (checkcaudung == 0)
                    {
                        socausai = socausai + 1;
                    }
                }
            }
            else if (rd3.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                cauhoi_public.DA = txt3.Text;
                cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                int checkcaudung = cauhoi_pul.check_caudung(cauhoi_public);               
                if (socaudung + socausai == tongsocau)
                { }
                else
                {
                    if (checkcaudung == 1)
                    {
                        socaudung = socaudung + 1;
                    }
                    else if (checkcaudung == 0)
                    {
                        socausai = socausai + 1;
                    }
                }
            }
            else if (rd4.Checked == true)
            {
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                cauhoi_public.DA = txt4.Text;
                cauhoi_public.NOIDUNG = txtnoidungcauhoi.Text;
                int checkcaudung = cauhoi_pul.check_caudung(cauhoi_public);             
                if (socaudung + socausai == tongsocau)
                { }
                else
                {
                    if (checkcaudung == 1)
                    {
                        socaudung = socaudung + 1;
                    }
                    else if (checkcaudung == 0)
                    {
                        socausai = socausai + 1;
                    }
                }
            }
        }
        private void btnhap_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshDG();
                int toi = dg_cauhoi.CurrentRow.Index + 1;
                if (toi != dg_cauhoi.Rows.Count - 1)
                {
                    dg_cauhoi.CurrentCell = dg_cauhoi.Rows[toi].Cells[dg_cauhoi.CurrentCell.ColumnIndex];                 
                    socau++;
                    groupBoxCauhoi.Text = "Nội dung câu hỏi: Câu " + socau.ToString() + "/" + tongsocau.ToString();
                }
                //
                int toi1 = dg_loadcauhoidachon.CurrentRow.Index + 1;
                if (toi1 != dg_loadcauhoidachon.Rows.Count - 1)
                {
                    dg_loadcauhoidachon.CurrentCell = dg_loadcauhoidachon.Rows[toi1].Cells[dg_loadcauhoidachon.CurrentCell.ColumnIndex];                                                     
                }
            }
            catch
            { }         
        }

        private void btquaylai_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshDG();
                int lui = dg_cauhoi.CurrentRow.Index - 1;
                if (lui != dg_cauhoi.Rows.Count + 1)
                {
                    dg_cauhoi.CurrentCell = dg_cauhoi.Rows[lui].Cells[dg_cauhoi.CurrentCell.ColumnIndex];                   
                    socau--;
                    groupBoxCauhoi.Text = "Nội dung câu hỏi: Câu " + socau.ToString() + "/" + tongsocau.ToString();
                }      
                //
                int toi1 = dg_loadcauhoidachon.CurrentRow.Index - 1;
                if (toi1 != dg_loadcauhoidachon.Rows.Count + 1)
                {
                    dg_loadcauhoidachon.CurrentCell = dg_loadcauhoidachon.Rows[toi1].Cells[dg_loadcauhoidachon.CurrentCell.ColumnIndex];                   
                }
            }
            catch
            { }         
        }       
        private void dg_loadcauhoidachon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong=e.RowIndex;
            if (dg_loadcauhoidachon.Rows[dong].Cells[1].Value.ToString() == "0")
            {
                RefreshRd();
            }
            else if (dg_loadcauhoidachon.Rows[dong].Cells[1].Value.ToString() == "1")
            {
                rd1.Checked = true;            
            }
            else if (dg_loadcauhoidachon.Rows[dong].Cells[1].Value.ToString() == "2")
            {
                rd2.Checked = true;             
            }
            else if (dg_loadcauhoidachon.Rows[dong].Cells[1].Value.ToString() == "3")
            {
                rd3.Checked = true;                
            }
            else if (dg_loadcauhoidachon.Rows[dong].Cells[1].Value.ToString() == "4")
            {
                rd4.Checked = true;              
            }
        }
        private void DisableAll()
        {
            groupBoxCauhoi.Enabled = false;
            groupBoxCauTraLoi.Enabled = false;
            groupBoxChucNang.Enabled = false;          
            groupBoxThoiGian.Enabled = false;
            timer1.Stop();
        }
        private void btnopbai_Click(object sender, EventArgs e)
        {
            RefreshDG(); 
            for (int i = 0; i < dg_loadcauhoidachon.Rows.Count-1; i++)
            {
                if (dg_loadcauhoidachon.Rows[i].Cells[1].Value.ToString() == dg_loadcauhoidachon.Rows[i].Cells[3].Value.ToString())
                {
                    socaudung++;
                }
                else
                {
                    socausai++;
                }
            }
            lbtrangthai.ForeColor = Color.Green;
            lbtrangthai.Text = "Tổng số câu hỏi: "+tongsocau.ToString()+"\n"+"Số câu đúng: "+socaudung.ToString()+"\n"+"Số câu sai: "+socausai.ToString();
            DisableAll();
            insert_baithicuathisinh();
            Thread dongformlb = new Thread(dongform);
            dongformlb.IsBackground = false;
            dongformlb.Start();
        }
        private void dongform()
        {
            Thread.Sleep(5000);
            this.Close();
        }
        private void insert_baithicuathisinh()
        {
            DSNOPBAI_BUL dsnopbai_bul = new DSNOPBAI_BUL();
            DSNOPBAI_PUBLIC dsnopbai_public = new DSNOPBAI_PUBLIC();
            dsnopbai_public.MATHISINH = Mathisinh;
            dsnopbai_public.MAMONHOC = MAMONHOC;
            dsnopbai_public.TENMONHOC = Tenmonthi;
            dsnopbai_public.SOCAUDUNG = socaudung;
            dsnopbai_public.SOCAUSAI = socausai;
            dsnopbai_public.MADETHI = MADETHI;
            dsnopbai_bul.insert_dsnopbai(dsnopbai_public);
        }
        private void btthoat_Click(object sender, EventArgs e)
        {
            RefreshDG();
            for (int i = 0; i < dg_loadcauhoidachon.Rows.Count - 1; i++)
            {
                if (dg_loadcauhoidachon.Rows[i].Cells[1].Value.ToString() == dg_loadcauhoidachon.Rows[i].Cells[3].Value.ToString())
                {
                    socaudung++;
                }
                else
                {
                    socausai++;
                }
            }
            DNPHIEUCHAMDIEM DNPCD = new DNPHIEUCHAMDIEM();
            DisableAll();
            insert_baithicuathisinh();
            this.Close();
        }

        private void rd1_CheckedChanged(object sender, EventArgs e)
        {
            check_cauhoi();          
        }

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            check_cauhoi();         
        }

        private void rd3_CheckedChanged(object sender, EventArgs e)
        {
            check_cauhoi();         
        }

        private void rd4_CheckedChanged(object sender, EventArgs e)
        {
            check_cauhoi();          
        }
    }
}
