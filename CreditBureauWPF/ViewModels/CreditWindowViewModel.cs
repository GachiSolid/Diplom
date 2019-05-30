using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using CreditBureauWPF.Models;

namespace CreditBureauWPF.ViewModels
{
    public class CreditWindowViewModel : DependencyObject
    {
        UserContext db;
        public Action Close { get; set; }
        public string Title { get; set; }
        Person person;
        RelayCommand pogas;
        private bool closeCredit;
        string user;
        public bool CloseCredit
        {
            get { return closeCredit; }
            set
            {
                closeCredit = value;
                OnPropertyChanged();
            }
        }
        private bool activeCredit;
        public bool ActiveCredit
        {
            get { return activeCredit; }
            set
            {
                activeCredit = value;
                OnPropertyChanged();
            }
        }
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public ICollectionView ActiveItems
        {
            get { return (ICollectionView)GetValue(ActiveItemsProperty); }
            set { SetValue(ActiveItemsProperty, value); }
        }

        public static readonly DependencyProperty ActiveItemsProperty =
            DependencyProperty.Register("ActiveItems", typeof(ICollectionView), typeof(CreditWindowViewModel), new PropertyMetadata(null));

        public ICollectionView CloseItems
        {
            get { return (ICollectionView)GetValue(CloseItemsProperty); }
            set { SetValue(CloseItemsProperty, value); }
        }

        public static readonly DependencyProperty CloseItemsProperty =
            DependencyProperty.Register("CloseItems", typeof(ICollectionView), typeof(CreditWindowViewModel), new PropertyMetadata(null));

        public CreditWindowViewModel(Person _person, string _user)
        {
            person = _person;
            user = _user;
            Update();
        }

        void Update()
        {
            db = new UserContext();
            db.CreditBanks.Load();

            int allrating = 0;
            int onerating = 0;
            int a = 0;
            int value = 0;
            int percent = 0;
            int appealcount = 0;
            int appercent = 0;
            activeCredit = false;
            closeCredit = false;

            Title = "Кредитная история: " + person.Familiya + " " + person.Name + " " + person.Otchestvo;
            var activecredits = db.CreditBanks.Where(c => c.PersonId.Equals(person.Id) && c.Status.Equals(false));
            if (activecredits.Any())
            {
                foreach (CreditBank c in activecredits)
                {
                    if (c.Sum >= 100000)
                    {
                        a++;
                    }
                }
                activeCredit = true;
            }
            ActiveItems = CollectionViewSource.GetDefaultView(activecredits.ToList());

            var closecredits = db.CreditBanks.Where(c => c.PersonId.Equals(person.Id) && c.Status.Equals(true));
            if (closecredits.Any())
            {
                foreach (CreditBank c in closecredits)
                {
                    onerating += c.Score;
                    allrating++;
                }
                closeCredit = true;
            }
            CloseItems = CollectionViewSource.GetDefaultView(closecredits.ToList());

            var appeals = db.Appeals.Where(c => c.PersonId.Equals(person.Id));
            if (appeals.Any())
            {
                foreach (Appeal c in appeals)
                {
                    appealcount++;
                }
            }

            if (allrating == 0)
            {
                if (a >= 1) Value = 2;
                else Value = 4;
            }

            else
            {
                if (a == 1) percent = 20;
                else if (a > 1) percent = 30;
                if (appealcount > 5 && appealcount <= 10) appercent = 5;
                else if (appealcount > 10) appercent = 10;
                value = (onerating / allrating) - percent - appercent;
                Value = value / 10;
            }
        }

        public ICommand UpdateGrid
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        db.SaveChanges();
                    });
            }
        }

        public ICommand CloseWindow
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        db.Dispose();
                        Close();
                    });
            }
        }

        public RelayCommand Pogas
        {
            get
            {
                return pogas ??
                (pogas = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;
                    var line = (CreditBank)selectedItem;
                    CloseCreditWindow closeCredit = new CloseCreditWindow (line, person.Id, user);
                    if (closeCredit.ShowDialog() == true)
                    {
                        db.SaveChanges();
                        Update();
                    }
                }));
            }
        }

        public ICommand Report
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        string full = Title;
                        string name = person.Familiya;
                        int id = person.Id;

                        AppealWindow appeal = new AppealWindow(full, name, id, Value);
                        appeal.ShowDialog();
                    });
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
