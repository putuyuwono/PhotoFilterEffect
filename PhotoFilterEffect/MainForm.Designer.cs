namespace PhotoFilterEffect
{
    partial class MainForm
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
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.modifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.btEffect1 = new System.Windows.Forms.Button();
            this.btEffect2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btEffect3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarV = new System.Windows.Forms.TrackBar();
            this.trackBarS = new System.Windows.Forms.TrackBar();
            this.trackBarH = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.btEffect4 = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btEffect5 = new System.Windows.Forms.Button();
            this.btEffect6 = new System.Windows.Forms.Button();
            this.btMayfair = new System.Windows.Forms.Button();
            this.btAmaro = new System.Windows.Forms.Button();
            this.btHudson = new System.Windows.Forms.Button();
            this.btValencia = new System.Windows.Forms.Button();
            this.btXpro = new System.Windows.Forms.Button();
            this.btRise = new System.Windows.Forms.Button();
            this.btLofi = new System.Windows.Forms.Button();
            this.btWillow = new System.Windows.Forms.Button();
            this.btSierra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.Location = new System.Drawing.Point(0, 19);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(640, 480);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalPictureBox.TabIndex = 0;
            this.originalPictureBox.TabStop = false;
            // 
            // modifiedPictureBox
            // 
            this.modifiedPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.modifiedPictureBox.Location = new System.Drawing.Point(646, 19);
            this.modifiedPictureBox.Name = "modifiedPictureBox";
            this.modifiedPictureBox.Size = new System.Drawing.Size(640, 480);
            this.modifiedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.modifiedPictureBox.TabIndex = 1;
            this.modifiedPictureBox.TabStop = false;
            // 
            // btEffect1
            // 
            this.btEffect1.Location = new System.Drawing.Point(0, 506);
            this.btEffect1.Name = "btEffect1";
            this.btEffect1.Size = new System.Drawing.Size(75, 23);
            this.btEffect1.TabIndex = 2;
            this.btEffect1.Text = "BW";
            this.btEffect1.UseVisualStyleBackColor = true;
            this.btEffect1.Click += new System.EventHandler(this.btEffect1_Click);
            // 
            // btEffect2
            // 
            this.btEffect2.Location = new System.Drawing.Point(82, 506);
            this.btEffect2.Name = "btEffect2";
            this.btEffect2.Size = new System.Drawing.Size(75, 23);
            this.btEffect2.TabIndex = 3;
            this.btEffect2.Text = "Equal Hist";
            this.btEffect2.UseVisualStyleBackColor = true;
            this.btEffect2.Click += new System.EventHandler(this.btEffect2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Original Picture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Result Picture";
            // 
            // btEffect3
            // 
            this.btEffect3.Location = new System.Drawing.Point(0, 535);
            this.btEffect3.Name = "btEffect3";
            this.btEffect3.Size = new System.Drawing.Size(75, 23);
            this.btEffect3.TabIndex = 6;
            this.btEffect3.Text = "HSV";
            this.btEffect3.UseVisualStyleBackColor = true;
            this.btEffect3.Click += new System.EventHandler(this.btEffect3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackBarV);
            this.groupBox1.Controls.Add(this.trackBarS);
            this.groupBox1.Controls.Add(this.trackBarH);
            this.groupBox1.Location = new System.Drawing.Point(460, 506);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 170);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HSV Setting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Saturation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hue";
            // 
            // trackBarV
            // 
            this.trackBarV.Location = new System.Drawing.Point(68, 119);
            this.trackBarV.Maximum = 255;
            this.trackBarV.Name = "trackBarV";
            this.trackBarV.Size = new System.Drawing.Size(336, 45);
            this.trackBarV.SmallChange = 10;
            this.trackBarV.TabIndex = 2;
            this.trackBarV.TickFrequency = 5;
            this.trackBarV.Scroll += new System.EventHandler(this.trackBarV_Scroll);
            // 
            // trackBarS
            // 
            this.trackBarS.Location = new System.Drawing.Point(68, 70);
            this.trackBarS.Maximum = 255;
            this.trackBarS.Name = "trackBarS";
            this.trackBarS.Size = new System.Drawing.Size(336, 45);
            this.trackBarS.SmallChange = 10;
            this.trackBarS.TabIndex = 1;
            this.trackBarS.TickFrequency = 5;
            this.trackBarS.Scroll += new System.EventHandler(this.trackBarS_Scroll);
            // 
            // trackBarH
            // 
            this.trackBarH.Location = new System.Drawing.Point(68, 19);
            this.trackBarH.Maximum = 180;
            this.trackBarH.Name = "trackBarH";
            this.trackBarH.Size = new System.Drawing.Size(336, 45);
            this.trackBarH.SmallChange = 10;
            this.trackBarH.TabIndex = 0;
            this.trackBarH.TickFrequency = 5;
            this.trackBarH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarH_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.trackBar2);
            this.groupBox2.Controls.Add(this.trackBar3);
            this.groupBox2.Location = new System.Drawing.Point(876, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 170);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RGB Setting";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Blue";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Green";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Red";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(68, 119);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(336, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 5;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(68, 70);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(336, 45);
            this.trackBar2.SmallChange = 10;
            this.trackBar2.TabIndex = 1;
            this.trackBar2.TickFrequency = 5;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(68, 19);
            this.trackBar3.Maximum = 255;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(336, 45);
            this.trackBar3.SmallChange = 10;
            this.trackBar3.TabIndex = 0;
            this.trackBar3.TickFrequency = 5;
            // 
            // btEffect4
            // 
            this.btEffect4.Location = new System.Drawing.Point(82, 535);
            this.btEffect4.Name = "btEffect4";
            this.btEffect4.Size = new System.Drawing.Size(75, 23);
            this.btEffect4.TabIndex = 9;
            this.btEffect4.Text = "Gingham";
            this.btEffect4.UseVisualStyleBackColor = true;
            this.btEffect4.Click += new System.EventHandler(this.btEffect4_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(-3, 578);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(28, 13);
            this.lblInfo.TabIndex = 10;
            this.lblInfo.Text = "Info:";
            // 
            // btEffect5
            // 
            this.btEffect5.Location = new System.Drawing.Point(82, 568);
            this.btEffect5.Name = "btEffect5";
            this.btEffect5.Size = new System.Drawing.Size(75, 23);
            this.btEffect5.TabIndex = 11;
            this.btEffect5.Text = "Clarendon";
            this.btEffect5.UseVisualStyleBackColor = true;
            this.btEffect5.Click += new System.EventHandler(this.btEffect5_Click);
            // 
            // btEffect6
            // 
            this.btEffect6.Location = new System.Drawing.Point(82, 597);
            this.btEffect6.Name = "btEffect6";
            this.btEffect6.Size = new System.Drawing.Size(75, 23);
            this.btEffect6.TabIndex = 12;
            this.btEffect6.Text = "Lark";
            this.btEffect6.UseVisualStyleBackColor = true;
            this.btEffect6.Click += new System.EventHandler(this.btEffect6_Click);
            // 
            // btMayfair
            // 
            this.btMayfair.Location = new System.Drawing.Point(82, 652);
            this.btMayfair.Name = "btMayfair";
            this.btMayfair.Size = new System.Drawing.Size(75, 23);
            this.btMayfair.TabIndex = 13;
            this.btMayfair.Text = "Mayfair";
            this.btMayfair.UseVisualStyleBackColor = true;
            this.btMayfair.Click += new System.EventHandler(this.btMayfair_Click);
            // 
            // btAmaro
            // 
            this.btAmaro.Location = new System.Drawing.Point(82, 623);
            this.btAmaro.Name = "btAmaro";
            this.btAmaro.Size = new System.Drawing.Size(75, 23);
            this.btAmaro.TabIndex = 14;
            this.btAmaro.Text = "Amaro";
            this.btAmaro.UseVisualStyleBackColor = true;
            this.btAmaro.Click += new System.EventHandler(this.btAmaro_Click);
            // 
            // btHudson
            // 
            this.btHudson.Location = new System.Drawing.Point(82, 681);
            this.btHudson.Name = "btHudson";
            this.btHudson.Size = new System.Drawing.Size(75, 23);
            this.btHudson.TabIndex = 15;
            this.btHudson.Text = "Hudson";
            this.btHudson.UseVisualStyleBackColor = true;
            this.btHudson.Click += new System.EventHandler(this.btHudson_Click);
            // 
            // btValencia
            // 
            this.btValencia.Location = new System.Drawing.Point(163, 505);
            this.btValencia.Name = "btValencia";
            this.btValencia.Size = new System.Drawing.Size(75, 23);
            this.btValencia.TabIndex = 16;
            this.btValencia.Text = "Valencia";
            this.btValencia.UseVisualStyleBackColor = true;
            this.btValencia.Click += new System.EventHandler(this.btValencia_Click);
            // 
            // btXpro
            // 
            this.btXpro.Location = new System.Drawing.Point(163, 535);
            this.btXpro.Name = "btXpro";
            this.btXpro.Size = new System.Drawing.Size(75, 23);
            this.btXpro.TabIndex = 17;
            this.btXpro.Text = "X-PRO II";
            this.btXpro.UseVisualStyleBackColor = true;
            this.btXpro.Click += new System.EventHandler(this.btXpro_Click);
            // 
            // btRise
            // 
            this.btRise.Location = new System.Drawing.Point(163, 655);
            this.btRise.Name = "btRise";
            this.btRise.Size = new System.Drawing.Size(75, 23);
            this.btRise.TabIndex = 18;
            this.btRise.Text = "Rise";
            this.btRise.UseVisualStyleBackColor = true;
            this.btRise.Click += new System.EventHandler(this.btRise_Click);
            // 
            // btLofi
            // 
            this.btLofi.Location = new System.Drawing.Point(163, 626);
            this.btLofi.Name = "btLofi";
            this.btLofi.Size = new System.Drawing.Size(75, 23);
            this.btLofi.TabIndex = 19;
            this.btLofi.Text = "Lo-Fi";
            this.btLofi.UseVisualStyleBackColor = true;
            this.btLofi.Click += new System.EventHandler(this.btLofi_Click);
            // 
            // btWillow
            // 
            this.btWillow.Location = new System.Drawing.Point(163, 597);
            this.btWillow.Name = "btWillow";
            this.btWillow.Size = new System.Drawing.Size(75, 23);
            this.btWillow.TabIndex = 20;
            this.btWillow.Text = "Willow";
            this.btWillow.UseVisualStyleBackColor = true;
            this.btWillow.Click += new System.EventHandler(this.btWillow_Click);
            // 
            // btSierra
            // 
            this.btSierra.Location = new System.Drawing.Point(163, 568);
            this.btSierra.Name = "btSierra";
            this.btSierra.Size = new System.Drawing.Size(75, 23);
            this.btSierra.TabIndex = 21;
            this.btSierra.Text = "Sierra";
            this.btSierra.UseVisualStyleBackColor = true;
            this.btSierra.Click += new System.EventHandler(this.btSierra_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 707);
            this.Controls.Add(this.btSierra);
            this.Controls.Add(this.btWillow);
            this.Controls.Add(this.btLofi);
            this.Controls.Add(this.btRise);
            this.Controls.Add(this.btXpro);
            this.Controls.Add(this.btValencia);
            this.Controls.Add(this.btHudson);
            this.Controls.Add(this.btAmaro);
            this.Controls.Add(this.btMayfair);
            this.Controls.Add(this.btEffect6);
            this.Controls.Add(this.btEffect5);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btEffect4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btEffect3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btEffect2);
            this.Controls.Add(this.btEffect1);
            this.Controls.Add(this.modifiedPictureBox);
            this.Controls.Add(this.originalPictureBox);
            this.Name = "MainForm";
            this.Text = "Photo Filter Effect";
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarH)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.PictureBox modifiedPictureBox;
        private System.Windows.Forms.Button btEffect1;
        private System.Windows.Forms.Button btEffect2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btEffect3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarV;
        private System.Windows.Forms.TrackBar trackBarS;
        private System.Windows.Forms.TrackBar trackBarH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Button btEffect4;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btEffect5;
        private System.Windows.Forms.Button btEffect6;
        private System.Windows.Forms.Button btMayfair;
        private System.Windows.Forms.Button btAmaro;
        private System.Windows.Forms.Button btHudson;
        private System.Windows.Forms.Button btValencia;
        private System.Windows.Forms.Button btXpro;
        private System.Windows.Forms.Button btRise;
        private System.Windows.Forms.Button btLofi;
        private System.Windows.Forms.Button btWillow;
        private System.Windows.Forms.Button btSierra;
    }
}

