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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.UploadImageBtn = new System.Windows.Forms.Button();
            this.generationLbl = new System.Windows.Forms.Label();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.maxScoreLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(33, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 265);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PaintBtn
            // 
            this.PaintBtn.Location = new System.Drawing.Point(497, 390);
            this.PaintBtn.Margin = new System.Windows.Forms.Padding(2);
            this.PaintBtn.Name = "PaintBtn";
            this.PaintBtn.Size = new System.Drawing.Size(72, 22);
            this.PaintBtn.TabIndex = 1;
            this.PaintBtn.Text = "Paint";
            this.PaintBtn.UseVisualStyleBackColor = true;
            this.PaintBtn.Click += new System.EventHandler(this.AIPaint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(721, 8);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(303, 265);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // UploadImageBtn
            // 
            this.UploadImageBtn.Location = new System.Drawing.Point(125, 390);
            this.UploadImageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UploadImageBtn.Name = "UploadImageBtn";
            this.UploadImageBtn.Size = new System.Drawing.Size(102, 22);
            this.UploadImageBtn.TabIndex = 3;
            this.UploadImageBtn.Text = "Upload Image";
            this.UploadImageBtn.UseVisualStyleBackColor = true;
            this.UploadImageBtn.Click += new System.EventHandler(this.UploadImage);
            // 
            // generationLbl
            // 
            this.generationLbl.AutoSize = true;
            this.generationLbl.Location = new System.Drawing.Point(494, 82);
            this.generationLbl.Name = "generationLbl";
            this.generationLbl.Size = new System.Drawing.Size(59, 13);
            this.generationLbl.TabIndex = 4;
            this.generationLbl.Text = "Generation";
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.Location = new System.Drawing.Point(494, 122);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(35, 13);
            this.ScoreLbl.TabIndex = 5;
            this.ScoreLbl.Text = "Score";
            // 
            // maxScoreLbl
            // 
            this.maxScoreLbl.AutoSize = true;
            this.maxScoreLbl.Location = new System.Drawing.Point(497, 167);
            this.maxScoreLbl.Name = "maxScoreLbl";
            this.maxScoreLbl.Size = new System.Drawing.Size(55, 13);
            this.maxScoreLbl.TabIndex = 6;
            this.maxScoreLbl.Text = "MaxScore";
            // 
            // Painter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 435);
            this.Controls.Add(this.maxScoreLbl);
            this.Controls.Add(this.ScoreLbl);
            this.Controls.Add(this.generationLbl);
            this.Controls.Add(this.UploadImageBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PaintBtn);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Painter";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PaintBtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button UploadImageBtn;
        private System.Windows.Forms.Label generationLbl;
        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.Label maxScoreLbl;
    }
}

