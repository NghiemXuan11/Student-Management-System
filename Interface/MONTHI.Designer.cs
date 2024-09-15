namespace Interface
{
    partial class MONTHI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbmadethi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbthoigian = new System.Windows.Forms.ComboBox();
            this.cbtenmon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btlambai = new System.Windows.Forms.Button();
            this.cbmamonhoc = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbmadethi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbthoigian);
            this.groupBox1.Controls.Add(this.cbtenmon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Môn kiểm tra và thời gian làm bài";
            // 
            // cbmadethi
            // 
            this.cbmadethi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbmadethi.FormattingEnabled = true;
            this.cbmadethi.Location = new System.Drawing.Point(77, 96);
            this.cbmadethi.Name = "cbmadethi";
            this.cbmadethi.Size = new System.Drawing.Size(93, 24);
            this.cbmadethi.TabIndex = 6;        
            this.cbmadethi.Click += new System.EventHandler(this.cbmadethi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mã đề thi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(225, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phút.";
            // 
            // cbthoigian
            // 
            this.cbthoigian.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbthoigian.FormattingEnabled = true;
            this.cbthoigian.Location = new System.Drawing.Point(126, 60);
            this.cbthoigian.Name = "cbthoigian";
            this.cbthoigian.Size = new System.Drawing.Size(93, 24);
            this.cbthoigian.TabIndex = 3;
            // 
            // cbtenmon
            // 
            this.cbtenmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbtenmon.FormattingEnabled = true;
            this.cbtenmon.Location = new System.Drawing.Point(126, 23);
            this.cbtenmon.Name = "cbtenmon";
            this.cbtenmon.Size = new System.Drawing.Size(148, 24);
            this.cbtenmon.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời gian làm bài:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên môn kiểm tra:";
            // 
            // btlambai
            // 
            this.btlambai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btlambai.Location = new System.Drawing.Point(92, 144);
            this.btlambai.Name = "btlambai";
            this.btlambai.Size = new System.Drawing.Size(111, 45);
            this.btlambai.TabIndex = 1;
            this.btlambai.Text = "Làm Bài";
            this.btlambai.UseVisualStyleBackColor = true;
            this.btlambai.Click += new System.EventHandler(this.btlambai_Click);
            this.btlambai.MouseLeave += new System.EventHandler(this.btlambai_MouseLeave);
            this.btlambai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btlambai_MouseMove);
            // 
            // cbmamonhoc
            // 
            this.cbmamonhoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbmamonhoc.FormattingEnabled = true;
            this.cbmamonhoc.Location = new System.Drawing.Point(12, 144);
            this.cbmamonhoc.Name = "cbmamonhoc";
            this.cbmamonhoc.Size = new System.Drawing.Size(74, 24);
            this.cbmamonhoc.TabIndex = 5;
            // 
            // MONTHI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 201);
            this.Controls.Add(this.cbmamonhoc);
            this.Controls.Add(this.btlambai);
            this.Controls.Add(this.groupBox1);
            this.Name = "MONTHI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHỌN MÔN KIỂM TRA";
            this.Load += new System.EventHandler(this.MONTHI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbthoigian;
        private System.Windows.Forms.ComboBox cbtenmon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btlambai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbmamonhoc;
        private System.Windows.Forms.ComboBox cbmadethi;
        private System.Windows.Forms.Label label4;
    }
}