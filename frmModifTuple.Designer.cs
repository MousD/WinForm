namespace WindowsFormsApplication1
{
    partial class frmModifTuple
    {
        private string _text_modif;

        public string Text_modif
        {
            get { return _text_modif; }
            set { _text_modif = value; }
        }


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
            this.txtModif = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtModif
            // 
            this.txtModif.Location = new System.Drawing.Point(12, 19);
            this.txtModif.Name = "txtModif";
            this.txtModif.Size = new System.Drawing.Size(134, 20);
            this.txtModif.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close me";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmModifTuple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 114);
            this.Controls.Add(this.txtModif);
            this.Controls.Add(this.button1);
            this.Name = "frmModifTuple";
            this.Text = "frmModifTuple";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModifTuple_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtModif;
        private System.Windows.Forms.Button button1;
    }
}