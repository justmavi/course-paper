namespace CoursePaper
{
    partial class TipsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipsForm));
            this.tipsRichBox = new System.Windows.Forms.RichTextBox();
            this.captionLabel = new System.Windows.Forms.Label();
            this.nextTipButton = new System.Windows.Forms.Button();
            this.prevTipButton = new System.Windows.Forms.Button();
            this.lastTipButton = new System.Windows.Forms.Button();
            this.firstTipButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tipsRichBox
            // 
            this.tipsRichBox.Location = new System.Drawing.Point(14, 87);
            this.tipsRichBox.Name = "tipsRichBox";
            this.tipsRichBox.ReadOnly = true;
            this.tipsRichBox.Size = new System.Drawing.Size(268, 205);
            this.tipsRichBox.TabIndex = 0;
            this.tipsRichBox.Text = "";
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.captionLabel.Location = new System.Drawing.Point(9, 23);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(139, 29);
            this.captionLabel.TabIndex = 1;
            this.captionLabel.Text = "Վերնագիր";
            // 
            // nextTipButton
            // 
            this.nextTipButton.Location = new System.Drawing.Point(307, 87);
            this.nextTipButton.Name = "nextTipButton";
            this.nextTipButton.Size = new System.Drawing.Size(132, 23);
            this.nextTipButton.TabIndex = 2;
            this.nextTipButton.Text = "Հաջորդ խորհուրդը";
            this.nextTipButton.UseVisualStyleBackColor = true;
            this.nextTipButton.Click += new System.EventHandler(this.nextTipButton_Click);
            // 
            // prevTipButton
            // 
            this.prevTipButton.Location = new System.Drawing.Point(307, 116);
            this.prevTipButton.Name = "prevTipButton";
            this.prevTipButton.Size = new System.Drawing.Size(132, 23);
            this.prevTipButton.TabIndex = 3;
            this.prevTipButton.Text = "Նախորդ խորհուրդը";
            this.prevTipButton.UseVisualStyleBackColor = true;
            this.prevTipButton.Click += new System.EventHandler(this.prevTipButton_Click);
            // 
            // lastTipButton
            // 
            this.lastTipButton.Location = new System.Drawing.Point(307, 207);
            this.lastTipButton.Name = "lastTipButton";
            this.lastTipButton.Size = new System.Drawing.Size(132, 23);
            this.lastTipButton.TabIndex = 5;
            this.lastTipButton.Text = "Վերջին խորհուրդը";
            this.lastTipButton.UseVisualStyleBackColor = true;
            this.lastTipButton.Click += new System.EventHandler(this.lastTipButton_Click);
            // 
            // firstTipButton
            // 
            this.firstTipButton.Location = new System.Drawing.Point(307, 178);
            this.firstTipButton.Name = "firstTipButton";
            this.firstTipButton.Size = new System.Drawing.Size(132, 23);
            this.firstTipButton.TabIndex = 4;
            this.firstTipButton.Text = "Առաջին խորհուրդը";
            this.firstTipButton.UseVisualStyleBackColor = true;
            this.firstTipButton.Click += new System.EventHandler(this.firstTipButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(307, 269);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(132, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Փակել";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // TipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 350);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.lastTipButton);
            this.Controls.Add(this.firstTipButton);
            this.Controls.Add(this.prevTipButton);
            this.Controls.Add(this.nextTipButton);
            this.Controls.Add(this.captionLabel);
            this.Controls.Add(this.tipsRichBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TipsForm";
            this.Text = "Օրվա խորհուրդներ";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button nextTipButton;
        private System.Windows.Forms.Button prevTipButton;
        private System.Windows.Forms.Button lastTipButton;
        private System.Windows.Forms.Button firstTipButton;
        private System.Windows.Forms.Button closeButton;
        internal System.Windows.Forms.RichTextBox tipsRichBox;
        internal System.Windows.Forms.Label captionLabel;
    }
}