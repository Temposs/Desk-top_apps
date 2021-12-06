namespace IP_subnet_calculator
{
    partial class Form1
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
            this.rbA = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nuID4 = new System.Windows.Forms.NumericUpDown();
            this.nuID3 = new System.Windows.Forms.NumericUpDown();
            this.nuID2 = new System.Windows.Forms.NumericUpDown();
            this.nuID1 = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbPocSieti = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tbWildMaska = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSubMaska = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbBitMap1 = new System.Windows.Forms.TextBox();
            this.tbBitMap4 = new System.Windows.Forms.TextBox();
            this.tbBitMap3 = new System.Windows.Forms.TextBox();
            this.tbBitMap2 = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRozsah = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPocKlientov = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuID4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuID3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuID2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuID1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbA
            // 
            this.rbA.AutoSize = true;
            this.rbA.Checked = true;
            this.rbA.Location = new System.Drawing.Point(18, 19);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(35, 22);
            this.rbA.TabIndex = 0;
            this.rbA.TabStop = true;
            this.rbA.Text = "A";
            this.rbA.UseVisualStyleBackColor = true;
            this.rbA.CheckedChanged += new System.EventHandler(this.rbA_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.rbC);
            this.groupBox1.Controls.Add(this.rbB);
            this.groupBox1.Controls.Add(this.rbA);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(18, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trieda siete";
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(118, 19);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(37, 22);
            this.rbC.TabIndex = 2;
            this.rbC.Text = "C";
            this.rbC.UseVisualStyleBackColor = true;
            this.rbC.CheckedChanged += new System.EventHandler(this.rbC_CheckedChanged);
            // 
            // rbB
            // 
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(66, 19);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(36, 22);
            this.rbB.TabIndex = 1;
            this.rbB.Text = "B";
            this.rbB.UseVisualStyleBackColor = true;
            this.rbB.CheckedChanged += new System.EventHandler(this.rbB_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.nuID4);
            this.groupBox2.Controls.Add(this.nuID3);
            this.groupBox2.Controls.Add(this.nuID2);
            this.groupBox2.Controls.Add(this.nuID1);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(18, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 77);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IP adresa";
            // 
            // nuID4
            // 
            this.nuID4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nuID4.Location = new System.Drawing.Point(294, 39);
            this.nuID4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nuID4.Name = "nuID4";
            this.nuID4.Size = new System.Drawing.Size(85, 24);
            this.nuID4.TabIndex = 11;
            this.nuID4.ValueChanged += new System.EventHandler(this.nuID4_ValueChanged);
            // 
            // nuID3
            // 
            this.nuID3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nuID3.Location = new System.Drawing.Point(198, 39);
            this.nuID3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nuID3.Name = "nuID3";
            this.nuID3.Size = new System.Drawing.Size(85, 24);
            this.nuID3.TabIndex = 10;
            this.nuID3.ValueChanged += new System.EventHandler(this.nuID3_ValueChanged);
            // 
            // nuID2
            // 
            this.nuID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nuID2.Location = new System.Drawing.Point(102, 39);
            this.nuID2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nuID2.Name = "nuID2";
            this.nuID2.Size = new System.Drawing.Size(85, 24);
            this.nuID2.TabIndex = 9;
            this.nuID2.ValueChanged += new System.EventHandler(this.nuID2_ValueChanged);
            // 
            // nuID1
            // 
            this.nuID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nuID1.Location = new System.Drawing.Point(6, 38);
            this.nuID1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nuID1.Name = "nuID1";
            this.nuID1.Size = new System.Drawing.Size(85, 24);
            this.nuID1.TabIndex = 8;
            this.nuID1.ValueChanged += new System.EventHandler(this.nuID1_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(287, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 3);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(191, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 3);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(95, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 3);
            this.panel1.TabIndex = 4;
            // 
            // cbPocSieti
            // 
            this.cbPocSieti.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPocSieti.FormattingEnabled = true;
            this.cbPocSieti.Location = new System.Drawing.Point(18, 238);
            this.cbPocSieti.Name = "cbPocSieti";
            this.cbPocSieti.Size = new System.Drawing.Size(155, 26);
            this.cbPocSieti.TabIndex = 4;
            this.cbPocSieti.SelectedIndexChanged += new System.EventHandler(this.cbPocSieti_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.tbWildMaska);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.tbSubMaska);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.tbRozsah);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.cbPocKlientov);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.cbPocSieti);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(423, 656);
            this.panel4.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(253, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Wildcard Maska";
            // 
            // tbWildMaska
            // 
            this.tbWildMaska.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbWildMaska.Location = new System.Drawing.Point(239, 376);
            this.tbWildMaska.Name = "tbWildMaska";
            this.tbWildMaska.ReadOnly = true;
            this.tbWildMaska.Size = new System.Drawing.Size(165, 24);
            this.tbWildMaska.TabIndex = 16;
            this.tbWildMaska.Text = "255.255.255.255";
            this.tbWildMaska.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(32, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Subnet Maska";
            // 
            // tbSubMaska
            // 
            this.tbSubMaska.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSubMaska.Location = new System.Drawing.Point(18, 376);
            this.tbSubMaska.Name = "tbSubMaska";
            this.tbSubMaska.ReadOnly = true;
            this.tbSubMaska.Size = new System.Drawing.Size(165, 24);
            this.tbSubMaska.TabIndex = 14;
            this.tbSubMaska.Text = "255.255.255.255";
            this.tbSubMaska.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 627);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 26);
            this.button1.TabIndex = 13;
            this.button1.Text = "info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Controls.Add(this.tbBitMap1);
            this.panel5.Controls.Add(this.tbBitMap4);
            this.panel5.Controls.Add(this.tbBitMap3);
            this.panel5.Controls.Add(this.tbBitMap2);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(18, 456);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(386, 33);
            this.panel5.TabIndex = 12;
            // 
            // tbBitMap1
            // 
            this.tbBitMap1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBitMap1.Location = new System.Drawing.Point(6, 5);
            this.tbBitMap1.Name = "tbBitMap1";
            this.tbBitMap1.ReadOnly = true;
            this.tbBitMap1.Size = new System.Drawing.Size(85, 22);
            this.tbBitMap1.TabIndex = 22;
            this.tbBitMap1.Text = "nnnnnnnn";
            this.tbBitMap1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBitMap4
            // 
            this.tbBitMap4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBitMap4.Location = new System.Drawing.Point(294, 5);
            this.tbBitMap4.Name = "tbBitMap4";
            this.tbBitMap4.ReadOnly = true;
            this.tbBitMap4.Size = new System.Drawing.Size(85, 22);
            this.tbBitMap4.TabIndex = 21;
            this.tbBitMap4.Text = "nnnnnnnn";
            this.tbBitMap4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBitMap3
            // 
            this.tbBitMap3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBitMap3.Location = new System.Drawing.Point(198, 5);
            this.tbBitMap3.Name = "tbBitMap3";
            this.tbBitMap3.ReadOnly = true;
            this.tbBitMap3.Size = new System.Drawing.Size(85, 22);
            this.tbBitMap3.TabIndex = 20;
            this.tbBitMap3.Text = "nnnnnnnn";
            this.tbBitMap3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBitMap2
            // 
            this.tbBitMap2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbBitMap2.Location = new System.Drawing.Point(102, 5);
            this.tbBitMap2.Name = "tbBitMap2";
            this.tbBitMap2.ReadOnly = true;
            this.tbBitMap2.Size = new System.Drawing.Size(85, 22);
            this.tbBitMap2.TabIndex = 19;
            this.tbBitMap2.Text = "nnnnnnnn";
            this.tbBitMap2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel8.Location = new System.Drawing.Point(95, 20);
            this.panel8.Margin = new System.Windows.Forms.Padding(1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(3, 3);
            this.panel8.TabIndex = 12;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Location = new System.Drawing.Point(191, 20);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(3, 3);
            this.panel7.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.Location = new System.Drawing.Point(287, 20);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(3, 3);
            this.panel6.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(109, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bitmapa pre sub-siete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(109, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rozsah adries pre klientov";
            // 
            // tbRozsah
            // 
            this.tbRozsah.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbRozsah.Location = new System.Drawing.Point(18, 313);
            this.tbRozsah.Name = "tbRozsah";
            this.tbRozsah.ReadOnly = true;
            this.tbRozsah.Size = new System.Drawing.Size(386, 24);
            this.tbRozsah.TabIndex = 8;
            this.tbRozsah.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(212, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Poč. klientov na sub-sieť";
            // 
            // cbPocKlientov
            // 
            this.cbPocKlientov.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPocKlientov.FormattingEnabled = true;
            this.cbPocKlientov.Location = new System.Drawing.Point(245, 238);
            this.cbPocKlientov.Name = "cbPocKlientov";
            this.cbPocKlientov.Size = new System.Drawing.Size(159, 26);
            this.cbPocKlientov.TabIndex = 6;
            this.cbPocKlientov.SelectedIndexChanged += new System.EventHandler(this.cbPocKlientov_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(14, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Max. počet sub-sietí";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 680);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ip kalkulacka";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nuID4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuID3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuID2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuID1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nuID4;
        private System.Windows.Forms.NumericUpDown nuID3;
        private System.Windows.Forms.NumericUpDown nuID2;
        private System.Windows.Forms.NumericUpDown nuID1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbPocSieti;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRozsah;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPocKlientov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbBitMap1;
        private System.Windows.Forms.TextBox tbBitMap4;
        private System.Windows.Forms.TextBox tbBitMap3;
        private System.Windows.Forms.TextBox tbBitMap2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSubMaska;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbWildMaska;
    }
}

