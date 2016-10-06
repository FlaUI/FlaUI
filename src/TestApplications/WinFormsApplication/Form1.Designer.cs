namespace WinFormsApplication
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Lvl2 a");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lvl3 a");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Lvl2 b", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Lvl2 c");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Lvl1 a", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Lvl1 b");
            this.label1 = new System.Windows.Forms.Label();
            this.EditableCombo = new System.Windows.Forms.ComboBox();
            this.SimpleCheckBox = new System.Windows.Forms.CheckBox();
            this.ThreeStateCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fancyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadioButton2 = new System.Windows.Forms.RadioButton();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Slider = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test Label";
            // 
            // EditableCombo
            // 
            this.EditableCombo.FormattingEnabled = true;
            this.EditableCombo.Items.AddRange(new object[] {
            "Item 1",
            "Item 2",
            "Item 3"});
            this.EditableCombo.Location = new System.Drawing.Point(70, 6);
            this.EditableCombo.Name = "EditableCombo";
            this.EditableCombo.Size = new System.Drawing.Size(121, 21);
            this.EditableCombo.TabIndex = 1;
            // 
            // SimpleCheckBox
            // 
            this.SimpleCheckBox.AutoSize = true;
            this.SimpleCheckBox.Location = new System.Drawing.Point(10, 33);
            this.SimpleCheckBox.Name = "SimpleCheckBox";
            this.SimpleCheckBox.Size = new System.Drawing.Size(98, 17);
            this.SimpleCheckBox.TabIndex = 2;
            this.SimpleCheckBox.Text = "Test Checkbox";
            this.SimpleCheckBox.UseVisualStyleBackColor = true;
            // 
            // ThreeStateCheckBox
            // 
            this.ThreeStateCheckBox.AutoSize = true;
            this.ThreeStateCheckBox.Location = new System.Drawing.Point(10, 56);
            this.ThreeStateCheckBox.Name = "ThreeStateCheckBox";
            this.ThreeStateCheckBox.Size = new System.Drawing.Size(132, 17);
            this.ThreeStateCheckBox.TabIndex = 3;
            this.ThreeStateCheckBox.Text = "3-Way Test Checkbox";
            this.ThreeStateCheckBox.ThreeState = true;
            this.ThreeStateCheckBox.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plainToolStripMenuItem,
            this.fancyToolStripMenuItem});
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // plainToolStripMenuItem
            // 
            this.plainToolStripMenuItem.Name = "plainToolStripMenuItem";
            this.plainToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.plainToolStripMenuItem.Text = "Plain";
            // 
            // fancyToolStripMenuItem
            // 
            this.fancyToolStripMenuItem.Name = "fancyToolStripMenuItem";
            this.fancyToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.fancyToolStripMenuItem.Text = "Fancy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // RadioButton2
            // 
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new System.Drawing.Point(10, 102);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new System.Drawing.Size(90, 17);
            this.RadioButton2.TabIndex = 10;
            this.RadioButton2.TabStop = true;
            this.RadioButton2.Text = "RadioButton2";
            this.RadioButton2.UseVisualStyleBackColor = true;
            // 
            // RadioButton1
            // 
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Location = new System.Drawing.Point(10, 79);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(90, 17);
            this.RadioButton1.TabIndex = 9;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "RadioButton1";
            this.RadioButton1.UseVisualStyleBackColor = true;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(7, 125);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 10);
            this.ProgressBar.TabIndex = 11;
            this.ProgressBar.Value = 50;
            // 
            // Slider
            // 
            this.Slider.LargeChange = 4;
            this.Slider.Location = new System.Drawing.Point(7, 141);
            this.Slider.Name = "Slider";
            this.Slider.Size = new System.Drawing.Size(150, 45);
            this.Slider.TabIndex = 16;
            this.Slider.Value = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(491, 273);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.Slider);
            this.tabPage1.Controls.Add(this.EditableCombo);
            this.tabPage1.Controls.Add(this.ProgressBar);
            this.tabPage1.Controls.Add(this.SimpleCheckBox);
            this.tabPage1.Controls.Add(this.RadioButton2);
            this.tabPage1.Controls.Add(this.ThreeStateCheckBox);
            this.tabPage1.Controls.Add(this.RadioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(483, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simple Controls";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(232, 9);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(100, 20);
            this.TextBox.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(483, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Complex Controls";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Lvl2 a";
            treeNode1.Text = "Lvl2 a";
            treeNode2.Name = "Lvl3 a";
            treeNode2.Text = "Lvl3 a";
            treeNode3.Name = "Lvl2 b";
            treeNode3.Text = "Lvl2 b";
            treeNode4.Name = "Lvl2 c";
            treeNode4.Text = "Lvl2 c";
            treeNode5.Name = "Lvl1 a";
            treeNode5.Text = "Lvl1 a";
            treeNode6.Name = "Lvl1 b";
            treeNode6.Text = "Lvl1 b";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(477, 241);
            this.treeView1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 297);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(491, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 319);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FlaUI WinForms Test App";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EditableCombo;
        private System.Windows.Forms.CheckBox SimpleCheckBox;
        private System.Windows.Forms.CheckBox ThreeStateCheckBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fancyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.RadioButton RadioButton2;
        private System.Windows.Forms.RadioButton RadioButton1;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.TrackBar Slider;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox TextBox;
    }
}

