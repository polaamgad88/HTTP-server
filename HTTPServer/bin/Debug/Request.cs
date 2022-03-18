using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace HTTPServer
{
    public enum RequestMethod
    {
        GET,
        POST,
        HEAD
    }

    public enum HTTPVersion
    {
        HTTP10,
        HTTP11,
        HTTP09
    }

    class Request
    {
        string[] requestLines;
        RequestMethod method = RequestMethod.GET;
   
        public string relativeURI;
        
        Dictionary<string, string> headerLines= new Dictionary <string, string>();

        public Dictionary<string, string> HeaderLines
        {
            get { return headerLines; }
        }

        HTTPVersion httpVersion = HTTPVersion.HTTP10;




        string requestString;
      
        string[] contentLines;
      


        public Request(string requestString)
        {
            this.requestString = requestString;
           
        }

        /// <summary>
        /// Parses the request string and loads the request line, header lines and content, returns false if there is a parsing error


        /// </summary>
        /// <returns>True if parsing succeeds, false otherwise.</returns>
        public bool ParseRequest()
        {
            bool isRequestValid = true;

            // throw new NotImplementedException();
            // Console.WriteLine("parse request");
          

            //TODO:parse the recieved request using \r\n  delimeter
            string[] sp = new string[] { "\r\n" };
            requestLines = requestString.Split(sp, StringSplitOptions.None);
           // Console.WriteLine("requestString " + requestString);

            // check that there is atleast 3 lines: Request line, Host Header, Blank line (usually 4 lines with the last empty line for empty content)

            int counter = 0;


            //for (int j = 0; j < requestString.Length; j++)
            //{
            //    if (requestString[j].Equals("\r\n"))
            //    {
            //        counter++;
            //    }

            //}
            //if (counter < 3)
            //{

            //    Console.WriteLine("there is should atleast 3 lines");
            //}

          
           
           
            // Parse Request line
            ParseRequestLine();


            // Validate blank line exists
             ValidateBlankLine();


            // Load header lines into HeaderLines dictionary
            LoadHeaderLines();
            //Console.WriteLine("request string is" , requestString);
            //Console.WriteLine("request line is", requestLines[0]);
            return true;
        }
       
        private bool ParseRequestLine()
        {
            Console.WriteLine("parse requestline strt \n ");
            bool isSuported = true;
            //Console.WriteLine("parse request line");
            // throw new NotImplementedException()

            int l = requestString.Length;
            Console.WriteLine("request line " + requestLines[0]);
            string[] requestLine = requestLines[0].Split(' ');
           

        
            string request_method = requestLine[0];
           // Console.WriteLine("method: " + request_method);
            //Console.WriteLine("this method is not suported", request_method);
            if (request_method != "GET ")
            {
               // isSuported = false;
               // Console.WriteLine("this method is not suported");
            }
            //string []s = requestLine[1].Split('/');

            // relativeURI = s[1];
            relativeURI = requestLine[1];
            Console.WriteLine("relativeURI: " + relativeURI);
           // string request_method = requestLine[0];
            string request_httpVersion = requestLine[2];
            Console.WriteLine("request_httpVersion: " + request_httpVersion);
            if (request_httpVersion != "HTTP/1.1") {
               // isSuported = false;
                Console.WriteLine("this version is not suported");
            }
            //Console.WriteLine("request string is", requestString);
            //Console.WriteLine("request line is", requestLines[0]);

            return true;

        }

        private bool ValidateIsURI(string uri)
        {
            return Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute);
        }

        int index = 0;
        private bool LoadHeaderLines()
        {
           // Console.WriteLine("load header");

            int i = 0;
            
            string[] sp2 = { ": " };
            while (!string.IsNullOrEmpty(requestLines[i])) {
                string header_content = requestLines[i];
                string[] data = header_content.Split(sp2,StringSplitOptions.None);
                // header name and header value 
                headerLines.Add(data[0], data[1]);
                i++;
                index = i;


            }
           



            return true;
        }

        private bool ValidateBlankLine()
        {
            //throw new NotImplementedException();
           // Console.WriteLine("blank line");

            if (string.IsNullOrEmpty(requestLines[index]))
            {



              
              //  Console.WriteLine("blank line exists");
                return true;

            }
            else
            {
                //Console.WriteLine("blank line does not exists");

                return false;
            }



        }


    }

}
