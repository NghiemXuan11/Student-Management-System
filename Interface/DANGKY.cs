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
using System.IO;
using System.Threading;
using System.Data.SqlClient;
namespace Interface
{
    public partial class DANGKY : Form
    {
        public DANGKY()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        THISINH_BUL thisinh_bul = new THISINH_BUL();
        MONHOC_BUL monhoc_bul = new MONHOC_BUL();
        GIAOVIEN_BUL giaovien_bul = new GIAOVIEN_BUL();
        TAIKHOAN_BUL taikhoan_bul = new TAIKHOAN_BUL();
        private void DANGKY_Load(object sender, EventArgs e)
        {
            dinhdang_bt();
            cbmamonhoc.Hide();
            cbmonhoc.Enabled = false;
            lbDayMon.Enabled = false;
            cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmonhoc.DropDownStyle = ComboBoxStyle.DropDownList;
            set_tabindex();
        }
        private void set_tabindex()
        {
            txtentaikhoan.TabIndex = 0;
            txtmatkhau.TabIndex = 1;
            txthovaten.TabIndex = 2;
            txtmaso.TabIndex = 3;
            cbgioitinh.TabIndex = 4;
            datengaysinh.TabIndex = 5;
            cbmonhoc.TabIndex = 6;
        }
        private void reset_values()
        {
            txthovaten.Clear();
            txtmaso.Clear();
            txtentaikhoan.Clear();
            txtmatkhau.Clear();
            cbgioitinh.SelectedIndex = -1;
            cbmamonhoc.SelectedIndex = -1;
            cbmonhoc.SelectedIndex = -1;
            datengaysinh.Value = DateTime.Today;
            hinhdangky.Image = null;
            rdGiaovien.Checked = false;
            rdGiaovien.ForeColor = Color.Black;
            rdThisinh.Checked = false;
            rdThisinh.ForeColor = Color.Black;
            cbmonhoc.Enabled = false;
            lbDayMon.Enabled = false;
            cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbmonhoc.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void Disable_LBTRANGTHAI()
        {
            Thread.Sleep(1500);
            lbtrangthai.Text = "";
        }
        private void insert_dangky()
        {
            if (txtentaikhoan.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa điền tên tài khoản.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (txtmatkhau.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa mật khẩu.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (txtmatkhau.TextLength <= 6 || txtmatkhau.TextLength >= 20)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Mật khẩu phải lớn hơn 6 ký tự và nhỏ hơn 20.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (txthovaten.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa điền họ và tên.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (txtmaso.TextLength == 0)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa điền mã số.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (cbgioitinh.Text == "")
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa chọn giới tính.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (datengaysinh.Value.Day == DateTime.Today.Day && datengaysinh.Value.Month == DateTime.Today.Month && datengaysinh.Value.Year == DateTime.Today.Year)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa chọn ngày sinh.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (hinhdangky.Image == null)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Nhấn vào ô hình để chọn hình ảnh.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else if (rdThisinh.Checked == false && rdGiaovien.Checked == false)
            {
                lbtrangthai.ForeColor = Color.Red;
                lbtrangthai.Text = "Chưa chọn quyền sửa dụng của tài khoản.";
                Thread t = new Thread(Disable_LBTRANGTHAI);
                t.Start();
            }
            else
            {
                if (rdThisinh.Checked == true)
                {
                    try
                    {
                        THISINH_PUBLIC thisinh_public = new THISINH_PUBLIC();
                        thisinh_public.MATS = txtmaso.Text;
                        thisinh_public.TENTHISINH = txthovaten.Text;
                        thisinh_public.GIOITINH = cbgioitinh.Text;
                        thisinh_public.NGAYSINH = DateTime.Parse(datengaysinh.Text);
                        thisinh_bul.insert_thisinh(thisinh_public);
                        // FileStream để đọc các tập tin hình.
                        FileStream fs = new FileStream(duongdan, FileMode.Open, FileAccess.Read);
                        // Tạo mảng kiểu byte với cái kích thước của Filestream
                        byte[] mangLuuHinh = new byte[fs.Length];
                        // Đọc dữ liệu từ FileStream và bỏ vào cái mảng Byte
                        fs.Read(mangLuuHinh, 0, Convert.ToInt32(fs.Length));
                        // Đóng filestream
                        fs.Close();
                        thisinh_public.HINH = mangLuuHinh;
                        thisinh_bul.insert_hinhthisinh(thisinh_public);
                        TAIKHOAN_PUBLIC taikhoan_public = new TAIKHOAN_PUBLIC();
                        taikhoan_public.TENTK = txtentaikhoan.Text;
                        taikhoan_public.MATKHAU = txtmatkhau.Text;
                        taikhoan_public.IDTAIKHOAN = txtmaso.Text;
                        taikhoan_public.QUYEN = "TS";
                        taikhoan_bul.insert_taikhoan(taikhoan_public);
                        lbtrangthai.ForeColor = Color.Green;
                        lbtrangthai.Text = "Đăng ký tài khoản thí sinh thành công.";
                        reset_values();
                        Thread t = new Thread(Disable_LBTRANGTHAI);
                        t.Start();
                    }
                    catch(SqlException sql)
                    {
                        if (sql.Message.Contains("Violation of PRIMARY KEY constraint 'PK_TENTK'. Cannot insert duplicate key in object 'dbo.taikhoan'"))
                        {
                            lbtrangthai.ForeColor = Color.Red;
                            lbtrangthai.Text = "Tên tài khoản bị trùng.";
                            Thread t = new Thread(Disable_LBTRANGTHAI);
                            t.Start();
                        }
                        else
                        {
                            lbtrangthai.ForeColor = Color.Red;
                            lbtrangthai.Text = "Mã thí sinh bị trùng.";
                            Thread t = new Thread(Disable_LBTRANGTHAI);
                            t.Start();
                        }
                    }
                }
                else if (rdGiaovien.Checked == true)
                {
                    if (cbmonhoc.Text == "")
                    {
                        lbtrangthai.ForeColor = Color.Red;
                        lbtrangthai.Text = "Chưa chọn môn phụ trách.";
                        Thread t = new Thread(Disable_LBTRANGTHAI);
                        t.Start();
                    }
                    else
                    {
                        try
                        {
                            GIAOVIEN_PUBLIC giaovien_public = new GIAOVIEN_PUBLIC();
                            giaovien_public.MAGV = txtmaso.Text;
                            giaovien_public.TENGV = txthovaten.Text;
                            giaovien_public.GIOITINH = cbgioitinh.Text;
                            giaovien_public.MAMONHOC = cbmamonhoc.Text;
                            giaovien_public.NGAYSINH = DateTime.Parse(datengaysinh.Text);
                            giaovien_bul.insert_giaovien(giaovien_public);
                            // FileStream để đọc các tập tin hình.
                            FileStream fs = new FileStream(duongdan, FileMode.Open, FileAccess.Read);
                            // Tạo mảng kiểu byte với cái kích thước của Filestream
                            byte[] mangLuuHinh = new byte[fs.Length];
                            // Đọc dữ liệu từ FileStream và bỏ vào cái mảng Byte
                            fs.Read(mangLuuHinh, 0, Convert.ToInt32(fs.Length));
                            // Đóng filestream
                            fs.Close();
                            giaovien_public.HINH = mangLuuHinh;
                            giaovien_bul.insert_hinhgiaovien(giaovien_public);
                            TAIKHOAN_PUBLIC taikhoan_public = new TAIKHOAN_PUBLIC();
                            taikhoan_public.TENTK = txtentaikhoan.Text;
                            taikhoan_public.MATKHAU = txtmatkhau.Text;
                            taikhoan_public.IDTAIKHOAN = txtmaso.Text;
                            taikhoan_public.QUYEN = "GV";
                            taikhoan_bul.insert_taikhoan(taikhoan_public);
                            lbtrangthai.ForeColor = Color.Green;
                            lbtrangthai.Text = "Đăng ký tài khoản giáo viên thành công.";
                            reset_values();
                            Thread t = new Thread(Disable_LBTRANGTHAI);
                            t.Start();
                        }
                        catch(SqlException sql)
                        {
                            if (sql.Message.Contains("Violation of PRIMARY KEY constraint 'PK_TENTK'. Cannot insert duplicate key in object 'dbo.taikhoan'"))
                            {
                                lbtrangthai.ForeColor = Color.Red;
                                lbtrangthai.Text = "Tên tài khoản bị trùng.";
                                Thread t = new Thread(Disable_LBTRANGTHAI);
                                t.Start();
                            }
                            else
                            {
                                lbtrangthai.ForeColor = Color.Red;
                                lbtrangthai.Text = "Mã giáo viên bị trùng.";
                                Thread t = new Thread(Disable_LBTRANGTHAI);
                                t.Start();
                            }
                        }
                    }
                }
            }
        }
        private void btdangky_Click(object sender, EventArgs e)
        {
            insert_dangky();
        }

        private void rdThisinh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdThisinh.Checked == true)
            {
                lbDayMon.Enabled = false;
                cbmonhoc.Enabled = false;
                rdThisinh.ForeColor = Color.Green;
                rdGiaovien.ForeColor = Color.Black;
            }
        }

        private void rdGiaovien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaovien.Checked == true)
            {
                lbDayMon.Enabled = true;
                cbmonhoc.Enabled = true;
                rdGiaovien.ForeColor = Color.Green;
                rdThisinh.ForeColor = Color.Black;
            }
        }
        string tenhinh, duongdan;
        private void hinhdangky_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.JPG ;*.PNG ;*.GIF) |*.jpg;*.png;*.gif";
            open.ShowDialog();
            {
                tenhinh = open.SafeFileName;
                duongdan = open.FileName;
                hinhdangky.ImageLocation = duongdan;
            }
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbmonhoc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = monhoc_bul.load_monhoc();
            cbmonhoc.DataSource = dt;
            cbmonhoc.DisplayMember = "TENMONHOC";
            cbmamonhoc.DataSource = dt;
            cbmamonhoc.DisplayMember = "MAMONHOC";
        }      
        private void btdangky_MouseMove(object sender, MouseEventArgs e)
        {
            btdangky.BackColor = Color.Green;
            btdangky.ForeColor = Color.GreenYellow;
        }
        private void dinhdang_bt()
        {
            btdangky.BackColor = Color.White;
            btdangky.ForeColor = Color.Black;
            btthoat.BackColor = Color.White;
            btthoat.ForeColor = Color.Black;
        }
        private void btdangky_MouseLeave(object sender, EventArgs e)
        {
            btdangky.BackColor = Color.White;
            btdangky.ForeColor = Color.Black;
        }

        private void btthoat_MouseMove(object sender, MouseEventArgs e)
        {
            btthoat.BackColor = Color.Red;
            btthoat.ForeColor = Color.GreenYellow;
        }

        private void btthoat_MouseLeave(object sender, EventArgs e)
        {
            btthoat.BackColor = Color.White;
            btthoat.ForeColor = Color.Black;
        }

        private void hinhdangky_MouseMove(object sender, MouseEventArgs e)
        {
            hinhdangky.BackColor = Color.WhiteSmoke;
        }

        private void hinhdangky_MouseLeave(object sender, EventArgs e)
        {
            hinhdangky.BackColor = SystemColors.ControlDark;
        }
    }
}
