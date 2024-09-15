using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BUL;
using PUBLIC;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
namespace Interface
{
    public partial class PHIEUCHAMDIEM : Form
    {
        public PHIEUCHAMDIEM()
        {
            InitializeComponent();
        }    
        private string _magiaovien;

        public string Magiaovien
        {
            get { return _magiaovien; }
            set { _magiaovien = value; }
        }
        private string _mathisinh;

        public string Mathisinh
        {
            get { return _mathisinh; }
            set { _mathisinh = value; }
        }
        private string _mamonhoc;

        public string Mamonhoc
        {
            get { return _mamonhoc; }
            set { _mamonhoc = value; }
        }
        private string _tenmonhoc;

        public string Tenmonhoc
        {
            get { return _tenmonhoc; }
            set { _tenmonhoc = value; }
        }
        private int _socaudung;

        public int Socaudung
        {
            get { return _socaudung; }
            set { _socaudung = value; }
        }
        private int _socausai;

        public int Socausai
        {
            get { return _socausai; }
            set { _socausai = value; }
        }
        private string _MADETHI;

        public string MADETHI
        {
            get { return _MADETHI; }
            set { _MADETHI = value; }
        }
        THISINH_BUL thisinh_bul = new THISINH_BUL();
        CAUHOI_BUL cauhoi_bul = new CAUHOI_BUL();
        INPHIEUDIEM_BUL phieudiem_bul = new INPHIEUDIEM_BUL();
        private void dinhdangluoi()
        {
            dg_dscauhoidalam.ReadOnly = true;
            dg_dscauhoidalam.Columns[0].HeaderText = "Nội dung câu hỏi";
            dg_dscauhoidalam.Columns[1].HeaderText = "Đáp án (1,2,3,4)";
            dg_dscauhoidalam.Columns[2].Visible = false;
            dg_dscauhoidalam.Columns[3].HeaderText = "Đáp án đúng";
            dg_dscauhoidalam.Columns[4].Visible = false;
        }
        private void dinhdangphieu()
        {
            dgphieudiem.ReadOnly = true;
            dgphieudiem.Columns[0].HeaderText="Mã thí sinh";
            dgphieudiem.Columns[1].HeaderText="Tên thí sinh";
            dgphieudiem.Columns[2].HeaderText="Môn thi";
            dgphieudiem.Columns[3].HeaderText = "Mã đề thi";
            dgphieudiem.Columns[4].HeaderText="Tổng số câu";
            dgphieudiem.Columns[5].HeaderText="Số câu đúng";
            dgphieudiem.Columns[6].HeaderText="Số câu sai";
            dgphieudiem.Columns[7].HeaderText="Tổng điểm";
        }
        private void PHIEUCHAMDIEM_Load(object sender, EventArgs e)
        {
            
            dg_thisinh.Hide();
            dgphieudiem.Hide();
            THISINH_PUBLIC thisinh_public = new THISINH_PUBLIC();
            CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
            INPHIEUDIEM_PUBLIC phieudiem_public = new INPHIEUDIEM_PUBLIC();
            phieudiem_public.MATS = Mathisinh;
            cauhoi_public.MAMONHOC = Mamonhoc;
            thisinh_public.MATS = Mathisinh;
            cauhoi_public.MADETHI = MADETHI;
            dg_thisinh.DataSource = thisinh_bul.load_ts_PD(thisinh_public);
            dg_dscauhoidalam.DataSource = cauhoi_bul.load_cauhoidachon(cauhoi_public);           
            dgphieudiem.DataSource = phieudiem_bul.load_phieudiem(phieudiem_public);          
            dinhdangluoi();
            dinhdangphieu();
            lbtenmon.Text = Tenmonhoc;
            lbtongsocau.Text = (dg_dscauhoidalam.Rows.Count - 1).ToString();
            lbtongsocaudung.Text = Socaudung.ToString();
            lbtongsocausai.Text = Socausai.ToString();
            lbmade.Text = MADETHI;
        }

        private void dg_thisinh_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            lbtents.Text = dg_thisinh.Rows[dong].Cells[0].Value.ToString();
            lbmasots.Text = dg_thisinh.Rows[dong].Cells[1].Value.ToString();
        }            
        private void save_dialog()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Word Documents (*.docx)|*.docx";         
            save.FileName = lbtents.Text;
            if (save.ShowDialog() == DialogResult.OK)
            {
                XuatRaFileWord(dgphieudiem, save.FileName);                
            }            
        }
        public void XuatRaFileWord(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style                        
                oDoc.Application.Selection.Tables[1].set_Style("Table Grid 3");
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;            

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Phiếu Điểm";
                    headerRange.Font.Size = 16;
                    headerRange.Font.Bold = 1;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save the file
                oDoc.SaveAs(filename);          
            }
        }
        DSNOPBAI_BUL dsnopbai_bul = new DSNOPBAI_BUL();
        private void bttinhdiem_Click(object sender, EventArgs e)
        {
            if (txtsodiemtungcau.TextLength == 0)
            {
                MessageBox.Show("Nhập số điểm cho từng câu hỏi vào ô.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                lbdiem.Text = (float.Parse(txtsodiemtungcau.Text) * Socaudung).ToString();
                INPHIEUDIEM_PUBLIC inphieudiem_public = new INPHIEUDIEM_PUBLIC();
                CAUHOI_PUBLIC cauhoi_public = new CAUHOI_PUBLIC();
                DSNOPBAI_PUBLIC dsnopbai_public = new DSNOPBAI_PUBLIC();
                dsnopbai_public.MATHISINH = Mathisinh;
                dsnopbai_public.MADETHI = MADETHI;
                dsnopbai_public.MAMONHOC = Mamonhoc;
                cauhoi_public.MAMONHOC = Mamonhoc;
                cauhoi_public.MADETHI = MADETHI;
                inphieudiem_public.Monthi = Tenmonhoc;
                inphieudiem_public.Tongsocau = dg_dscauhoidalam.Rows.Count - 1;
                inphieudiem_public.Socaudung = Socaudung;
                inphieudiem_public.Socausai = Socausai;
                inphieudiem_public.Tongdiem = float.Parse(txtsodiemtungcau.Text) * Socaudung;
                inphieudiem_public.MATS = Mathisinh;
                inphieudiem_public.MAGV = Magiaovien;
                inphieudiem_public.Madethi = MADETHI;
                phieudiem_bul.insert_phieudiem(inphieudiem_public);
                dgphieudiem.DataSource = phieudiem_bul.load_phieudiem(inphieudiem_public);
                Thread inphieu = new Thread(new ThreadStart(save_dialog));
                inphieu.ApartmentState = ApartmentState.STA;
                inphieu.IsBackground = false;
                inphieu.Start();               
                btinphieudiem.Enabled=false;
                txtsodiemtungcau.Enabled = false;
                cauhoi_bul.update_cauhoidachon(cauhoi_public);
                dsnopbai_bul.delete_dsnopbai(dsnopbai_public);
                Thread tat = new Thread(tatungdung);
                tat.IsBackground = false;
                tat.Start();
            }            
        }
        private void dongfileword()
        {
            Process[] GetPArry = Process.GetProcesses();
            foreach (Process testProcess in GetPArry)
            {
                string ProcessName = testProcess.ProcessName;

                ProcessName = ProcessName.ToLower();
                if (ProcessName.CompareTo("winword") == 0)
                {
                    testProcess.Kill();
                }                    
            } 
        }
        private void tatungdung()
        {
            MessageBox.Show("Ứng dũng sẽ tắt sau 5 giây...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Thread.Sleep(5000);
            dongfileword();
            this.Close();
        }       
    }
}
