using Aircall.Data;
using Aircall.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Windows.UI;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Aircall
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ItemContacts : Page
    {
        List<Peoples> names;

        public ItemContacts() //ToggleSwitch tglsw
        {
            this.InitializeComponent();

            FilterCombo.Items.Add("Фамилия");
            FilterCombo.Items.Add("Имя");
            FilterCombo.Items.Add("Отчество");
            FilterCombo.Items.Add("Телефон");
            FilterCombo.Items.Add("Дата рождения");
            FilterCombo.Items.Add("Адрес");
            FilterCombo.Items.Add("Почта");

            names = new List<Peoples>();

            using (var db = new ApplicationDbContext())
            {
                names = db.People.ToList();
            }
        }

        private class filters
        {
            public string Names;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PeopleList.ItemsSource = names;
        }

        private void AddButtonPane_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                Peoples item = new Peoples
                {
                    firstName = firstNametxt.Text,
                    Name = Nametxt.Text,
                    lastName = LastNametxt.Text,
                    Data = Agetxt.Text,
                    Telephone = Telephonetxt.Text,
                    Email = Emailtxt.Text,
                    Adress = Adresstxt.Text
                };

                if (!string.IsNullOrEmpty(Nametxt.Text) && !string.IsNullOrWhiteSpace(Nametxt.Text))
                {
                    db.People.Add(item);
                    db.SaveChanges();

                    PeopleList.ItemsSource = db.People.ToList();
                    MySplitView.IsPaneOpen = false;
                    firstNametxt.Text = "";
                    Nametxt.Text = "";
                    LastNametxt.Text = "";
                    Agetxt.Text = "";
                    Telephonetxt.Text = "";
                    Emailtxt.Text = "";
                    Adresstxt.Text = "";
                }
                else
                {
                    txtWrong.Visibility = Visibility;
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (PeopleList.SelectedItem != null)
            {
                Peoples people = PeopleList.SelectedItem as Peoples;
                if (people != null)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        db.People.Remove(people);
                        db.SaveChanges();

                        PeopleList.ItemsSource = db.People.ToList();
                    }
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitViewEdit.IsPaneOpen = !MySplitViewEdit.IsPaneOpen;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (PeopleList.SelectedItem != null)
            {
                Peoples people = PeopleList.SelectedItem as Peoples;

                if (people != null)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        if (people != null)
                        {
                            people.firstName = firstNametxt1.Text;
                            people.Name = Nametxt1.Text;
                            people.lastName = LastNametxt1.Text;
                            people.Data = Agetxt1.Text;
                            people.Telephone = Telephonetxt1.Text;
                            people.Email = Emailtxt1.Text;
                            people.Adress = Adresstxt1.Text;
                            db.People.Update(people);
                        }
                        else
                        {
                            db.People.Add(new Peoples
                            {
                                firstName = firstNametxt1.Text,
                                Name = Nametxt1.Text,
                                lastName = LastNametxt1.Text,
                                Data = Agetxt1.Text,
                                Telephone = Telephonetxt1.Text,
                                Email = Emailtxt1.Text,
                                Adress = Adresstxt1.Text
                            });
                        }
                        db.SaveChanges();
                        PeopleList.ItemsSource = db.People.ToList();
                        MySplitViewEdit.IsPaneOpen = false;
                        firstNametxt1.Text = "";
                        Nametxt1.Text = "";
                        LastNametxt1.Text = "";
                        Agetxt1.Text = "";
                        Telephonetxt1.Text = "";
                        Emailtxt1.Text = "";
                        Adresstxt1.Text = "";
                    }
                }
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var cont = from s in names where s.Name.Contains(tbxSearc.Text) select s;
            var cont1 = from s in names where s.firstName.Contains(tbxSearc.Text) select s;
            var cont2 = from s in names where s.lastName.Contains(tbxSearc.Text) select s;
            var cont3 = from s in names where s.Adress.Contains(tbxSearc.Text) select s;
            var cont4 = from s in names where s.Data.Contains(tbxSearc.Text) select s;
            var cont5 = from s in names where s.Email.Contains(tbxSearc.Text) select s;
            var cont6 = from s in names where s.Telephone.Contains(tbxSearc.Text) select s;

            if (FilterCombo.SelectedItem == "Имя")
            {
                PeopleList.ItemsSource = cont;
            }
            else if(FilterCombo.SelectedItem == "Фамилия")
            {
                PeopleList.ItemsSource = cont1;
            }
            else if (FilterCombo.SelectedItem == "Отчество")
            {
                PeopleList.ItemsSource = cont2;
            }
            else if (FilterCombo.SelectedItem == "Телефон")
            {
                PeopleList.ItemsSource = cont6;
            }
            else if (FilterCombo.SelectedItem == "Дата рождения")
            {
                PeopleList.ItemsSource = cont4;
            }
            else if (FilterCombo.SelectedItem == "Адрес")
            {
                PeopleList.ItemsSource = cont3;
            }
            else if (FilterCombo.SelectedItem == "Почта")
            {
                PeopleList.ItemsSource = cont5;
            }
        }

        private void tbxSearc_TextChanged(object sender, TextChangedEventArgs e)
        {
            PeopleList.ItemsSource = names;
        }
    }
}
