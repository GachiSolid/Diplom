using System;
using System.Windows;
using CreditBureauWPF.ViewModels;

namespace CreditBureauWPF
{
    public partial class AppealWindow : Window
    {

        public AppealWindow(string full, string name, int id, int value)
        {
            InitializeComponent();

            AppealWindowViewModel vm = new AppealWindowViewModel(full, name, id, value);
            this.DataContext = vm;
            if (vm.Close == null) vm.Close = new Action(this.Close);
        }

        private void appeal_DropDownClosed(object sender, EventArgs e)
        {
            if (appeal.Text == "Запрос банка" || appeal.Text == "Запрос работадателя")
            {
                organization.Visibility = Visibility.Visible;
                infoBox.Visibility = Visibility.Collapsed;
            }
            else if (appeal.Text == "Другая причина")
            {
                organization.Visibility = Visibility.Collapsed;
                infoBox.Visibility = Visibility.Visible;
            }
            else
            {
                organization.Visibility = Visibility.Collapsed;
                infoBox.Visibility = Visibility.Collapsed;
            }
        }
    }
}
