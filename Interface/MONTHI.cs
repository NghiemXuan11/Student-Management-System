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
namespace Interface
{
    public partial class MONTHI : Form
    {
        public MONTHI()
        {
            InitializeComponent();
        }
        private string _mathisinh;

        public string Mathisinh
        {
            get { return _mathisinh; }
            set { _mathisinh = value; }
        }       
        private void MONTHI_Load(object sender, EventArgs e)
        {
            cbtenmon.DropDownStyle = ComboBoxStyle.DropDownList;
            cbthoigian.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmadethi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmamonhoc.Hide();
            btlambai.ForeColor = Color.Black;
            btlambai.BackColor = Color.White;
            DataTable dt = new DataTable();
            dt = monhoc_bul.load_monhoc();
            cbtenmon.DataSource = dt;
            cbtenmon.DisplayMember = "TENMONHOC";
            cbthoigian.DataSource = dt;
            cbthoigian.DisplayMember = "TGTHI";
            cbmamonhoc.DataSource = dt;
            cbmamonhoc.DisplayMember = "MAMONHOC";         
        }
        MONHOC_BUL monhoc_bul = new MONHOC_BUL();

        private void btlambai_Click(object sender, EventArgs e)
        {
            if (cbmadethi.Text == "")
            {
                MessageBox.Show("Chưa chọn mã đề thi.","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                LamBaiTracNghiem lbtn = new LamBaiTracNghiem();
                lbtn.Phut = int.Parse(cbthoigian.Text);
                lbtn.Tenmonthi = cbtenmon.Text;
                lbtn.Mathisinh = Mathisinh;
                lbtn.MAMONHOC = cbmamonhoc.Text;
                lbtn.MADETHI = cbmadethi.Text;
                this.Hide();
                lbtn.ShowDialog();
                Application.Exit();
            }
        }

        private void btlambai_MouseMove(object sender, MouseEventArgs e)
        {
            btlambai.ForeColor = Color.GreenYellow;
            btlambai.BackColor = Color.Green;
        }

        private void btlambai_MouseLeave(object sender, EventArgs e)
        {
            btlambai.ForeColor = Color.Black;
            btlambai.BackColor = Color.White;
        }

        private void cbmadethi_Click(object sender, EventArgs e)
        {
            MONHOC_PUBLIC monhoc_public = new MONHOC_PUBLIC();
            monhoc_public.MAMONHOC = cbmamonhoc.Text;
            cbmadethi.DataSource = monhoc_bul.load_monhocwithwhere(monhoc_public);
            cbmadethi.DisplayMember = "madethi";
        }
       
    }
}
