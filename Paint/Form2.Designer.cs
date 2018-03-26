namespace Paint
{
    partial class Form2
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
            this.AlphaTrack = new System.Windows.Forms.TrackBar();
            this.BlueTrack = new System.Windows.Forms.TrackBar();
            this.GreenTrack = new System.Windows.Forms.TrackBar();
            this.RedTrack = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RedUpDown = new System.Windows.Forms.NumericUpDown();
            this.GreenUpDown = new System.Windows.Forms.NumericUpDown();
            this.BlueUpDown = new System.Windows.Forms.NumericUpDown();
            this.AlphaUpDown = new System.Windows.Forms.NumericUpDown();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.colors = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colors)).BeginInit();
            this.SuspendLayout();
            // 
            // AlphaTrack
            // 
            this.AlphaTrack.Location = new System.Drawing.Point(31, 327);
            this.AlphaTrack.Maximum = 255;
            this.AlphaTrack.Name = "AlphaTrack";
            this.AlphaTrack.Size = new System.Drawing.Size(322, 56);
            this.AlphaTrack.TabIndex = 1;
            this.AlphaTrack.Scroll += new System.EventHandler(this.AlphaTrack_Scroll);
            this.AlphaTrack.ValueChanged += new System.EventHandler(this.BlueTrack_ValueChanged);
            // 
            // BlueTrack
            // 
            this.BlueTrack.Location = new System.Drawing.Point(404, 186);
            this.BlueTrack.Maximum = 255;
            this.BlueTrack.Name = "BlueTrack";
            this.BlueTrack.Size = new System.Drawing.Size(288, 56);
            this.BlueTrack.TabIndex = 2;
            this.BlueTrack.ValueChanged += new System.EventHandler(this.BlueTrack_ValueChanged);
            // 
            // GreenTrack
            // 
            this.GreenTrack.Location = new System.Drawing.Point(404, 97);
            this.GreenTrack.Maximum = 255;
            this.GreenTrack.Name = "GreenTrack";
            this.GreenTrack.Size = new System.Drawing.Size(288, 56);
            this.GreenTrack.TabIndex = 3;
            this.GreenTrack.Scroll += new System.EventHandler(this.GreenTrack_Scroll);
            this.GreenTrack.ValueChanged += new System.EventHandler(this.BlueTrack_ValueChanged);
            // 
            // RedTrack
            // 
            this.RedTrack.Location = new System.Drawing.Point(403, 12);
            this.RedTrack.Maximum = 255;
            this.RedTrack.Name = "RedTrack";
            this.RedTrack.Size = new System.Drawing.Size(288, 56);
            this.RedTrack.TabIndex = 4;
            this.RedTrack.Scroll += new System.EventHandler(this.RedTrack_Scroll);
            this.RedTrack.ValueChanged += new System.EventHandler(this.BlueTrack_ValueChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button1.Location = new System.Drawing.Point(403, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button2.Location = new System.Drawing.Point(594, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(360, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "R:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(359, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "G:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(360, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "B:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(-2, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 29);
            this.label4.TabIndex = 11;
            this.label4.Text = "A:";
            // 
            // RedUpDown
            // 
            this.RedUpDown.Location = new System.Drawing.Point(697, 18);
            this.RedUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedUpDown.Name = "RedUpDown";
            this.RedUpDown.Size = new System.Drawing.Size(50, 22);
            this.RedUpDown.TabIndex = 12;
            this.RedUpDown.ValueChanged += new System.EventHandler(this.RedUpDown_ValueChanged);
            // 
            // GreenUpDown
            // 
            this.GreenUpDown.Location = new System.Drawing.Point(697, 97);
            this.GreenUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenUpDown.Name = "GreenUpDown";
            this.GreenUpDown.Size = new System.Drawing.Size(50, 22);
            this.GreenUpDown.TabIndex = 13;
            this.GreenUpDown.ValueChanged += new System.EventHandler(this.GreenUpDown_ValueChanged);
            // 
            // BlueUpDown
            // 
            this.BlueUpDown.Location = new System.Drawing.Point(697, 186);
            this.BlueUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueUpDown.Name = "BlueUpDown";
            this.BlueUpDown.Size = new System.Drawing.Size(50, 22);
            this.BlueUpDown.TabIndex = 14;
            this.BlueUpDown.ValueChanged += new System.EventHandler(this.BlueUpDown_ValueChanged);
            // 
            // AlphaUpDown
            // 
            this.AlphaUpDown.Location = new System.Drawing.Point(155, 361);
            this.AlphaUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AlphaUpDown.Name = "AlphaUpDown";
            this.AlphaUpDown.Size = new System.Drawing.Size(50, 22);
            this.AlphaUpDown.TabIndex = 15;
            this.AlphaUpDown.ValueChanged += new System.EventHandler(this.AlphaUpDown_ValueChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(403, 248);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(313, 86);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // colors
            // 
            this.colors.BackColor = System.Drawing.Color.White;
            this.colors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colors.Image = global::Paint.Properties.Resources.colors;
            this.colors.Location = new System.Drawing.Point(31, 10);
            this.colors.Name = "colors";
            this.colors.Size = new System.Drawing.Size(322, 311);
            this.colors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.colors.TabIndex = 0;
            this.colors.TabStop = false;
            this.colors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colors_MouseDown);
            this.colors.MouseLeave += new System.EventHandler(this.colors_MouseLeave);
            this.colors.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colors_MouseMove);
            this.colors.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colors_MouseUp);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 396);
            this.Controls.Add(this.AlphaUpDown);
            this.Controls.Add(this.BlueUpDown);
            this.Controls.Add(this.GreenUpDown);
            this.Controls.Add(this.RedUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.RedTrack);
            this.Controls.Add(this.GreenTrack);
            this.Controls.Add(this.BlueTrack);
            this.Controls.Add(this.AlphaTrack);
            this.Controls.Add(this.colors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AlphaTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox colors;
        private System.Windows.Forms.TrackBar AlphaTrack;
        private System.Windows.Forms.TrackBar BlueTrack;
        private System.Windows.Forms.TrackBar GreenTrack;
        private System.Windows.Forms.TrackBar RedTrack;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RedUpDown;
        private System.Windows.Forms.NumericUpDown GreenUpDown;
        private System.Windows.Forms.NumericUpDown BlueUpDown;
        private System.Windows.Forms.NumericUpDown AlphaUpDown;
    }
}