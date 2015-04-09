namespace DataCenter.Forms
{
    partial class ProgressFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressFrm));
            this.pbc = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pbc
            // 
            this.pbc.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbc.Location = new System.Drawing.Point(0, 0);
            this.pbc.Name = "pbc";
            this.pbc.Size = new System.Drawing.Size(403, 21);
            this.pbc.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Image = global::DataCenter.Properties.Resources.cancel_16x16;
            this.btnCancel.Location = new System.Drawing.Point(409, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProgressFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 21);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressFrm";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Please wait ......";
            ((System.ComponentModel.ISupportInitialize)(this.pbc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl pbc;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}