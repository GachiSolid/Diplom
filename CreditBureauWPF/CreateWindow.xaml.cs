using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CreditBureauWPF.Models;
using CreditBureauWPF.ViewModels;

namespace CreditBureauWPF
{
    public partial class CreateWindow : Window
    {

        public CreateWindow(string user)
        {
            InitializeComponent();

            datePicker.DisplayDateEnd = DateTime.Now;
            CreateWindowViewModel vm = new CreateWindowViewModel(user);
            this.DataContext = vm;
            if (vm.Close == null) vm.Close = new Action(this.Close);
        }

        private void number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) || Char.IsPunctuation(e.Text,0)) e.Handled = true;
        }

        private void MounthText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MounthText.Text == "" || Convert.ToInt32(MounthText.Text) == 0)
            {
                MounthBox.IsEnabled = false;
                MounthBox.Text = "";
            }
            else MounthBox.IsEnabled = true;
        }

        private void space(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
        }

        private void have_Checked(object sender, RoutedEventArgs e)
        {
            Familiya.Visibility = Visibility.Collapsed;
            Name.Visibility = Visibility.Collapsed;
            Otchestvo.Visibility = Visibility.Collapsed;
            Gender.Visibility = Visibility.Collapsed;
            Passport.Visibility = Visibility.Collapsed;
            exist.Visibility = Visibility.Visible;
            have.Content = "";
        }

        private void have_Unchecked(object sender, RoutedEventArgs e)
        {
            Familiya.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            Otchestvo.Visibility = Visibility.Visible;
            Gender.Visibility = Visibility.Visible;
            Passport.Visibility = Visibility.Visible;
            exist.Visibility = Visibility.Collapsed;
            have.Content = "Человек есть в базе данных?";
            exist.Text = null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
