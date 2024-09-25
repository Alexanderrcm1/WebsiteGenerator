using System.IO.Enumeration;
using System.Transactions;
using System.Xml;

namespace WebsiteGeneratorOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\acarl\\Desktop\\ITHS\\Programmering C#\\Övningsuppgifter\\WebsiteGenerator\\WebsiteGeneratorOOP\\WebsiteGeneratorOOP";
            string fileName = "test.txt";

            string[] html = { "<!DOCTYPE html>", "<html>", "<body>", "<h1>Välkomna!</h1>", "<main>", "<p>Kurs om C#</p>", "<p>Kurs om Databaser</p>", "</main>", "</body>", "</html>" };

            menu();
            int choice = getMenuChoice();
            IUser? user = null;

            switch(choice)
            {
                case 1:
                    user = new ConsoleDisplayer();
                    break;
                case 2:
                    user = new FileMaker(path, fileName);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }


            WebsiteGenerator myWebsite = new WebsiteGenerator();
            string standardHtml = myWebsite.GetStandardHtml(html);
            user?.Output(standardHtml);

            //string classSpecificHtml = myWebsite.GetClassSpecificHtml(html, "Klass 1", "Välkommna hit!");
            //string classSpecificHtml2 = myWebsite.GetClassSpecificHtml(html, "Klass 1", 4);
            //Console.WriteLine(standardHtml);

            //displayer.Output(classSpecificHtml2);

            //Console.WriteLine(myWebsite.GetClassSpecificHtml(html, "Klass1", 4));

            //string ogHtml = myWebsite.OutputHtml();
            //Console.WriteLine(ogHtml);

            //Console.WriteLine(myWebsite.GetHtml(html));
        }

        static void menu()
        {
            string[] menuString = { "=====MENU=====", "1. Print html to console.", "2. Save html on file.", "3. Exit." };

            foreach (string item in menuString)
            {
                Console.WriteLine(item);
            }
        }

        static int getMenuChoice()
        {
            while(true)
            if (int.TryParse(Console.ReadLine() , out int choice))
            {
                    if (choice > 0 && choice < 4)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("Enter a number between 1 - 3\nTry again");
                    }
            }
            else
            {
                Console.WriteLine("You have to enter a number!\nTry again");
            }
        }
    }
    interface IUser
    {
        public void Output(string html);
    }

    class FileMaker : IUser
    {
        public string Pathh
        {
            get; private set;
        }

        public string FileName
        {
            get; private set;
        }

        public string FullPath
        {
            get; private set;
        }

        public FileMaker(string path, string fileName)
        {
            Pathh = path;
            FileName = fileName;
            FullPath = Pathh + "\\" + FileName;
        }
        public void Output(string html)
        {
            try
            {
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                    Console.WriteLine($"File: {FileName} deleted!");
                }

                using(FileStream fileStr = File.Create(FullPath))
                {
                    Console.WriteLine($"File: {FileName} successfully created!");
                }
                using(StreamWriter sw = new StreamWriter(FullPath))
                {
                    sw.WriteLine(html);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class ConsoleDisplayer : IUser
    {
        public void Output(string html)
        {
            Console.WriteLine(html);
        }
    }
    class WebsiteGenerator
    {
        public string GetStandardHtml(string[] html)
        {
            string fullHtml = "";
            foreach (string s in html)
            {
                fullHtml += $"{s}\n";
            }
            return fullHtml;
        }

        public string GetClassSpecificHtml(string[] html, string klassnamn, string klassmeddelande)
        {
            string fullHtml = "";
            foreach (string s in html)
            {
                if (s == "<h1>Välkomna!</h1>")
                {
                    fullHtml += $"<h1>Välkomna {klassnamn}!</h1>\n";
                    fullHtml += $"<p><b>Meddelande:</b> {klassmeddelande}.</p>\n";
                }
                else
                {
                    fullHtml += $"{s}\n";
                }

            }
            return fullHtml;
        }

        public string GetClassSpecificHtml(string[] html, string klassnamn, int antal)
        {
            string fullHtml = "";
            foreach (string s in html)
            {
                if (s == "<h1>Välkomna!</h1>")
                {
                    fullHtml += $"<h1>Välkomna {klassnamn}!</h1>\n";
                    for (int i = 0; i < antal; i++)
                    {
                        Console.Write($"Meddelande {i + 1}: ");
                        fullHtml += $"<p><b>Meddelande:</b> {Console.ReadLine()}.</p>\n";
                    }
                }
                else
                {
                    fullHtml += $"{s}\n";
                }

            }
            return fullHtml;
        }
    }
}
