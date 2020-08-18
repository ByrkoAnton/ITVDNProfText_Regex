using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Text_Regex04
{
    class Program
    {
        static void Main(string[] args)//не то потом доделаю. Не зашли эти форматы. 
        {
            string textFromFile;
            using (FileStream fstream = File.OpenRead(@"D:\test\bill.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine(textFromFile);
            }

            var cultureInfo = new CultureInfo("de-DE");
            string dateString = textFromFile;
            var dateTime = DateTime.Parse(dateString, cultureInfo);
            Console.WriteLine(dateTime);
        }
    }
}
