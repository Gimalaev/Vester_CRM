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
    

    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            this.InitializeComponent();

 //           Grab_Entries();
        }

        private async void Button_Extract_Account_Click(object sender, RoutedEventArgs e)
        {

            FileOpenPicker openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.Desktop,
                CommitButtonText = "Открыть выписку"
            };
            openPicker.FileTypeFilter.Add(".txt");
            var file = await openPicker.PickSingleFileAsync();
            var lines = await Windows.Storage.FileIO.ReadLinesAsync(file);
            //еук
            foreach (var line in lines)
            {
                // Строки будут выводиться в окне Output Visual Studio
                // с ними можно делать все, что угодно
                Text_Start_Date_Extract.Text = line;
                //System.Diagnostics.Debug.WriteLine(line);
            }
          /*  using (SqliteConnection db = new SqliteConnection(string.Format("Data Source={0};", @"D:\sqliteSample.db")))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                //Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", Text_Start_Date_Extract.Text);

                try
                {
                    insertCommand.ExecuteReader();
                }
                catch (SqliteException error)
                {
                    //Handle error
                    return;
                }
                db.Close();
            }
            Output.ItemsSource = Grab_Entries();*/
        }
  /*      private List<String> Grab_Entries()
        {
            List<String> entries = new List<string>();
        //
        //  const string databaseName = @"D:\test.db";
        // using (SqliteConnection db = new SqliteConnection(string.Format("Data Source={0};", databaseName))
        using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from MyTable", db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                }
                catch (SqliteException error)
                {
                    //Handle error
                    return entries;
                }
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }
        */
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new SQLiteConnection("bd_vester.db", true);
            // do your work here
            db.Dispose();
        }
    }
}
