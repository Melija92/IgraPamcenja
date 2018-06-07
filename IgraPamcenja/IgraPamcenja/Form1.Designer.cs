namespace IgraPamcenja
{
    partial class PocetniPodaci
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
            this.ime = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UnestiVrijeme = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ime
            // 
            this.ime.AutoSize = true;
            this.ime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ime.Location = new System.Drawing.Point(60, 50);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(104, 25);
            this.ime.TabIndex = 0;
            this.ime.Text = "Unesi ime:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 22);
            this.textBox1.TabIndex = 1;
            // 
            // UnestiVrijeme
            // 
            this.UnestiVrijeme.AutoSize = true;
            this.UnestiVrijeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnestiVrijeme.Location = new System.Drawing.Point(60, 144);
            this.UnestiVrijeme.Name = "UnestiVrijeme";
            this.UnestiVrijeme.Size = new System.Drawing.Size(172, 25);
            this.UnestiVrijeme.TabIndex = 2;
            this.UnestiVrijeme.Text = "Unesi vrijeme igre:";
            // 
            // PocetniPodaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 285);
            this.Controls.Add(this.UnestiVrijeme);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ime);
            this.Name = "PocetniPodaci";
            this.Text = "Početni podaci";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ime;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label UnestiVrijeme;
    }
}