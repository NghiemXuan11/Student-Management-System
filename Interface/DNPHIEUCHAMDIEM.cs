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
using System.IO;
namespace Interface
{
    public partial class DNPHIEUCHAMDIEM : Form
    {
        public DNPHIEUCHAMDIEM()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }        
        private string _mathisinh;  
        private string _mamonhoc;     
        private string _tenmonhoc;
        private int _socaudung;     
        private int _socausai;
        private string _madethi;
        DSNOPBAI_BUL dsnopbai_bul = new DSNOPBAI_BUL();
        private void load_dsnopbai()
        {
            dg_danhsachnopbai.DataSource = dsnopbai_bul.load_dsnopbai();
        }
        private void dinhdangluoi()
        {
            dg_danhsachnopbai.ReadOnly = true;
            dg_danhsachnopbai.Columns[0].HeaderText="Tên thí sinh";
            dg_danhsachnopbai.Columns[1].Visible = false;
            dg_danhsachnopbai.Columns[2].HeaderText="Mã môn học";
            dg_danhsachnopbai.Columns[3].Visible = false;
            dg_danhsachnopbai.Columns[4].HeaderText="Số câu đúng";
            dg_danhsachnopbai.Columns[5].HeaderText="Số câu sai";
            dg_danhsachnopbai.Columns[6].HeaderText="Mã đề thi";
            dg_danhsachnopbai.Columns[7].Visible = false;
        }
        private void DNPHIEUCHAMDIEM_Load(object sender, EventArgs e)
        {
            load_dsnopbai();
            dinhdangluoi();
        }
        byte[] hinh;
        private void dg_danhsachnopbai_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = e.RowIndex;
                _mathisinh = dg_danhsachnopbai.Rows[dong].Cells[1].Value.ToString();
                _mamonhoc = dg_danhsachnopbai.Rows[dong].Cells[2].Value.ToString();
                _tenmonhoc = dg_danhsachnopbai.Rows[dong].Cells[3].Value.ToString();
                _socaudung = int.Parse(dg_danhsachnopbai.Rows[dong].Cells[4].Value.ToString());
                _socausai = int.Parse(dg_danhsachnopbai.Rows[dong].Cells[5].Value.ToString());
                _madethi = dg_danhsachnopbai.Rows[dong].Cells[6].Value.ToString();
                hinh = (byte[])(dg_danhsachnopbai.Rows[dong].Cells[7].Value);
                MemoryStream ms = new MemoryStream(hinh);
                hinhgv.Image = new Bitmap(ms);
            }
            catch
            { }
        }

        private void btcham_Click(object sender, EventArgs e)
        {
            if (dg_danhsachnopbai.Rows.Count == 1)
            { }
            else
            {
                PHIEUCHAMDIEM PCD = new PHIEUCHAMDIEM();
                PCD.Mathisinh = _mathisinh;
                PCD.Mamonhoc = _mamonhoc;
                PCD.Tenmonhoc = _tenmonhoc;
                PCD.Socaudung = _socaudung;
                PCD.Socausai = _socausai;
                PCD.MADETHI = _madethi;
                this.Hide();
                PCD.ShowDialog();
                Application.Exit(); 
            }
        }

        private void btlui_Click(object sender, EventArgs e)
        {
            try
            {              
                int lui = dg_danhsachnopbai.CurrentRow.Index - 1;
                if (lui != dg_danhsachnopbai.Rows.Count + 1)
                {
                    dg_danhsachnopbai.CurrentCell = dg_danhsachnopbai.Rows[lui].Cells[dg_danhsachnopbai.CurrentCell.ColumnIndex];                  
                }               
            }
            catch
            { }         
        }

        private void bttoi_Click(object sender, EventArgs e)
        {
            try
            {             
                int toi = dg_danhsachnopbai.CurrentRow.Index + 1;
                if (toi != dg_danhsachnopbai.Rows.Count - 1)
                {
                    dg_danhsachnopbai.CurrentCell = dg_danhsachnopbai.Rows[toi].Cells[dg_danhsachnopbai.CurrentCell.ColumnIndex];                   
                }           
           }
            catch
            { }         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            load_dsnopbai();
        }   
    }
}
