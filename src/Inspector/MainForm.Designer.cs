namespace Inspector
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnStartSelection;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartSelection
            // 
            this.btnStartSelection.Location = new System.Drawing.Point(12, 12);
            this.btnStartSelection.Name = "btnStartSelection";
            this.btnStartSelection.Size = new System.Drawing.Size(200, 40);
            this.btnStartSelection.TabIndex = 0;
            this.btnStartSelection.Text = "Start Element Selection";
            this.btnStartSelection.UseVisualStyleBackColor = true;
            this.btnStartSelection.Click += new System.EventHandler(this.btnStartSelection_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(234, 66);
            this.Controls.Add(this.btnStartSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlaUI Inspector";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
