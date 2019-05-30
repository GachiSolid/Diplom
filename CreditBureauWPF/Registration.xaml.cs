using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using CreditBureauWPF.ViewModels;

namespace CreditBureauWPF
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            RegistrationViewModel vm = new RegistrationViewModel(() => Pass.Password, () => PassConfirm.Password);
            this.DataContext = vm;
            if (vm.Close == null) vm.Close = new Action(this.Close);
        }

        private void RegName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) || Char.IsPunctuation(e.Text,0)) e.Handled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
