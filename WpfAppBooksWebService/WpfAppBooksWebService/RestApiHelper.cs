using System.Windows;
using System.Net;
using System.IO;


namespace WpfAppBooksWebService
{
    class RestApiHelper
    {
        public void HelloWorld()
        {
            
            string baseUrl = "https://openlibrary.org/api/books?bibkeys=";
            string requestUrl = baseUrl + "asdfelchenschmelchen";
            MessageBox.Show(requestUrl);
        }


        public string requestISBN(string isbn)
        {
            string baseUrl = "https://openlibrary.org/api/books?bibkeys=";
            string requestUrl = baseUrl + isbn + "&format=json";

            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;

            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            return content;
        }
    }
}
