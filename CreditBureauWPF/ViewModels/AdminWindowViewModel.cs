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
    class AdminWindowViewModel : DependencyObject
    {
        UserContext db;
        public Action Close { get; set; }
        RelayCommand delete;

        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(AdminWindowViewModel), new PropertyMetadata("", FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as AdminWindowViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterUser;
            }
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(AdminWindowViewModel), new PropertyMetadata(null));

        public AdminWindowViewModel()
        {
            db = new UserContext();
            db.Users.Load();
            Items = CollectionViewSource.GetDefaultView (db.Users.Local.ToList());
            Items.Filter = FilterUser;
        }


        private bool FilterUser (object obj)
        {
            bool result = true;
            User current = obj as User;
            if (!string.IsNullOrWhiteSpace(FilterText) && current != null && !current.Name.Contains(FilterText) && !current.Login.Contains(FilterText))
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
                        Registration registration = new Registration();

                        if (registration.ShowDialog() == true)
                        {
                            db.Users.Load();
                            Items = null;
                            Items = CollectionViewSource.GetDefaultView(db.Users.Local.ToList());
                        }
                    });
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
                                User user = selectedItem as User;
                                db.Users.Remove(user);
                                db.SaveChanges();
                                db.Users.Load();
                                Items = null;
                                Items = CollectionViewSource.GetDefaultView(db.Users.Local.ToList());
                            }
                            break;
                        }
                }));
            }
        }
    }
}
