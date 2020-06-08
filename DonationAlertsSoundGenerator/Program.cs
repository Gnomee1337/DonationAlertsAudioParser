using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Web;

namespace DonationAlertsSoundGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            string url;
            string filename;

            string randomNewDirectory = "DonationAlertSounds" + DateTime.Now.ToString("dd.MM.yyyyInhh-mm-ss");
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            Directory.CreateDirectory(@currentDirectory + @randomNewDirectory);

            WebClient client = new WebClient();
            HttpWebRequest webRequest;
            HttpWebResponse response;

            while (true)
            {

                url = "https://static.donationalerts.ru/audiodonations/";
                string tempurl = "6" + rnd.Next(4, 6).ToString() + rnd.Next(111, 999).ToString();
                url += tempurl + '/' + tempurl + rnd.Next(111, 999).ToString();
                url += ".wav";
				

                filename = url.Split('/').Last();

                webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                response = (HttpWebResponse)webRequest.GetResponse();
                if ((int)response.StatusCode == 200)
                {
                    Console.WriteLine(url + " - Valid");
                    client.DownloadFile(new Uri(url), currentDirectory + randomNewDirectory + "\\" + filename);
                }
                else
                {
                    Console.WriteLine(url + " - Invalid");
                }
            }
        }
    }
}