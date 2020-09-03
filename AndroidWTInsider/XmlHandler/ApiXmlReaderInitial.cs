using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidWTInsider.XmlHandler
{
    public class ApiXmlReaderInitial
    {
        public XmlReader ApiXmlReader(string URL)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US\r\n");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36\r\n";
            request.Accept = "text/html,application/xhtml+xml,application/xml\r\n";

            WebResponse response = request.GetResponse();
            XmlReader xReader = XmlReader.Create(response.GetResponseStream());
            return xReader;
        }
    }
}