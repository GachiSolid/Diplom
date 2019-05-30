using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using CreditBureauWPF.Models;

namespace CreditBureauWPF.ViewModels
{
    public class TaskWindowViewModel : DependencyObject
    {
        UserContext db;
        public Action Close { get; set; }
        RelayCommand delete;
        RelayCommand open;
        string user;

        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(TaskWindowViewModel), new PropertyMetadata("", FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as TaskWindowViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterPerson;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(TaskWindowViewModel), new PropertyMetadata(null));

        public TaskWindowViewModel(string _user)
        {
            db = new UserContext();
            db.People.Load();
            Items = CollectionViewSource.GetDefaultView(db.People.Local.ToList());
            Items.Filter = FilterPerson;
            user = _user;
        }


        private bool FilterPerson(object obj)
        {
            bool result = true;
            Person current = obj as Person;
            if (!string.IsNullOrWhiteSpace(FilterText) && current != null && !current.Familiya.Contains(FilterText) && !current.Name.Contains(FilterText) && !current.Snils.Contains(FilterText))
            {
                result = false;
            }
            return result;
        }

        public ICommand LogOut
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        MessageBoxResult delete = MessageBox.Show("Вы уверны, что хотите выйти из учетной записи?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Information);

                        switch (delete)
                        {
                            case MessageBoxResult.Yes:
                                {
                                    MainWindow main = new MainWindow();
                                    main.Show();
                                    db.Dispose();
                                    Close();
                                }
                                break;
                        }
                    }
                    );
            }
        }

        public ICommand Clear
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        FilterText = null;
                    });
            }
        }

        public ICommand Create
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        CreateWindow create = new CreateWindow(user);

                        if (create.ShowDialog() == true)
                        {
                            db.People.Load();
                            Items = null;
                            Items = CollectionViewSource.GetDefaultView(db.People.Local.ToList());
                        }
                    });
            }
        }

        public RelayCommand Open
        {
            get
            {
                return open ??
                (open = new RelayCommand((selectedItem) =>
                {
                    if (selectedItem == null) return;
                    var line = (Person)selectedItem;
                    CreditWindow credit = new CreditWindow(line, user);
                    credit.ShowDialog();
                }));
            }
        }

        public ICommand Update
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

        public RelayCommand Delete
        {
            get
            {
                return delete ??
                (delete = new RelayCommand((selectedItem) =>
                {
                    MessageBoxResult delete = MessageBox.Show("Вы уверны, что хотите удалить?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    switch (delete)
                    {
                        case MessageBoxResult.Yes:
                            {
                                if (selectedItem == null) return;
                                Person person = selectedItem as Person;
                                db.People.Remove(person);
                                db.SaveChanges();
                                db.People.Load();
                                Items = null;
                                Items = CollectionViewSource.GetDefaultView(db.People.Local.ToList());
                            }
                            break;
                    }
                }));
            }
        }
    }
}
