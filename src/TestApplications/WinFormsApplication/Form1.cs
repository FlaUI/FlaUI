using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WinFormsApplication.Core;

namespace WinFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var list = new List<DataGridViewItem>()
            {
                new DataGridViewItem { Name = "John", Number = 12, IsChecked = false },
                new DataGridViewItem { Name = "Doe",  Number = 24, IsChecked = true }
            };
            var bindingList = new BindingList<DataGridViewItem>(list);
            var source = new BindingSource(bindingList, null);
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = source;
        }

        private void NonEditableCombo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem.ToString() == "Item 4")
            {
                MessageBox.Show("Do you really want to do it?");
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                button.Text = "Invoked!";
            }
        }
    }
}
