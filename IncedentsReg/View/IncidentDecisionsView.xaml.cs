using Kurs.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kurs.View
{
    /// <summary>
    /// Логика взаимодействия для BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window
    {
        public BuyerWindow()
        {
            InitializeComponent();
            DataContext = new BuyerViewModel(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
