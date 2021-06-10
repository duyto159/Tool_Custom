namespace Tool_Custom
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
            this.btnDuy = new System.Windows.Forms.Button();
            this.btnShoppe = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDuy
            // 
            this.btnDuy.Location = new System.Drawing.Point(350, 12);
            this.btnDuy.Name = "btnDuy";
            this.btnDuy.Size = new System.Drawing.Size(120, 38);
            this.btnDuy.TabIndex = 0;
            this.btnDuy.Text = "Tiki";
            this.btnDuy.UseVisualStyleBackColor = true;
            this.btnDuy.Click += new System.EventHandler(this.btnDuy_Click);
            // 
            // btnShoppe
            // 
            this.btnShoppe.Location = new System.Drawing.Point(47, 12);
            this.btnShoppe.Name = "btnShoppe";
            this.btnShoppe.Size = new System.Drawing.Size(120, 38);
            this.btnShoppe.TabIndex = 0;
            this.btnShoppe.Text = "Shoppe";
            this.btnShoppe.UseVisualStyleBackColor = true;
            this.btnShoppe.Click += new System.EventHandler(this.btnShoppe_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 38);
            this.button2.TabIndex = 0;
            this.button2.Text = "Minh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnShoppe);
            this.Controls.Add(this.btnDuy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDuy;
        private System.Windows.Forms.Button btnShoppe;
        private System.Windows.Forms.Button button2;
    }
}

