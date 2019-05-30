using System;
using System.Windows;
using CreditBureauWPF.Models;
using CreditBureauWPF.ViewModels;

namespace CreditBureauWPF
{
    public partial class TaskWindow : Window
    {
        public TaskWindow(string user)
        {
            InitializeComponent();

            TaskWindowViewModel vm = new TaskWindowViewModel(user);
            this.DataContext = vm;
            if (vm.Close == null) vm.Close = new Action(this.Close);
        }
    }
}
