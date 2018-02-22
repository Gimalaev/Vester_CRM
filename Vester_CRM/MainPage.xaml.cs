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
using Windows.Storage.Pickers;
using Windows.Storage;

//using Microsoft.Data.Sqlite;
//using Microsoft.Data.Sqlite.Internal;


//using System.Data.Common;

using SQLite;
//using SQLitePCL;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Vester_CRM
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// string path;

    class Payment
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        [MaxLength(100)]
        public string НазначениеПлатежа { get; set; }
        [NotNull]
        public int Номер { get; set; }
        [MaxLength(10), NotNull]
        public string Дата { get; set; }
        [NotNull]
        public Double Сумма { get; set; }
        [MaxLength(30)]
        public string ПлательщикСчет { get; set; }
        [MaxLength(10)]
        public string ДатаСписано { get; set; }
        [MaxLength(10)]
        public string ДатаПоступило { get; set; }
        [MaxLength(15)]
        public string ПлательщикИНН { get; set; }
        [MaxLength(15)]
        public string ПлательщикКПП { get; set; }
        [MaxLength(50)]
        public string Плательщик1 { get; set; }
        [MaxLength(50)]
        public string Плательщик2 { get; set; }
        [MaxLength(30)]
        public string ПлательщикРасчСчет { get; set; }
        [MaxLength(50)]
        public string ПлательщикБанк1 { get; set; }
        [MaxLength(50)]
        public string ПлательщикБанк2 { get; set; }
        [MaxLength(15)]
        public string ПлательщикБИК { get; set; }
        [MaxLength(30)]
        public string ПлательщикКорсчет { get; set; }
        [MaxLength(30)]
        public string ПолучательСчет { get; set; }
        [MaxLength(15)]
        public string ПолучательИНН { get; set; }
        [MaxLength(15)]
        public string ПолучательКПП { get; set; }
        [MaxLength(50)]
        public string Получатель1 { get; set; }
        [MaxLength(50)]
        public string Получатель2 { get; set; }
        [MaxLength(30)]
        public string ПолучательРасчСчет { get; set; }
        [MaxLength(50)]
        public string ПолучательБанк1 { get; set; }
        [MaxLength(50)]
        public string ПолучательБанк2 { get; set; }
        [MaxLength(15)]
        public string ПолучательБИК { get; set; }
        [MaxLength(30)]
        public string ПолучательКорсчет { get; set; }
        [MaxLength(30)]
        public string ВидПлатежа { get; set; }
        [MaxLength(3)]
        public string ВидОплаты { get; set; }

    }


    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            this.InitializeComponent();

 //           Grab_Entries();
        }

        private async void Button_Extract_Account_Click(object sender, RoutedEventArgs e)
        {
            bool b = false, z=false, sect = false;

            var db = new SQLiteConnection("bd_vester.db", true);
            var pm = new Payment();
            string s;
            int i=0;
            double summ=0, fr=0;
            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.Desktop,
                CommitButtonText = "Открыть выписку"
            };
            openPicker.FileTypeFilter.Add(".txt");
            var file = await openPicker.PickSingleFileAsync();
            var lines = await Windows.Storage.FileIO.ReadLinesAsync(file);


            foreach (var line in lines)
            {
                // Строки будут выводиться в окне Output Visual Studio
                // с ними можно делать все, что угодно
                b = line.Contains("СекцияДокумент=Платежное поручение");

                if (b)
                {
                    sect=true;
                    b = false;

                }

                if (sect)
                {
                    z = line.Contains("Номер=");
                    if (z)
                    {
                        s = line.Replace("Номер=", "");
                        pm.Номер = Convert.ToInt32(s);
                    }
                    z = line.Contains("Дата=");
                    if (z)
                    {
                        s = line.Replace("Дата=", "");
                        pm.Дата = s;
                    }
                    z = line.Contains("Сумма=");
                    if (z)
                    {
                        s = line.Replace("Сумма=", "");
                        s = s.Replace(".", ",");
                        Output.Items.Add(s);
                        pm.Сумма = Convert.ToDouble(s);
                    }
                    z = line.Contains("ПлательщикСчет=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикСчет=", "");
                        pm.ПлательщикСчет = s;
                    }
                    z = line.Contains("ДатаСписано=");
                    if (z)
                    {
                        s = line.Replace("ДатаСписано=", "");
                        pm.ДатаСписано = s;
                        fr += pm.Сумма;
                    }
                    z = line.Contains("ДатаПоступило=");
                    if (z)
                    {
                        s = line.Replace("ДатаПоступило=", "");
                        pm.ДатаПоступило = s;
                        summ += pm.Сумма;

                    }
                    z = line.Contains("ПлательщикИНН=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикИНН=", "");
                        pm.ПлательщикИНН = s;
                    }
                    z = line.Contains("ПлательщикКПП=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикКПП=", "");
                        pm.ПлательщикКПП = s;
                    }
                    z = line.Contains("Плательщик1=");
                    if (z)
                    {
                        s = line.Replace("Плательщик1=", "");
                        pm.Плательщик1 = s;
                    }
                    z = line.Contains("Плательщик2=");
                    if (z)
                    {
                        s = line.Replace("Плательщик2=", "");
                        pm.Плательщик2 = s;
                    }
                    z = line.Contains("ПлательщикРасчСчет=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикРасчСчет=", "");
                        pm.ПлательщикРасчСчет = s;
                    }
                    z = line.Contains("ПлательщикБанк1=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикБанк1=", "");
                        pm.ПлательщикБанк1 = s;
                    }
                    z = line.Contains("ПлательщикБанк2=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикБанк2=", "");
                        pm.ПлательщикБанк2 = s;
                    }
                    z = line.Contains("ПлательщикБИК=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикБИК=", "");
                        pm.ПлательщикБИК = s;
                    }
                    z = line.Contains("ПлательщикКорсчет=");
                    if (z)
                    {
                        s = line.Replace("ПлательщикКорсчет=", "");
                        pm.ПлательщикКорсчет = s;
                    }
                    z = line.Contains("ПолучательСчет=");
                    if (z)
                    {
                        s = line.Replace("ПолучательСчет=", "");
                        pm.ПолучательСчет = s;
                    }
                    z = line.Contains("ПолучательИНН="); 
                    if (z)
                    {
                        s = line.Replace("ПолучательИНН=", "");
                        pm.ПолучательИНН = s;
                    }
                    z = line.Contains("ПолучательКПП=");
                    if (z)
                    {
                        s = line.Replace("ПолучательКПП=", "");
                        pm.ПолучательКПП = s;
                    }
                    z = line.Contains("Получатель1=");
                    if (z)
                    {
                        s = line.Replace("Получатель1=", "");
                        pm.Получатель1 = s;
                    }
                    z = line.Contains("Получатель2=");
                    if (z)
                    {
                        s = line.Replace("Получатель2=", "");
                        pm.Получатель2 = s;
                    }
                    z = line.Contains("ПолучательРасчСчет=");
                    if (z)
                    {
                        s = line.Replace("ПолучательРасчСчет=", "");
                        pm.ПолучательРасчСчет = s;
                    }
                    z = line.Contains("ПолучательБанк1=");
                    if (z)
                    {
                        s = line.Replace("ПолучательБанк1=", "");
                        pm.ПолучательБанк1 = s;
                    }
                    z = line.Contains("ПолучательБанк2=");
                    if (z)
                    {
                        s = line.Replace("ПолучательБанк2=", "");
                        pm.ПолучательБанк2 = s;
                    }
                    z = line.Contains("ПолучательБИК=");
                    if (z)
                    {
                        s = line.Replace("ПолучательБИК=", "");
                        pm.ПолучательБИК = s;
                    }
                    z = line.Contains("ПолучательКорсчет=");
                    if (z)
                    {
                        s = line.Replace("ПолучательКорсчет=", "");
                        pm.ПолучательКорсчет = s;
                    }
                    z = line.Contains("ВидПлатежа=");
                    if (z)
                    {
                        s = line.Replace("ВидПлатежа=", "");
                        pm.ВидПлатежа = s;
                    }
                    z = line.Contains("ВидОплаты=");
                    if (z)
                    {
                        s = line.Replace("ВидОплаты=", "");
                        pm.ВидОплаты = s;
                    }
                    z = line.Contains("НазначениеПлатежа=");
                    if (z)
                    {
                        s = line.Replace("НазначениеПлатежа=", "");
                        pm.НазначениеПлатежа = s;
                    }




                    z = line.Contains("КонецДокумента");
                    if (z)
                    {

                        sect = false;
                        // bool isThere = db.Table<Payment>().Contains<Payment>(pm);
                        // if (isThere==false)
                        var pm2 = db.Table<Payment>();
                        bool fl = true;
                     //    foreach (var payment in pm2)
                     //     {
                            // if ((payment.НазначениеПлатежа == pm.НазначениеПлатежа) && (!payment.НазначениеПлатежа.Contains("Аванс")) &&(!payment.НазначениеПлатежа.Contains("НДФЛ за")) && (!payment.НазначениеПлатежа.Contains("Заработная"))) fl = false;
                           //fl = false;
                     //   }

                        if (fl) db.Insert(pm);
                        i++;
                    }
                    
                }
                //System.Diagnostics.Debug.WriteLine(line);
            }

            Text_Start_Date_Extract.Text = Convert.ToString(summ)+" - " + Convert.ToString(fr);
            db.Dispose();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new SQLiteConnection("bd_vester.db", true);
//            db.DropTable<Payment>();
            db.CreateTable<Payment>();
            db.Dispose();
        }
    }
}
