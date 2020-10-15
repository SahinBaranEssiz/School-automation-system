namespace Bitirme_Tezi
{
    partial class ayarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ayarlar));
            this.labelvadi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtVeriAdi = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelvadi
            // 
            this.labelvadi.AutoSize = true;
            this.labelvadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelvadi.Location = new System.Drawing.Point(12, 49);
            this.labelvadi.Name = "labelvadi";
            this.labelvadi.Size = new System.Drawing.Size(151, 20);
            this.labelvadi.TabIndex = 0;
            this.labelvadi.Text = "Sunucu Adını Giriniz";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kapat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtVeriAdi
            // 
            this.txtVeriAdi.AllowDrop = true;
            this.txtVeriAdi.Location = new System.Drawing.Point(207, 49);
            this.txtVeriAdi.Name = "txtVeriAdi";
            this.txtVeriAdi.Size = new System.Drawing.Size(253, 20);
            this.txtVeriAdi.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(207, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Kaydet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 224);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtVeriAdi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelvadi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ayarlar";
            this.Text = "ayarlar";
            this.Load += new System.EventHandler(this.ayarlar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelvadi;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtVeriAdi;
        public System.Windows.Forms.Button button2;
    }
}