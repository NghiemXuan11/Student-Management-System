using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUL;
using PUBLIC;
using System.Threading;
namespace Interface
{
    public partial class MONHOC : Form
    {
        public MONHOC()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        MONHOC_BUL monhoc_bul = new MONHOC_BUL();
        private void dinhdangluoi()
        {
            dg_monhoc.ReadOnly = true;            
            dg_monhoc.Columns[0].HeaderText = "Mã môn học";
            dg_monhoc.Columns[1].HeaderText = "Tên môn hoc";
        }
        private void show_datagird()
        {          
            bindingSource1.DataSource = monhoc_bul.load_monhoc();
            dg_monhoc.DataSource = bindingSource1;            
        }
        private void MONHOC_Load(object sender, EventArgs e)
        {
            show_datagird();
            dinhdangluoi();           
        }
        private void Delete_textbox()
        {
            if (dg_monhoc.Rows.Count == 1)
            {
                txtmamonhoc.Clear();
                txttenmonhoc.Clear();
            }           
        }
        private void Disable_Lbtrangthai()
        {
            Thread.Sleep(1200);
            lbtrangthai.Text = "";
        }
        private void insert_monhoc()
        {
            if (txtmamonhoc.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Mã môn học chưa điền.";
                Thread t = new Thread(Disable_Lbtrangthai);
                t.Start();
            }
            else if (txttenmonhoc.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Tên môn học chưa điền.";
                Thread t = new Thread(Disable_Lbtrangthai);
                t.Start();
            }
            else
            {
                try
                {
                    MONHOC_PUBLIC monhoc_public = new MONHOC_PUBLIC();
                    monhoc_public.MAMONHOC = txtmamonhoc.Text;
                    monhoc_public.TENMONHOC = txttenmonhoc.Text;
                    monhoc_bul.insert_monhoc(monhoc_public);
                    lbtrangthai.ForeColor = Color.Green;
                    show_datagird();
                    lbtrangthai.Text = "Thêm môn học thành công.";
                    txtmamonhoc.Clear();
                    txttenmonhoc.Clear();
                    Thread t = new Thread(Disable_Lbtrangthai);
                    t.Start();
                }
                catch
                {
                    lbtrangthai.ForeColor = Color.Red;
                    lbtrangthai.Text = "Mã môn học bị trùng.";
                    Thread t = new Thread(Disable_Lbtrangthai);
                    t.Start();
                }
            }           
        }
        private void update_monhoc()
        {
            if (txtmamonhoc.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Mã môn học chưa điền.";
                Thread t = new Thread(Disable_Lbtrangthai);
                t.Start();
            }
            else if (txttenmonhoc.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Tên môn học chưa điền.";
                Thread t = new Thread(Disable_Lbtrangthai);
                t.Start();
            }
            else
            {
                try
                {
                    MONHOC_PUBLIC monhoc_public = new MONHOC_PUBLIC();
                    monhoc_public.MAMONHOC = txtmamonhoc.Text;
                    monhoc_public.MAMONHOCOLD = mamonhoc_old;
                    monhoc_public.TENMONHOC = txttenmonhoc.Text;
                    monhoc_bul.update_monhoc(monhoc_public);
                    lbtrangthai.ForeColor = Color.Green;
                    show_datagird();
                    lbtrangthai.Text = "Sửa môn học thành công.";
                    Thread t = new Thread(Disable_Lbtrangthai);
                    t.Start();
                }
                catch
                {
                    lbtrangthai.ForeColor = Color.Red;
                    lbtrangthai.Text = "Mã môn học bị trùng.";
                    Thread t = new Thread(Disable_Lbtrangthai);
                    t.Start();
                }
            }
        }
        private void delete_monhoc()
        {
            if (txtmamonhoc.TextLength == 0 && txttenmonhoc.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Không có gì để xóa, điền mã môn vào ô để xóa.";
                Thread t = new Thread(Disable_Lbtrangthai);
                t.Start();
            }           
            else if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa môn học này?.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                MONHOC_PUBLIC monhoc_public = new MONHOC_PUBLIC();
                monhoc_public.MAMONHOC = txtmamonhoc.Text;
                monhoc_bul.delete_monhoc(monhoc_public); 
                lbtrangthai.ForeColor = Color.Green;               
                lbtrangthai.Text = "Xóa thành công.";
                show_datagird();
                Thread t1 = new Thread(Delete_textbox);
                t1.Start();
                Thread t = new Thread(Disable_Lbtrangthai);
                t.Start();
            }
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            insert_monhoc();
        }
        private string mamonhoc_old = "";
        private void dg_monhoc_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = e.RowIndex;
                txtmamonhoc.Text = dg_monhoc.Rows[dong].Cells[0].Value.ToString();
                mamonhoc_old = dg_monhoc.Rows[dong].Cells[0].Value.ToString();
                txttenmonhoc.Text = dg_monhoc.Rows[dong].Cells[1].Value.ToString();
            }
            catch
            { }          
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            update_monhoc();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            delete_monhoc();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_monhoc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
