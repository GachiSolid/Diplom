using CreditBureauWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CreditBureauWPF.ViewModels
{
    public class CreateWindowViewModel : INotifyPropertyChanged
    {
        UserContext db;
        public Action Close { get; set; }
        public string Familiya { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public string Gender { get; set; }
        public string Snils { get; set; }
        public string Bank { get; set; }
        public string Sum { get; set; }
        public string Percent { get; set; }
        public DateTime? Date { get; set; }
        public string MounthText { get; set; }
        public string MounthBox { get; set; }
        public bool TextVisible { get; set; }
        public bool ComboVisible { get; set; }
        public string Warn { get; set; }
        public List<Person> IdSub { get; set; }
        public string IdText { get; set; }
        string user;

        public CreateWindowViewModel(string _user)
        {
            db = new UserContext();
            db.People.Load();
            var id = db.People.ToList();
            IdSub = id;
            user = _user;
        }

        public ICommand Create
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        db = new UserContext();
                        if (IdText != null)
                        {
                            int id = Convert.ToInt32(IdText);
                            var check = db.People.FirstOrDefault(c => c.Id.Equals(id));

                            if (check != null)
                            {
                                check.Date = DateTime.Now;
                                check.User = user;
                                CreditBank credit = new CreditBank { Bank = Bank, Sum = Convert.ToInt32(Sum), Percent = Convert.ToInt32(Percent), Begin = Date, Mounth = Converter(), Status = false, Person = check, PersonId = check.Id};
                                db.CreditBanks.Add(credit);
                                db.SaveChanges();
                            }
                            else
                            {
                                Warn = "Такого кода субъекта нет";
                                OnPropertyChanged("Warn");
                            }
                        }

                        else
                        {
                            var check = db.People.FirstOrDefault(c => (c.Familiya == Familiya && c.Snils == Snils));

                            if (check == null)
                            {

                                Person person = new Person { Familiya = Familiya, Name = Name, Otchestvo = Otchestvo, Gender = Gender, Snils = Snils, Date = DateTime.Now, User = user };
                                db.People.Add(person);
                                db.SaveChanges();

                                int id = person.Id;
                                var people = db.People.FirstOrDefault(p => p.Id == id);

                                CreditBank credit = new CreditBank { Bank = Bank, Sum = Convert.ToInt32(Sum), Percent = Convert.ToInt32(Percent), Begin = Date, Mounth = Converter(), Status = false, Person = people, PersonId = id };
                                db.CreditBanks.Add(credit);
                                db.SaveChanges();
                            }

                            else
                            {
                                check.Date = DateTime.Now;
                                check.User = user;
                                CreditBank credit = new CreditBank { Bank = Bank, Sum = Convert.ToInt32(Sum), Percent = Convert.ToInt32(Percent), Begin = Date, Mounth = Converter(), Status = false, Person = check, PersonId = check.Id };
                                db.CreditBanks.Add(credit);
                                db.SaveChanges();
                            }
                        }
                        Close();
                    },
                    (obj) =>
                    {
                        return (!string.IsNullOrWhiteSpace(Bank) && !string.IsNullOrWhiteSpace(Convert.ToString(Sum)) && !string.IsNullOrWhiteSpace(Convert.ToString(Percent)) && !string.IsNullOrWhiteSpace(Convert.ToString(Date)) && !string.IsNullOrWhiteSpace(Convert.ToString(MounthText)) && !string.IsNullOrWhiteSpace(MounthBox)) &&
                            ((!string.IsNullOrWhiteSpace(Familiya) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Otchestvo) && !string.IsNullOrWhiteSpace(Gender) && !string.IsNullOrWhiteSpace(Snils)) ||
                            (!string.IsNullOrWhiteSpace(IdText)));
                    });
            }
        }

        public string Converter()
        {
            string Mounth;
            if (MounthBox == "мес.")
            {
                Mounth = MounthText + " " + MounthBox;
            }

            else
            {
                if (((Convert.ToInt32(MounthText) / 10 % 10) == 1) || ((Convert.ToInt32(MounthText) % 10) == 0) || (((Convert.ToInt32(MounthText) % 10) >= 5) && (Convert.ToInt32(MounthText) % 10) <= 9)) Mounth = MounthText + " " + MounthBox;
                else if ((Convert.ToInt32(MounthText) % 10) == 1) Mounth = MounthText + " год";
                else Mounth = MounthText + " года";
            }

            return Mounth;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
