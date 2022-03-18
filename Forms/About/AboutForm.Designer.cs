namespace CoursePaper
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.captionLabel = new System.Windows.Forms.Label();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.slideShowBox = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.slideShowBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.Location = new System.Drawing.Point(12, 9);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(218, 29);
            this.captionLabel.TabIndex = 0;
            this.captionLabel.Text = "Հեղինակի մասին";
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(14, 65);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(52, 13);
            this.aboutLabel.TabIndex = 1;
            this.aboutLabel.Text = "About me";
            // 
            // slideShowBox
            // 
            this.slideShowBox.Image = ((System.Drawing.Image)(resources.GetObject("slideShowBox.Image")));
            this.slideShowBox.Location = new System.Drawing.Point(316, 65);
            this.slideShowBox.Name = "slideShowBox";
            this.slideShowBox.Size = new System.Drawing.Size(211, 199);
            this.slideShowBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.slideShowBox.TabIndex = 2;
            this.slideShowBox.TabStop = false;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(455, 319);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(72, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Փակել";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 354);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.slideShowBox);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.captionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Text = "Հեղինակ";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slideShowBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.PictureBox slideShowBox;
        private System.Windows.Forms.Button closeButton;
    }
}