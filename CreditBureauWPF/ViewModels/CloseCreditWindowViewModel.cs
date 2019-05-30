using CreditBureauWPF.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CreditBureauWPF.ViewModels
{
    public class CloseCreditWindowViewModel : INotifyPropertyChanged
    {
        UserContext db;
        public Action Close { get; set; }
        public string Sposob { get; set; }
        public string ZaderList { get; set; }
        public string InfoBox { get; set; }
        public CreditBank credit { get; set; }
        public int personid;
        string user;

        public CloseCreditWindowViewModel(CreditBank _credit, int _personid, string _user)
        {
            credit = _credit;
            personid = _personid;
            user = _user;
        }

        public ICommand OkClick
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        string des;
                        int rating = 100;
                        if (ZaderList == "3-5") rating -= 20;
                        else if (ZaderList == ">5") rating -= 35;

                        if (Sposob == "Судебное разбирательство") rating -= 15;
                        else if (Sposob == "Досрочное погашение кредита") rating -= 10;

                        if (ZaderList == "1-2" || ZaderList == "3-5" || ZaderList == ">5")
                        {
                            des = "Задержки: " + ZaderList + ", ";
                        }
                        else des = null;

                        credit.Description = des + "Способ погашения: " + Sposob + ". " + InfoBox;
                        credit.Score += rating;
                        if (credit.Score > 100) credit.Score = 100;
                        credit.Status = true;
                        db = new UserContext();
                        var person = db.People.FirstOrDefault(c => c.Id.Equals(personid));
                        person.User = user;
                        person.Date = DateTime.Now;
                        db.SaveChanges();
                        Close();
                    },
                    (obj) =>
                    {
                        return !string.IsNullOrWhiteSpace(Sposob);
                    }
                    );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
