using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Text_Regex02
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://strela.in.ua/katalog/mossberg/falsh_patrony_12k2/";

            Console.WriteLine("_______all________");
            string all = GetTextFromHtmlPage(url);
            Console.WriteLine(all);

            Console.WriteLine("_____links_______");
            string links = GetAllLinks(all);
            Console.WriteLine(links);

            Console.WriteLine("______pfones____");
            string pfones = GetAllTel(all);
            Console.WriteLine(pfones);

            Console.WriteLine("_______mails________");
            string mails = GetAllEmails(all);
            Console.WriteLine(mails);

            var file = new FileInfo(@"D:\text.txt");
            FileStream stream = file.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(links, pfones);
            writer.Write(pfones);
            writer.Write(mails);
            writer.Close();

        }

        public static string GetTextFromHtmlPage(string src)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(src);
            HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
            string html;
            using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default))
                html = sr.ReadToEnd();
            html = html.Trim();
            return html;
        }

        public static string GetAllLinks(string src)
        {
            Regex reg = new Regex(@"(http://.\S+.\d+?)");
            string links = "";
            MatchCollection collect_math = reg.Matches(src);
            foreach (Match a in collect_math)
            {
                links += Convert.ToString(a + "\n");
            }
            return links;
        }

        public static string GetAllTel(string src)
        {
            Regex reg = new Regex(@"\(0\d+\)\s\d+\s\d+\s\d+");
            string pfones = "";
            MatchCollection collect_math = reg.Matches(src);
            foreach (Match a in collect_math)
            {
                pfones += Convert.ToString(a + "\n");
            }
            return pfones;
        }

        public static string GetAllEmails(string src)
        {
            Regex reg = new Regex
                (@"([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}");
            string mails = "";
            MatchCollection collect_math = reg.Matches(src);
            foreach (Match a in collect_math)
            {
                mails += Convert.ToString(a + "\n");
            }
            return mails;
        }
    }
}
