namespace CoursePaper
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.infoLabel = new System.Windows.Forms.Label();
            this.closeHelpFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(35, 13);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "label1";
            // 
            // closeHelpFormButton
            // 
            this.closeHelpFormButton.Location = new System.Drawing.Point(116, 324);
            this.closeHelpFormButton.Name = "closeHelpFormButton";
            this.closeHelpFormButton.Size = new System.Drawing.Size(75, 23);
            this.closeHelpFormButton.TabIndex = 1;
            this.closeHelpFormButton.Text = "Փակել";
            this.closeHelpFormButton.UseVisualStyleBackColor = true;
            this.closeHelpFormButton.Click += new System.EventHandler(this.closeHelpFormButton_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 359);
            this.Controls.Add(this.closeHelpFormButton);
            this.Controls.Add(this.infoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HelpForm";
            this.Text = "Օգնություն";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button closeHelpFormButton;
    }
}