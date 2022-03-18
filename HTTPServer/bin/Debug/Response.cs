using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace HTTPServer
{

    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
        NotFound = 404,
        BadRequest = 400,
        Redirect = 301
    }

    class Response
    {
        string responseString;
        public string ResponseString
        {
            get
            {
                return responseString;
            }
        }
        StatusCode code;
        List<string> headerLines = new List<string>();
        public Response(StatusCode code, string contentType, string content, string redirectoinPath)
        {
            // throw new NotImplementedException();
            // TODO: Add headlines (Content-Type, Content-Length,Date, [location if there is redirection])
            Console.WriteLine("response");
            headerLines.Add(contentType);
            headerLines.Add(content.Length.ToString());
            headerLines.Add(DateTime.Now.ToString("ddd, dd MMM yyy HH : mm ss "));
            string status = GetStatusLine(code);
            if (code == StatusCode.Redirect) {
                headerLines.Add(redirectoinPath);
                responseString = status + "\r\n" + "content type: "+headerLines[0] + "\r\n" + "content length: " + headerLines[1] + "\r\n" + "content date: "+ headerLines[2]+ "redirection path:"+ headerLines[3] + "\r\n"+ "\r\n" + "content: " + content;
            }
            else
                responseString = status + "\r\n" + "content type: " + headerLines[0] + "\r\n" + "content length: " + headerLines[1] + "\r\n" + "content date: " + headerLines[2] + "\r\n" + "\r\n" + "content: " + content;



            Console.WriteLine("responseString: " + responseString);




        }

        private string GetStatusLine(StatusCode code)
        {
            // TODO: Create the response status line and return it
            string statusLine = "";
               
            if (code == StatusCode.OK)
                statusLine = "HTTP/1.1"+" "+ 200 + " "+"ok";
            else if (code == StatusCode.Redirect)
                statusLine = "HTTP/1.1" + " " + 300 + " " + "Redirect";
            else if (code == StatusCode.BadRequest)
                statusLine = "HTTP/1.1" + " " + 400 + " " + "Bad Request";
            else if (code == StatusCode.InternalServerError) 
                statusLine = "HTTP/1.1" + " " + 500 + " " + "Internal Server Error";
            else if (code == StatusCode.NotFound)
                statusLine = "HTTP/1.1" + " " + 404 + " " +"not found";

           // Console.WriteLine("statusLine" + statusLine);

            return statusLine;
        }
    }
}
