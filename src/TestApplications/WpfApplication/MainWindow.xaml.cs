﻿using System.Windows;
using System.Windows.Controls;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            DataContext = vm;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (object item in e.AddedItems)
            {
                TextBlock textBlock = (TextBlock) item;
                if (textBlock.Text == "Item 4")
                {
                    MessageBox.Show("Do you really want to do it?");
                }
            }
        }
    }
}
