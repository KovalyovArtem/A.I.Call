using Aircall.Data;
using Aircall.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.StartScreen;
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
    public sealed partial class ItemSettings : Page
    {
        List<Password> passwords;
        List<SaveProperties> Saves;
        public ToggleSwitch tglsw = new ToggleSwitch();

        public ItemSettings()
        {
            this.InitializeComponent();

            passwords = new List<Password>();
            Saves = new List<SaveProperties>();

            using (var db = new ApplicationDbContext())
            {
                tglsw = tgl_switch1;
                Saves = db.saveProp.ToList();

                foreach (var tglswSave in this.Saves)
                {
                    if (tglswSave.id == 1)
                    {
                        tglsw.IsOn = tglswSave.prop;
                    }
                }
            }
        }

        public void tgl_switch1_Toggled(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                Saves = db.saveProp.ToList();
                if (tglsw.IsOn == true)
                {
                    foreach (var saves in this.Saves)
                    {
                        if (saves.id == 1)
                        {
                            saves.prop = true;
                            db.saveProp.Update(saves);
                        }
                        db.SaveChanges();
                    }
                }
                if(tglsw.IsOn == false)
                {
                    foreach (var saves in this.Saves)
                    {
                        if (saves.id == 1)
                        {
                            saves.prop = false;
                            db.saveProp.Update(saves);
                        }
                        db.SaveChanges();
                    }
                }
            }
        }

        private void btn_DelPass_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                passwords = db.passes.ToList();
                foreach (var passDel in this.passwords)
                {
                    if (passDel.id == 1)
                    {
                        db.passes.Remove(passDel);
                    }
                }
                db.SaveChanges();
            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            tbx_EditPass.Visibility = Visibility.Visible;
        }

        private void tbx_EditPass_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                using (var db = new ApplicationDbContext())
                {
                    passwords = db.passes.ToList();
                    foreach (var passEdit in this.passwords)
                    {
                        if (passEdit.id == 1 && tbl_Ok.Text.Length != 0)
                        {
                            passEdit.pass = tbx_EditPass.Password;
                            db.passes.Update(passEdit);
                            tbl_Ok.Visibility = Visibility.Visible;
                            db.SaveChanges();
                            tbx_EditPass.Password = "";
                        }
                        else
                        {
                            tbl_Ok.Text = "Ошибка!";
                            tbl_Ok.Foreground = new SolidColorBrush(Colors.Red);
                            tbl_Ok.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }
    }
}
