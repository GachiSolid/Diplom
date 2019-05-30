using System;
using System.Windows;
using CreditBureauWPF.ViewModels;

namespace CreditBureauWPF
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            AdminWindowViewModel vm = new AdminWindowViewModel();
            this.DataContext = vm;
            if (vm.Close == null) vm.Close = new Action(this.Close);
        }
    }
}
