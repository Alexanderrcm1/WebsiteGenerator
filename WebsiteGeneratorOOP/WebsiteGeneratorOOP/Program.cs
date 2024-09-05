﻿using System.Xml;

namespace WebsiteGeneratorOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebsiteGenerator myWebsite = new WebsiteGenerator();

            myWebsite.ClassSpecificHtml("Klass1", "Välkomna hit!");
        }
    }

    class WebsiteGenerator
    {

        public void OutputHtml()
        {
            Console.WriteLine("<!DOCTYPE html>");
            Console.WriteLine("<html>");
            Console.WriteLine("<body>");
            Console.WriteLine("<h1>Välkomna!</h1>");
            Console.WriteLine("<main>");
            Console.WriteLine("<p>Kurs om C#</p>");
            Console.WriteLine("<p>Kurs om Databaser</p>");
            Console.WriteLine("</main>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }

        public void ClassSpecificHtml(string klassnamn, string klassmeddelande)
        {
            Console.WriteLine("<!DOCTYPE html>");
            Console.WriteLine("<html>");
            Console.WriteLine("<body>");
            Console.WriteLine($"<h1>Välkomna {klassnamn}!</h1>");
            Console.WriteLine($"<p><b>Meddelande:</b> {klassmeddelande}.</p>");
            Console.WriteLine("<main>");
            Console.WriteLine("<p>Kurs om C#</p>");
            Console.WriteLine("<p>Kurs om Databaser</p>");
            Console.WriteLine("</main>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }

        public void ClassSpecificHtml(string klassnamn, int antal)
        {
            Console.WriteLine("<!DOCTYPE html>");
            Console.WriteLine("<html>");
            Console.WriteLine("<body>");
            Console.WriteLine($"<h1>Välkomna {klassnamn}!</h1>");

            for (int i = 0; i < antal; i++)
            {
                Console.Write($"Meddelande {i}: ");
                Console.WriteLine($"<p><b>Meddelande:</b> {Console.ReadLine()}.</p>");
            }
            Console.WriteLine("<main>");
            Console.WriteLine("<p>Kurs om C#</p>");
            Console.WriteLine("<p>Kurs om Databaser</p>");
            Console.WriteLine("</main>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
        }
    }
}
