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
using System.Text;

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
    class Settings
    {
        [PrimaryKey, AutoIncrement, Unique]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Путь { get; set; }

    }
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
        public void Empty()
        {
            НазначениеПлатежа = null;
            Дата = null;
            ПлательщикСчет = null;
            ДатаСписано = null;
            ДатаПоступило = null;
            ПлательщикИНН = null;
            ПлательщикКПП = null;
            Плательщик1 = null;
            Плательщик2 = null;
            ПлательщикРасчСчет = null;
            ПлательщикБанк1 = null;
            ПлательщикБанк2 = null;
            ПлательщикБИК = null;
            ПлательщикКорсчет = null;
            ПолучательСчет = null;
            ПолучательИНН = null;
            ПолучательКПП = null;
            Получатель1 = null;
            Получатель2 = null;
            ПолучательРасчСчет = null;
            ПолучательБанк2 = null;
            ПолучательБанк1 = null;
            ПолучательБИК = null;
            ПолучательКорсчет = null;
            ВидПлатежа = null;
            ВидОплаты = null;
        }

    }
    class Company
    {
      //  [AutoIncrement, Unique]
       // public int Id { get; set; }
        [PrimaryKey, Unique, NotNull, MaxLength(50)]
        public string Название1 { get; set; }
        [MaxLength(50)]
        public string Название2 { get; set; }
        [MaxLength(30)]
        public string ИНН { get; set; }
        [MaxLength(15)]
        public string КПП { get; set; }
        [MaxLength(50)]
        public string РасчСчет { get; set; }
        [MaxLength(50)]
        public string Банк1 { get; set; }
        [MaxLength(50)]
        public string Банк2 { get; set; }
        [MaxLength(15)]
        public string БИК { get; set; }
        [MaxLength(30)]
        public string Корсчет { get; set; }
        [MaxLength(50)]
        public string Телефон { get; set; }
        [MaxLength(50)]
        public string Мыло { get; set; }
        [MaxLength(150)]
        public string ЮрАдрес { get; set; }
        [MaxLength(150)]
        public string ФактАдрес { get; set; }

        [MaxLength(50)]
        public string КонтЛицоИмя { get; set; }
        [MaxLength(50)]
        public string КонтЛицоТелефон { get; set; }
        [MaxLength(50)]
        public string КонтЛицоМыло { get; set; }
        public void Empty()
        {
            Название1 = null;
            Название1 = null;
            ИНН = null;
            КПП = null;
            РасчСчет = null;
            Банк1 = null;
            Банк2 = null;
            БИК = null;
            Корсчет = null;
            Телефон = null;
            Мыло = null;
            ЮрАдрес = null;
            ФактАдрес = null;
            КонтЛицоИмя = null;
            КонтЛицоТелефон = null;
            КонтЛицоМыло = null;
        }

    }



    public sealed partial class MainPage : Page
    {
        private Common.Prg_Par param;
        private string param_filename="prg.ini";

        public async System.Threading.Tasks.Task InitPrg()
        {
        // param.SmenaHour = 0;
        // param.SmenaMinute = 0;
        // param.SmenaNum = 0;
        //  
            try
            {
                await param.OpenPrgFile(param_filename);
            }
            catch
            {
                await param.SavePrgFile(param_filename);
            }
        }


        private void Company_To_List()
        {
            var db = new SQLiteConnection("bd_vester.db", true);
            var company = new Company();
            var pm2 = db.Table<Company>();
            foreach (var comp in pm2)
            {
                List_Company_Name.Items.Add(comp.Название1);
            }
            db.Dispose();

        }
        private void Make_Company()
        {
            var db = new SQLiteConnection("bd_vester.db", true);
            var pm = new Payment();
            var company = new Company();
            var pm2 = db.Table<Payment>();
            //  var cm2 = db.Table<Company>();
            bool fl = true;


            foreach (var payment in pm2)
            {

                if (payment.ДатаПоступило != null)
                {
                    company.Название1 = payment.Плательщик1;
                    company.Название2 = payment.Плательщик2;
                    company.ИНН = payment.ПлательщикИНН;
                    company.КПП = payment.ПлательщикКПП;
                    company.РасчСчет = payment.ПлательщикРасчСчет;
                    company.Банк1 = payment.ПлательщикБанк1;
                    company.Банк2 = payment.ПлательщикБанк2;
                    company.БИК = payment.ПлательщикБИК;
                    company.Корсчет = payment.ПлательщикКорсчет;
                    if (fl) db.InsertOrReplace(company);
                    company.Empty();

                }
            }
            db.Dispose();
        }



        public MainPage()
        {
            this.InitializeComponent();
            param = new Common.Prg_Par();
            //           Grab_Entries();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await InitPrg();

            PathToBase.Text = param.path;

            // Windows.Storage.StorageFolder storageFolder = @"D:\temp";

            //true для добавления данных в файл. false Перезаписать файл. Если указанный файл не существует, этот параметр не действует и конструктор создает новый файл.



            var db = new SQLiteConnection("bd_vester.db", true);
            db.DropTable<Payment>();
            db.CreateTable<Payment>();
            db.CreateTable<Company>();
            Make_Company();
            db.Dispose();
            Company_To_List();


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
                        if (s!="") fr += pm.Сумма;
                    }
                    z = line.Contains("ДатаПоступило=");
                    if (z)
                    {
                        s = line.Replace("ДатаПоступило=", "");
                        pm.ДатаПоступило = s;
                        if (s != "") summ += pm.Сумма;

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
                        pm.НазначениеПлатежа += " Номер:" + pm.Номер;

                            foreach (var payment in pm2)
                             {
                            // if ((payment.НазначениеПлатежа == pm.НазначениеПлатежа) && (!payment.НазначениеПлатежа.Contains("Аванс")) &&(!payment.НазначениеПлатежа.Contains("НДФЛ за")) && (!payment.НазначениеПлатежа.Contains("Заработная"))) fl = false;
                            if ((payment.НазначениеПлатежа == pm.НазначениеПлатежа)) fl = false;
                           }

                        if (fl) db.Insert(pm);
                        pm.Empty();
                        
                        i++;
                    }
                    
                }
                //System.Diagnostics.Debug.WriteLine(line);
            }

            Text_Start_Date_Extract.Text = Convert.ToString(summ)+" - " + Convert.ToString(fr);
            db.Dispose();
        }


        private void Button_Company_Click(object sender, RoutedEventArgs e)
        {
            Grid_Main_Company.Visibility = Visibility.Visible;
            Grid_Main_Account.Visibility = Visibility.Collapsed;
            Grid_Main_Settings.Visibility = Visibility.Collapsed;
        }

        private void Button_Account_Click(object sender, RoutedEventArgs e)
        {
            Grid_Main_Company.Visibility = Visibility.Collapsed;
            Grid_Main_Account.Visibility = Visibility.Visible;
            Grid_Main_Settings.Visibility = Visibility.Collapsed;

        }
        private void Button_Settings_Click(object sender, RoutedEventArgs e)
        {
            Grid_Main_Company.Visibility = Visibility.Collapsed;
            Grid_Main_Account.Visibility = Visibility.Collapsed;
            Grid_Main_Settings.Visibility = Visibility.Visible;

        }

        private void List_Company_Name_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (List_Company_Name.SelectedIndex!=-1)
            {

                var db = new SQLiteConnection("bd_vester.db", true);
                  var cm = db.Get<Company>(List_Company_Name.SelectedItem);

                if (cm.Название1 != null) Название1.Text = cm.Название1;
                else Название1.Text = "";
                if (cm.Название2 != null) Название2.Text = cm.Название2;
                else Название2.Text = "";
                if (cm.ИНН != null) ИНН.Text = cm.ИНН;
                else ИНН.Text = "";
                if (cm.КПП != null) КПП.Text = cm.КПП;
                else КПП.Text = "";
                if (cm.РасчСчет != null) РасчСчет.Text = cm.РасчСчет;
                else РасчСчет.Text = "";
                if (cm.Банк1 != null) Банк1.Text = cm.Банк1;
                else Банк1.Text = "";
                if (cm.Банк2 != null) Банк2.Text = cm.Банк2;
                else Банк2.Text = "";
                if (cm.БИК != null) БИК.Text = cm.БИК;
                else БИК.Text = "";
                if (cm.Корсчет != null) Корсчет.Text = cm.Корсчет;
                else Корсчет.Text = "";
                if (cm.Телефон != null) Телефон.Text = cm.Телефон;
                else Телефон.Text = "";
                if (cm.Мыло != null) Мыло.Text = cm.Мыло;
                else Мыло.Text = "";
                if (cm.ФактАдрес != null) ФактАдрес.Text = cm.ФактАдрес;
                else ФактАдрес.Text = "";
                if (cm.ЮрАдрес != null) ЮрАдрес.Text = cm.ЮрАдрес;
                else ЮрАдрес.Text = "";
                if (cm.КонтЛицоИмя != null) КонтЛицоИмя.Text = cm.КонтЛицоИмя;
                else КонтЛицоИмя.Text = "";
                if (cm.КонтЛицоТелефон != null) КонтЛицоТелефон.Text = cm.КонтЛицоТелефон;
                else КонтЛицоТелефон.Text = "";
                if (cm.КонтЛицоМыло != null) КонтЛицоМыло.Text = cm.КонтЛицоМыло;
                else КонтЛицоМыло.Text = "";


                db.Dispose();
            }
        }

        private async void Button_PathToBase_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add(".txt");

            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder (including other sub-folder contents)
                // StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                // OutputTextBlock.Text = "Picked folder: " + folder.Name;
                PathToBase.Text = folder.Path;
                param.path = folder.Path;
                await param.SavePrgFile(param_filename);

            }
            else
            {
               // OutputTextBlock.Text = "Operation cancelled.";
            }
        }
    }
}
