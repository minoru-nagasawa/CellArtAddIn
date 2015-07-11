namespace CellArtAddIn
{
    partial class ProgressBarDialog
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
            this.c_progressBar = new System.Windows.Forms.ProgressBar();
            this.c_btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // c_progressBar
            // 
            this.c_progressBar.Location = new System.Drawing.Point(13, 13);
            this.c_progressBar.Name = "c_progressBar";
            this.c_progressBar.Size = new System.Drawing.Size(259, 23);
            this.c_progressBar.TabIndex = 0;
            // 
            // c_btnCancel
            // 
            this.c_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.c_btnCancel.Location = new System.Drawing.Point(196, 43);
            this.c_btnCancel.Name = "c_btnCancel";
            this.c_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.c_btnCancel.TabIndex = 1;
            this.c_btnCancel.Text = "Cancel";
            this.c_btnCancel.UseVisualStyleBackColor = true;
            this.c_btnCancel.Click += new System.EventHandler(this.c_btnCancel_Click);
            // 
            // ProgressBarDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 76);
            this.ControlBox = false;
            this.Controls.Add(this.c_btnCancel);
            this.Controls.Add(this.c_progressBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBarDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Progress...";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar c_progressBar;
        private System.Windows.Forms.Button c_btnCancel;
    }
}