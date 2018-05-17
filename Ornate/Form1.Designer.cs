namespace Ornate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCaptureNotes = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnTrainData = new System.Windows.Forms.Button();
            this.btnUploadDeficient = new System.Windows.Forms.Button();
            this.chckDeficient = new System.Windows.Forms.CheckBox();
            this.chckTrainData = new System.Windows.Forms.CheckBox();
            this.lstuatoSlides = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboMechanism = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecording = new System.Windows.Forms.Label();
            this.btnSpeech = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCaptureNotes
            // 
            this.btnCaptureNotes.FlatAppearance.BorderSize = 0;
            this.btnCaptureNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaptureNotes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaptureNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCaptureNotes.Image = ((System.Drawing.Image)(resources.GetObject("btnCaptureNotes.Image")));
            this.btnCaptureNotes.Location = new System.Drawing.Point(426, 115);
            this.btnCaptureNotes.Name = "btnCaptureNotes";
            this.btnCaptureNotes.Size = new System.Drawing.Size(128, 75);
            this.btnCaptureNotes.TabIndex = 1;
            this.btnCaptureNotes.Text = "Create Notes";
            this.btnCaptureNotes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCaptureNotes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCaptureNotes.UseVisualStyleBackColor = true;
            this.btnCaptureNotes.Click += new System.EventHandler(this.btnCaptureNotes_Click_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(961, 1);
            this.panel4.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(767, 34);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 150);
            this.textBox1.TabIndex = 9;
            // 
            // btnTrainData
            // 
            this.btnTrainData.ForeColor = System.Drawing.Color.Black;
            this.btnTrainData.Location = new System.Drawing.Point(24, 103);
            this.btnTrainData.Name = "btnTrainData";
            this.btnTrainData.Size = new System.Drawing.Size(162, 34);
            this.btnTrainData.TabIndex = 11;
            this.btnTrainData.Text = "Upload Train Data";
            this.btnTrainData.UseVisualStyleBackColor = true;
            this.btnTrainData.Click += new System.EventHandler(this.btnTrainData_Click);
            // 
            // btnUploadDeficient
            // 
            this.btnUploadDeficient.ForeColor = System.Drawing.Color.Black;
            this.btnUploadDeficient.Location = new System.Drawing.Point(198, 100);
            this.btnUploadDeficient.Name = "btnUploadDeficient";
            this.btnUploadDeficient.Size = new System.Drawing.Size(152, 37);
            this.btnUploadDeficient.TabIndex = 12;
            this.btnUploadDeficient.Text = "Upload Deficient";
            this.btnUploadDeficient.UseVisualStyleBackColor = true;
            this.btnUploadDeficient.Click += new System.EventHandler(this.btnUploadDeficient_Click);
            // 
            // chckDeficient
            // 
            this.chckDeficient.AutoCheck = false;
            this.chckDeficient.AutoSize = true;
            this.chckDeficient.ForeColor = System.Drawing.Color.White;
            this.chckDeficient.Location = new System.Drawing.Point(198, 138);
            this.chckDeficient.Name = "chckDeficient";
            this.chckDeficient.Size = new System.Drawing.Size(94, 24);
            this.chckDeficient.TabIndex = 13;
            this.chckDeficient.Text = "Deficient";
            this.chckDeficient.UseVisualStyleBackColor = true;
            // 
            // chckTrainData
            // 
            this.chckTrainData.AutoCheck = false;
            this.chckTrainData.AutoSize = true;
            this.chckTrainData.ForeColor = System.Drawing.Color.White;
            this.chckTrainData.Location = new System.Drawing.Point(24, 138);
            this.chckTrainData.Name = "chckTrainData";
            this.chckTrainData.Size = new System.Drawing.Size(100, 24);
            this.chckTrainData.TabIndex = 14;
            this.chckTrainData.Text = "Train Data";
            this.chckTrainData.UseVisualStyleBackColor = true;
            // 
            // lstuatoSlides
            // 
            this.lstuatoSlides.FormattingEnabled = true;
            this.lstuatoSlides.ItemHeight = 20;
            this.lstuatoSlides.Location = new System.Drawing.Point(724, 66);
            this.lstuatoSlides.Name = "lstuatoSlides";
            this.lstuatoSlides.Size = new System.Drawing.Size(163, 304);
            this.lstuatoSlides.TabIndex = 15;
            this.lstuatoSlides.SelectedIndexChanged += new System.EventHandler(this.lstuatoSlides_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRecording);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstuatoSlides);
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 383);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outputs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboMechanism);
            this.groupBox2.Controls.Add(this.chckTrainData);
            this.groupBox2.Controls.Add(this.btnUploadDeficient);
            this.groupBox2.Controls.Add(this.chckDeficient);
            this.groupBox2.Controls.Add(this.btnTrainData);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 168);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // comboMechanism
            // 
            this.comboMechanism.FormattingEnabled = true;
            this.comboMechanism.Items.AddRange(new object[] {
            "Microphone",
            "Deficient"});
            this.comboMechanism.Location = new System.Drawing.Point(219, 47);
            this.comboMechanism.Name = "comboMechanism";
            this.comboMechanism.Size = new System.Drawing.Size(121, 28);
            this.comboMechanism.TabIndex = 0;
            this.comboMechanism.SelectedIndexChanged += new System.EventHandler(this.comboMechanism_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generation Mechanism";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(24, 66);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(694, 304);
            this.webBrowser1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "View";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(727, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Auto Generated Notes";
            // 
            // lblRecording
            // 
            this.lblRecording.AutoSize = true;
            this.lblRecording.BackColor = System.Drawing.Color.Transparent;
            this.lblRecording.Font = new System.Drawing.Font("Moonbeam", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecording.ForeColor = System.Drawing.Color.White;
            this.lblRecording.Location = new System.Drawing.Point(303, -3);
            this.lblRecording.Name = "lblRecording";
            this.lblRecording.Size = new System.Drawing.Size(0, 116);
            this.lblRecording.TabIndex = 19;
            // 
            // btnSpeech
            // 
            this.btnSpeech.FlatAppearance.BorderSize = 0;
            this.btnSpeech.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeech.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpeech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSpeech.Image = ((System.Drawing.Image)(resources.GetObject("btnSpeech.Image")));
            this.btnSpeech.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSpeech.Location = new System.Drawing.Point(426, 22);
            this.btnSpeech.Name = "btnSpeech";
            this.btnSpeech.Size = new System.Drawing.Size(128, 75);
            this.btnSpeech.TabIndex = 19;
            this.btnSpeech.Text = "Speech Record";
            this.btnSpeech.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSpeech.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSpeech.UseVisualStyleBackColor = true;
            this.btnSpeech.Click += new System.EventHandler(this.btnSpeech_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(560, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 75);
            this.button1.TabIndex = 20;
            this.button1.Text = "Done Recording";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(961, 591);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSpeech);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnCaptureNotes);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Ornate";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCaptureNotes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnTrainData;
        private System.Windows.Forms.Button btnUploadDeficient;
        private System.Windows.Forms.CheckBox chckDeficient;
        private System.Windows.Forms.CheckBox chckTrainData;
        private System.Windows.Forms.ListBox lstuatoSlides;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboMechanism;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecording;
        private System.Windows.Forms.Button btnSpeech;
        private System.Windows.Forms.Button button1;
    }
}

