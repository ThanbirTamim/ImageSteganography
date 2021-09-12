
namespace ImageSteganographyThesisProject
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
            this.lblTxtCount = new System.Windows.Forms.Label();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMeaturement = new System.Windows.Forms.RichTextBox();
            this.txtSecretMessage = new System.Windows.Forms.RichTextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowseCoverImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioAlgo1 = new System.Windows.Forms.RadioButton();
            this.radioAlgo2 = new System.Windows.Forms.RadioButton();
            this.radioAlgo3 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTxtCount
            // 
            this.lblTxtCount.AutoSize = true;
            this.lblTxtCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTxtCount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtCount.Location = new System.Drawing.Point(23, 259);
            this.lblTxtCount.Name = "lblTxtCount";
            this.lblTxtCount.Size = new System.Drawing.Size(122, 21);
            this.lblTxtCount.TabIndex = 22;
            this.lblTxtCount.Text = "Letter Count: 0";
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(366, 262);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(86, 30);
            this.btnHide.TabIndex = 21;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.BackColor = System.Drawing.Color.Thistle;
            this.btnExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtract.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtract.Location = new System.Drawing.Point(274, 262);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(86, 30);
            this.btnExtract.TabIndex = 20;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = false;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(467, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Meaturement Metrix ";
            // 
            // txtMeaturement
            // 
            this.txtMeaturement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMeaturement.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeaturement.Location = new System.Drawing.Point(12, 332);
            this.txtMeaturement.Name = "txtMeaturement";
            this.txtMeaturement.ReadOnly = true;
            this.txtMeaturement.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMeaturement.Size = new System.Drawing.Size(619, 89);
            this.txtMeaturement.TabIndex = 18;
            this.txtMeaturement.Text = "";
            // 
            // txtSecretMessage
            // 
            this.txtSecretMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecretMessage.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecretMessage.Location = new System.Drawing.Point(182, 43);
            this.txtSecretMessage.Name = "txtSecretMessage";
            this.txtSecretMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSecretMessage.Size = new System.Drawing.Size(270, 213);
            this.txtSecretMessage.TabIndex = 17;
            this.txtSecretMessage.Text = "";
            this.txtSecretMessage.TextChanged += new System.EventHandler(this.txtSecretMessage_TextChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(12, 12);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(519, 25);
            this.txtFileName.TabIndex = 16;
            // 
            // btnBrowseCoverImage
            // 
            this.btnBrowseCoverImage.BackColor = System.Drawing.Color.OldLace;
            this.btnBrowseCoverImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseCoverImage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseCoverImage.Location = new System.Drawing.Point(537, 9);
            this.btnBrowseCoverImage.Name = "btnBrowseCoverImage";
            this.btnBrowseCoverImage.Size = new System.Drawing.Size(98, 28);
            this.btnBrowseCoverImage.TabIndex = 15;
            this.btnBrowseCoverImage.Text = "Browse";
            this.btnBrowseCoverImage.UseVisualStyleBackColor = false;
            this.btnBrowseCoverImage.Click += new System.EventHandler(this.btnBrowseCoverImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(71, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "Max Letter: 0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(71, 154);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 102);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Cover";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Stego";
            // 
            // radioAlgo1
            // 
            this.radioAlgo1.AutoSize = true;
            this.radioAlgo1.Checked = true;
            this.radioAlgo1.Location = new System.Drawing.Point(458, 45);
            this.radioAlgo1.Name = "radioAlgo1";
            this.radioAlgo1.Size = new System.Drawing.Size(124, 17);
            this.radioAlgo1.TabIndex = 29;
            this.radioAlgo1.TabStop = true;
            this.radioAlgo1.Text = "Proposed Technique";
            this.radioAlgo1.UseVisualStyleBackColor = true;
            // 
            // radioAlgo2
            // 
            this.radioAlgo2.AutoSize = true;
            this.radioAlgo2.Location = new System.Drawing.Point(458, 68);
            this.radioAlgo2.Name = "radioAlgo2";
            this.radioAlgo2.Size = new System.Drawing.Size(179, 17);
            this.radioAlgo2.TabIndex = 30;
            this.radioAlgo2.TabStop = true;
            this.radioAlgo2.Text = "8 Dir Based Technique with LSB";
            this.radioAlgo2.UseVisualStyleBackColor = true;
            // 
            // radioAlgo3
            // 
            this.radioAlgo3.AutoSize = true;
            this.radioAlgo3.Location = new System.Drawing.Point(458, 93);
            this.radioAlgo3.Name = "radioAlgo3";
            this.radioAlgo3.Size = new System.Drawing.Size(173, 17);
            this.radioAlgo3.TabIndex = 31;
            this.radioAlgo3.TabStop = true;
            this.radioAlgo3.Text = "Xor Based Technique with LSB";
            this.radioAlgo3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 428);
            this.Controls.Add(this.radioAlgo3);
            this.Controls.Add(this.radioAlgo2);
            this.Controls.Add(this.radioAlgo1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTxtCount);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMeaturement);
            this.Controls.Add(this.txtSecretMessage);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnBrowseCoverImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageSteganography";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTxtCount;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtMeaturement;
        private System.Windows.Forms.RichTextBox txtSecretMessage;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrowseCoverImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioAlgo1;
        private System.Windows.Forms.RadioButton radioAlgo2;
        private System.Windows.Forms.RadioButton radioAlgo3;
    }
}

