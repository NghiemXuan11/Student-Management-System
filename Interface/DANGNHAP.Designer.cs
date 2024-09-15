namespace Interface
{
    partial class DANGNHAP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DANGNHAP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmatkhau = new System.Windows.Forms.TextBox();
            this.txttentk = new System.Windows.Forms.TextBox();
            this.lbtrangthai = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkboxAnHien = new System.Windows.Forms.CheckBox();
            this.btdangnhap = new System.Windows.Forms.Button();
            this.btthoat = new System.Windows.Forms.Button();
            this.btdangky = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtmatkhau);
            this.groupBox1.Controls.Add(this.txttentk);
            this.groupBox1.Controls.Add(this.lbtrangthai);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đăng nhập";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtmatkhau
            // 
            this.txtmatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtmatkhau.Location = new System.Drawing.Point(77, 69);
            this.txtmatkhau.Name = "txtmatkhau";
            this.txtmatkhau.PasswordChar = '*';
            this.txtmatkhau.Size = new System.Drawing.Size(203, 22);
            this.txtmatkhau.TabIndex = 3;
            // 
            // txttentk
            // 
            this.txttentk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txttentk.Location = new System.Drawing.Point(104, 25);
            this.txttentk.Name = "txttentk";
            this.txttentk.Size = new System.Drawing.Size(176, 22);
            this.txttentk.TabIndex = 1;
            // 
            // lbtrangthai
            // 
            this.lbtrangthai.AutoSize = true;
            this.lbtrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtrangthai.Location = new System.Drawing.Point(6, 105);
            this.lbtrangthai.Name = "lbtrangthai";
            this.lbtrangthai.Size = new System.Drawing.Size(0, 16);
            this.lbtrangthai.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản:";
            // 
            // checkboxAnHien
            // 
            this.checkboxAnHien.AutoSize = true;
            this.checkboxAnHien.BackColor = System.Drawing.Color.Transparent;
            this.checkboxAnHien.Location = new System.Drawing.Point(12, 142);
            this.checkboxAnHien.Name = "checkboxAnHien";
            this.checkboxAnHien.Size = new System.Drawing.Size(113, 17);
            this.checkboxAnHien.TabIndex = 1;
            this.checkboxAnHien.Text = "Ẩn/Hiện mật khẩu";
            this.checkboxAnHien.UseVisualStyleBackColor = false;
            this.checkboxAnHien.CheckedChanged += new System.EventHandler(this.checkboxAnHien_CheckedChanged);
            // 
            // btdangnhap
            // 
            this.btdangnhap.BackColor = System.Drawing.Color.Transparent;
            this.btdangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btdangnhap.Location = new System.Drawing.Point(12, 165);
            this.btdangnhap.Name = "btdangnhap";
            this.btdangnhap.Size = new System.Drawing.Size(91, 39);
            this.btdangnhap.TabIndex = 2;
            this.btdangnhap.Text = "Đăng Nhập";
            this.btdangnhap.UseVisualStyleBackColor = false;
            this.btdangnhap.Click += new System.EventHandler(this.btdangnhap_Click);
            this.btdangnhap.MouseLeave += new System.EventHandler(this.btdangnhap_MouseLeave);
            this.btdangnhap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btdangnhap_MouseMove);
            // 
            // btthoat
            // 
            this.btthoat.BackColor = System.Drawing.Color.Transparent;
            this.btthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btthoat.Location = new System.Drawing.Point(206, 165);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(91, 39);
            this.btthoat.TabIndex = 3;
            this.btthoat.Text = "Thoát";
            this.btthoat.UseVisualStyleBackColor = false;
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
            this.btthoat.MouseLeave += new System.EventHandler(this.btthoat_MouseLeave);
            this.btthoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btthoat_MouseMove);
            // 
            // btdangky
            // 
            this.btdangky.BackColor = System.Drawing.Color.Transparent;
            this.btdangky.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btdangky.Location = new System.Drawing.Point(109, 165);
            this.btdangky.Name = "btdangky";
            this.btdangky.Size = new System.Drawing.Size(91, 39);
            this.btdangky.TabIndex = 4;
            this.btdangky.Text = "Đăng Ký";
            this.btdangky.UseVisualStyleBackColor = false;
            this.btdangky.Click += new System.EventHandler(this.btdangky_Click);
            this.btdangky.MouseLeave += new System.EventHandler(this.btdangky_MouseLeave);
            this.btdangky.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btdangky_MouseMove);
            // 
            // DANGNHAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Interface.Properties.Resources.MauVang;
            this.ClientSize = new System.Drawing.Size(310, 216);
            this.Controls.Add(this.btdangky);
            this.Controls.Add(this.btthoat);
            this.Controls.Add(this.btdangnhap);
            this.Controls.Add(this.checkboxAnHien);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(326, 255);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(326, 255);
            this.Name = "DANGNHAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương Trình Làm Bài Trắc Nghiệm";
            this.Load += new System.EventHandler(this.DANGNHAP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbtrangthai;
        private System.Windows.Forms.TextBox txttentk;
        private System.Windows.Forms.CheckBox checkboxAnHien;
        private System.Windows.Forms.TextBox txtmatkhau;
        private System.Windows.Forms.Button btdangnhap;
        private System.Windows.Forms.Button btthoat;
        private System.Windows.Forms.Button btdangky;
    }
}