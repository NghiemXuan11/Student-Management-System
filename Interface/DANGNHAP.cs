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
using System.Threading;
namespace Interface
{
    public partial class DANGNHAP : Form
    {
        public DANGNHAP()
        {
            InitializeComponent();
        }
        TAIKHOAN_BUL taikhoan_bul = new TAIKHOAN_BUL();
        private void DANGNHAP_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btdangnhap;
            btdangnhap.ForeColor = Color.Black;
            btdangnhap.BackColor = Color.White;
            btthoat.ForeColor = Color.Black;
            btthoat.BackColor = Color.White;
            btdangky.ForeColor = Color.Black;
            btdangky.BackColor = Color.White;
        }        
        private void btdangnhap_Click(object sender, EventArgs e)
        {
            if (txttentk.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa điền tên tài khoản.";
                txttentk.Focus();
            }
            else if (txtmatkhau.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa điền mật khẩu.";
                txtmatkhau.Focus();
            }
            else
            {
                TAIKHOAN_PUBLIC taikhoan_public = new TAIKHOAN_PUBLIC();
                taikhoan_public.TENTK = txttentk.Text;
                taikhoan_public.MATKHAU = txtmatkhau.Text;
                int trangthaitaikhoan = 0;
                string quyentaikhoan = "";
                trangthaitaikhoan = taikhoan_bul.check_dangnhap(taikhoan_public);
                
                if (trangthaitaikhoan == 1)
                {
                    quyentaikhoan = taikhoan_bul.check_quyentaikhoan(taikhoan_public);
                    NhapCauHoi nch = new NhapCauHoi();
                    MONTHI monthi = new MONTHI();
                    nch.Magiaovien = taikhoan_bul.get_IDTAIKHOAN(taikhoan_public);
                    monthi.Mathisinh = taikhoan_bul.get_IDTAIKHOAN(taikhoan_public);
                    if (quyentaikhoan == "GV")
                    {                     
                        this.Hide();
                        nch.ShowDialog();                       
                        Application.Exit();
                    }
                    else if (quyentaikhoan == "TS")
                    {
                        this.Hide();
                        monthi.ShowDialog();
                        Application.Exit();
                        //lbtrangthai.ForeColor = Color.Red;
                        //lbtrangthai.Text = "Sai tên tài khoản hoặc mật khẩu.";
                    }
                }
                else if (trangthaitaikhoan == 0)
                {
                    lbtrangthai.ForeColor = Color.Red;
                    lbtrangthai.Text = "Sai tên tài khoản hoặc mật khẩu.";
                    txttentk.Focus();
                }
            }
        }

        private void checkboxAnHien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxAnHien.Checked == true)
            {
                txtmatkhau.PasswordChar = '\0';
            }
            else
            {
                txtmatkhau.PasswordChar = '*';
            }
        }

        private void btdangnhap_MouseMove(object sender, MouseEventArgs e)
        {
            btdangnhap.ForeColor = Color.GreenYellow;
            btdangnhap.BackColor = Color.Green;
        }

        private void btdangnhap_MouseLeave(object sender, EventArgs e)
        {
            btdangnhap.ForeColor = Color.Black;
            btdangnhap.BackColor = Color.White;
        }

        private void btthoat_MouseMove(object sender, MouseEventArgs e)
        {
            btthoat.ForeColor = Color.GreenYellow;
            btthoat.BackColor = Color.Red;
        }

        private void btthoat_MouseLeave(object sender, EventArgs e)
        {
            btthoat.ForeColor = Color.Black;
            btthoat.BackColor = Color.White;
        }

        private void btdangky_MouseMove(object sender, MouseEventArgs e)
        {
            btdangky.ForeColor = Color.GreenYellow;
            btdangky.BackColor = Color.Green;
        }

        private void btdangky_MouseLeave(object sender, EventArgs e)
        {
            btdangky.ForeColor = Color.Black;
            btdangky.BackColor = Color.White;
        }

        private void btdangky_Click(object sender, EventArgs e)
        {
            DANGKY dk = new DANGKY();
            dk.ShowDialog();
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
