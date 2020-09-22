using Aircall.Data;
using Aircall.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Aircall
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AuntidicationPage : Page
    {
        List<Password> passwords;

        public AuntidicationPage()
        {
            this.InitializeComponent();
            passwords = new List<Password>();
            using (var db = new ApplicationDbContext())
            {
                passwords = db.passes.ToList();
            }
            ItemSettings itmSett = new ItemSettings();
            if (itmSett.tglsw.IsOn == false)
            {
                Window.Current.Content = myFrame;
                myFrame.Navigate(typeof(MainPage));
                Window.Current.Activate();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (passwords.Count == 0)
            {
                tbx_Word.Text = "Создайте пароль для дальнейшего входа в учётную запись.";
                btn_Accept.Content = "Создать";
            }
            else if (passwords.Count != 0)
            {
                tbx_Word.Text = "Введите пароль для входа в учётную запись.";
                btn_Accept.Content = "Войти";
            }
        }

        private void btn_Accept_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                if (btn_Accept.Content == "Создать")
                {
                    Password item = new Password
                    {
                        id = 1,
                        pass = tbx_pass.Password
                    };

                    if(!string.IsNullOrEmpty(tbx_pass.Password) && !string.IsNullOrWhiteSpace(tbx_pass.Password))
                    {
                        db.passes.Add(item);
                        db.SaveChanges();
                        Window.Current.Content = myFrame;
                        myFrame.Navigate(typeof(MainPage));
                        Window.Current.Activate();
                    }
                    else
                    {
                        tbl_Wrong.Visibility = Visibility.Visible;
                    }
                }
                else if (btn_Accept.Content == "Войти")
                {
                    passwords = db.passes.ToList();

                    foreach(var peoplePass in this.passwords)
                    {
                        if(peoplePass.pass == tbx_pass.Password)
                        {
                            Window.Current.Content = myFrame;
                            myFrame.Navigate(typeof(MainPage));
                            Window.Current.Activate();
                        }
                        else
                        {
                            tbl_Wrong.Text = "Вы ввели не верный пароль!";
                            tbl_Wrong.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
            
        }
    }
}
