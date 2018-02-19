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
//using SQLite;
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

  //          var db = new SQLiteConnection("filename.db", true);
            // do your work here
            //db.Dispose();
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

            foreach (var line in lines)
            {
                // Строки будут выводиться в окне Output Visual Studio
                // с ними можно делать все, что угодно
                Text_Start_Date_Extract.Text = line;
                //System.Diagnostics.Debug.WriteLine(line);
            }


        }
    }
}
