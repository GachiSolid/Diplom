using CreditBureauWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CreditBureauWPF.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public Action Close { get; set; }
        readonly Func<string> GetPassword;
        readonly Func<string> GetConfirm;
        public string Role { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        bool ex = false;
        private string warn;
        public string Warn
        {
            get
            {
                return warn;
            }
            set
            {
                warn = value;
                OnPropertyChanged("Warn");
            }
        }
        public bool check = true;

        public RegistrationViewModel(Func<string> getPass, Func<string> getConfirm)
        {
            GetPassword = getPass;
            GetConfirm = getConfirm;
        }

        public ICommand Create
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        try
                        {
                            using (UserContext db = new UserContext())
                            {
                                bool admin;
                                string pass = GetPassword();
                                if (Role == "Администратор") admin = true;
                                else admin = false;

                                User user = new User { Login = Login, Password = pass, IsAdmin = admin, Name = Name};
                                db.Users.Add(user);
                                db.SaveChanges();
                                Close();
                            }
                        }
                        catch (Exception)
                        {
                            ex = true;
                            Warn = "Логин занят";
                        }
                        },
                    (obj) =>
                    {
                        string pass = GetPassword();
                        if (!string.IsNullOrWhiteSpace(pass))
                        {
                            if (pass != GetConfirm())
                            {
                                Warn = "Пароли не совпадают";
                                return false;
                            }
                            else if (ex != true)
                            {
                                Warn = "";
                            }
                            ex = false;
                        }
                        return !string.IsNullOrWhiteSpace(Role) && !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(GetPassword());
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
