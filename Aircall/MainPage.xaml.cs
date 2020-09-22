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
using Aircall.Data;
using Aircall.Model;
using System.Diagnostics;
using Windows.UI.Xaml.Documents;
//using Tulpep.NotificationWindow;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Aircall
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MyFrame.Navigate(typeof(ItemContacts));
            HeaderText.Text = "Контакты";
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemContacts.IsSelected)
            {
                MyFrame.Navigate(typeof(ItemContacts));
                HeaderText.Text = "Контакты";
            }
            if (ItemSettings.IsSelected)
            {
                MyFrame.Navigate(typeof(ItemSettings));
                HeaderText.Text = "Настройки";
            }
        }

        private void GamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //using(var db = new ApplicationDbContext())
            //{
            //    foreach(var happyBirth in peoples)
            //    {
            //        if(happyBirth.Data == Convert.ToString(DateTime.Now))
            //        {
            //            PopupNotifier popup = new PopupNotifier();
            //            //popup.Image = Image.
            //            popup.TitleText = "Сегодня День Рождение!";
            //            popup.ContentText = "Сегодня День Рождение у " + happyBirth.Name + " " + happyBirth.firstName;
            //            popup.Popup();
            //        }
            //    }
            //}
        }
    }
}
