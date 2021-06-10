namespace Tool_Custom
{
    partial class frmTiki
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
            this.btnGet = new System.Windows.Forms.Button();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.rtbData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(622, 55);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(109, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(80, 55);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(511, 20);
            this.txtLink.TabIndex = 1;
            // 
            // rtbData
            // 
            this.rtbData.Location = new System.Drawing.Point(12, 123);
            this.rtbData.Name = "rtbData";
            this.rtbData.Size = new System.Drawing.Size(765, 300);
            this.rtbData.TabIndex = 2;
            this.rtbData.Text = "";
            // 
            // frmTiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbData);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.btnGet);
            this.Name = "frmTiki";
            this.Text = "frmTiki";
            this.Load += new System.EventHandler(this.frmTiki_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.RichTextBox rtbData;
    }
}