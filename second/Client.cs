using System;
using System.Net;
using System.Text;
using Exception = System.Exception;

namespace HTTPClient
{
    public class Client
    {
        public bool Ping(string link)
        {
            var client = new WebClient();
            try
            {
                client.DownloadString(link);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public string GetInputData(string link)
        {
            var client = new WebClient();
            try
            {
                return client.DownloadString(link);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool WriteAnswer(string link, string answer)
        {
            var client = new WebClient();
            var sendString = Encoding.UTF8.GetBytes(answer);
            try
            {
                client.UploadData(link, sendString);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Status);
                if (e.Response is HttpWebResponse response)
                {
                    if ((int)response.StatusCode == 302)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
