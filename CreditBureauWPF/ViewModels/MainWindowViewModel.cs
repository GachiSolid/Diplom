using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CreditBureauWPF.Models;
using System.Windows.Input;

namespace CreditBureauWPF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public string Login { get; set; }
        public string password
        {
            get;
            set;
        }
        public string Warn { get; set; }
        public Action Close { get; set; }
        readonly Func<string> GetPassword;
        public bool check = true;

        public MainWindowViewModel(Func<string> getPass)
        {
            GetPassword = getPass;
        }

        public ICommand Check
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        using (UserContext db = new UserContext())
                        {
                            string pass = GetPassword();
                            var user = db.Users.SingleOrDefault(p => p.Login == Login && p.Password == pass);
                            if (user != null)
                            {
                                if (user.IsAdmin == true)
                                {
                                    user.LastOnline = DateTime.Now;
                                    db.SaveChanges();
                                    AdminWindow adminWindow = new AdminWindow();
                                    adminWindow.Show();
                                    Close();
                                }
                                else
                                {
                                    user.LastOnline = DateTime.Now;
                                    db.SaveChanges();
                                    TaskWindow task = new TaskWindow(user.Login);
                                    task.Show();
                                    Close();
                                }
                            }
                            else check = false;
                        }
                    },
                    (obj) =>
                    {
                        if (check == false)
                        {
                            Warn = "Неправильный логин или пароль";
                            OnPropertyChanged("Warn");
                        }
                        return !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(GetPassword());
                    }
                    );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
