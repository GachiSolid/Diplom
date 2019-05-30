using System;
using System.Windows;
using CreditBureauWPF.Models;
using CreditBureauWPF.ViewModels;

namespace CreditBureauWPF
{
    public partial class CreditWindow : Window
    {

        public CreditWindow(Person person, string user)
        {
            InitializeComponent();

            CreditWindowViewModel vm = new CreditWindowViewModel(person, user);
            this.DataContext = vm;
            if (vm.Close == null) vm.Close = new Action(this.Close);
        }

        private void des_Click(object sender, RoutedEventArgs e)
        {
            CreditBank des = ((FrameworkElement)sender).DataContext as CreditBank;
            MessageBox.Show(des.Description);
        }
    }
}
