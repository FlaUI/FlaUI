using System.Windows.Forms;

namespace WinFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NonEditableCombo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem.ToString() == "Item 4")
            {
                MessageBox.Show("Do you really want to do it?");
            }
        }
    }
}
