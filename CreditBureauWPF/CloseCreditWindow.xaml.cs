using CreditBureauWPF.Models;
using CreditBureauWPF.ViewModels;
using System;
using System.Windows;

namespace CreditBureauWPF
{
    public partial class CloseCreditWindow : Window
    {

        public CloseCreditWindow(CreditBank credit, int personid, string user)
        {
            InitializeComponent();

            CloseCreditWindowViewModel vm = new CloseCreditWindowViewModel(credit, personid, user);
            this.DataContext = vm;
            if (vm.Close == null) vm.Close = new Action(this.Close);
        }

        private void info_Checked(object sender, RoutedEventArgs e)
        {
            infoBox.Visibility = Visibility.Visible;
        }

        private void info_Unchecked(object sender, RoutedEventArgs e)
        {
            infoBox.Text = "";
            infoBox.Visibility = Visibility.Collapsed;
        }

        private void zader_Checked(object sender, RoutedEventArgs e)
          {
              zaderlist.Visibility = Visibility.Visible;
          }

        private void zader_Unchecked(object sender, RoutedEventArgs e)
          {
              zaderlist.Text = "";
              zaderlist.Visibility = Visibility.Collapsed;
          }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
