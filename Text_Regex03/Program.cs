using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Text_Regex03
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFromFile;
            using (FileStream fstream = File.OpenRead(@"D:\test\text2.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine(textFromFile);
            }

            Regex reg = new Regex(@"^|\W\w{1,2}\W"); //все предлоги скорее всего не возможно выбрать. Они бывают длинее слов. их нужно конкретно перечислить? 

            string dst = reg.Replace(textFromFile, "GAW ");
            Console.WriteLine(dst);
        }
    }
}
