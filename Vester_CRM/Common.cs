using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace Common
{
    class Prg_Par
    {

        public string path;
        public string out_str;
        public async Task SavePrgFile(string filename)
        {

            string content = "";
            content += "ПутьКБазе="; content += path; content += "\n"; //Количество смен
                                                                      /*            content += "SmenaHour="; content += Convert.ToString(this.SmenaHour); content += ";\n"; // Начало первой смены - час
                                                                                  content += "SmenaMinute="; content += Convert.ToString(this.SmenaMinute); content += ";\n"; //Минуты начала первой смены 0 - 0минут, 1 - 30 минут.
                                                                                  content += "ComAdress="; content += Convert.ToString(this.ComAdress); content += ";\n"; //Минуты начала первой смены 0 - 0минут, 1 - 30 минут.
                                                                                  content += "ComBaud="; content += Convert.ToString(this.ComBaud); content += ";\n"; //Минуты начала первой смены 0 - 0минут, 1 - 30 минут.
                                                                                  content += "ComMode="; content += Convert.ToString(this.ComMode); content += ";\n"; //Минуты начала первой смены 0 - 0минут, 1 - 30 минут.
                                                                                  content += "ComDevice="; content += Convert.ToString(this.ComDevice); content += ";\n"; //Минуты начала первой смены 0 - 0минут, 1 - 30 минут.
                                                                                  content += "ComMonitor="; content += Convert.ToString(this.ComMonitor); content += ";\n"; //Минуты начала первой смены 0 - 0минут, 1 - 30 минут.
                                                                      */
            content = content.Replace(",", ".");

            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(content.ToCharArray());

            // create a file with the given filename in the local folder; replace any existing file with the same name
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

            // write the char array created from the content string into the file
            using (var stream = await file.OpenStreamForWriteAsync())
            {
                stream.Write(fileBytes, 0, fileBytes.Length);
            }


        }
        public async System.Threading.Tasks.Task OpenPrgFile(string fileName)
        {
            string s;
            StorageFile file;
            var _folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            file = await _folder.GetFileAsync(fileName);

            var lines = await Windows.Storage.FileIO.ReadLinesAsync(file);

            out_str = "";
            if (file != null)
            {
                foreach (var line in lines)
                {
                    if (line.Contains("ПутьКБазе="))
                    {
                        s = line.Replace("ПутьКБазе=", "");
                        this.path = s;
//                            pm.Номер = Convert.ToInt32(s);
                    }

                }

            }
            else
            {
                await SavePrgFile(fileName);
            }

        }

    }
}
