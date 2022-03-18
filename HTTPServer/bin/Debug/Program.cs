using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Call CreateRedirectionRulesFile() function to create the rules of redirection 
            CreateRedirectionRulesFile();
            string filePath = @"F:\Computer Science ASU\education\Third\first semester\new\CN\project\Template[2021-2022]\HTTPServer\bin\Debug\redirectionRules.txt";
            Server httpserver = new Server(1000, filePath);
            httpserver.StartServer();
            //Start server
            // 1) Make server object on port 1000
            // 2) Start Server
        }

        static void CreateRedirectionRulesFile()
        {
            // TODO: Create file named redirectionRules.txt
            // each line in the file specify a redirection rule
            // example: "aboutus.html,aboutus2.html"
            // means that when making request to aboustus.html,, it redirects me to aboutus2
            FileStream fs = new FileStream(@"F:\Computer Science ASU\education\Third\first semester\new\CN\project\Template[2021-2022]\HTTPServer\bin\Debug\redirectionRules.txt", FileMode.OpenOrCreate);
            StreamWriter fw = new StreamWriter(fs);
            fw.WriteLine(@"aboutus.html,aboutus2.html");
            fw.Close();
        }

    }
}