namespace AIPainter
{
    partial class Painter
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PaintBtn = new System.Windows.Forms.Button();
            this.UploadImageBtn = new System.Windows.Forms.Button();
            this.generationLbl = new System.Windows.Forms.Label();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.completionRateLbl = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 180);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PaintBtn
            // 
            this.PaintBtn.Location = new System.Drawing.Point(651, 392);
            this.PaintBtn.Name = "PaintBtn";
            this.PaintBtn.Size = new System.Drawing.Size(108, 34);
            this.PaintBtn.TabIndex = 1;
            this.PaintBtn.Text = "Paint";
            this.PaintBtn.UseVisualStyleBackColor = true;
            this.PaintBtn.Click += new System.EventHandler(this.AIPaint);
            // 
            // UploadImageBtn
            // 
            this.UploadImageBtn.Location = new System.Drawing.Point(315, 80);
            this.UploadImageBtn.Name = "UploadImageBtn";
            this.UploadImageBtn.Size = new System.Drawing.Size(153, 34);
            this.UploadImageBtn.TabIndex = 3;
            this.UploadImageBtn.Text = "Upload Image";
            this.UploadImageBtn.UseVisualStyleBackColor = true;
            this.UploadImageBtn.Click += new System.EventHandler(this.UploadImage);
            // 
            // generationLbl
            // 
            this.generationLbl.AutoSize = true;
            this.generationLbl.Location = new System.Drawing.Point(311, 368);
            this.generationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.generationLbl.Name = "generationLbl";
            this.generationLbl.Size = new System.Drawing.Size(89, 20);
            this.generationLbl.TabIndex = 4;
            this.generationLbl.Text = "Generation";
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.Location = new System.Drawing.Point(311, 275);
            this.ScoreLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(51, 20);
            this.ScoreLbl.TabIndex = 5;
            this.ScoreLbl.Text = "Score";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(50, 246);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(211, 180);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // completionRateLbl
            // 
            this.completionRateLbl.AutoSize = true;
            this.completionRateLbl.Location = new System.Drawing.Point(311, 317);
            this.completionRateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.completionRateLbl.Name = "completionRateLbl";
            this.completionRateLbl.Size = new System.Drawing.Size(128, 20);
            this.completionRateLbl.TabIndex = 10;
            this.completionRateLbl.Text = "Completion Rate";
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(637, 80);
            this.timeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(43, 20);
            this.timeLbl.TabIndex = 11;
            this.timeLbl.Text = "Time";
            // 
            // Painter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 477);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.completionRateLbl);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.generationLbl);
            this.Controls.Add(this.UploadImageBtn);
            this.Controls.Add(this.PaintBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Painter";
            this.Text = "AI Painter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PaintBtn;
        private System.Windows.Forms.Button UploadImageBtn;
        private System.Windows.Forms.Label generationLbl;
        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label completionRateLbl;
        private System.Windows.Forms.Label timeLbl;
    }
}

