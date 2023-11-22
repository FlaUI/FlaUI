namespace WinFormsApplication
{
    partial class FormWindow1
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
            this.window1TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // window1TextBox
            // 
            this.window1TextBox.Location = new System.Drawing.Point(182, 133);
            this.window1TextBox.Name = "window1TextBox";
            this.window1TextBox.Size = new System.Drawing.Size(100, 20);
            this.window1TextBox.TabIndex = 0;
            this.window1TextBox.Text = "Window1 TextBox";
            // 
            // FormWindow1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 309);
            this.Controls.Add(this.window1TextBox);
            this.Name = "FormWindow1";
            this.Text = "FormWindow1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox window1TextBox;
    }
}