using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICarros.Crawler.Robo
{
    public class Robo
    {
        public RoboWebClient RoboWebClient { get; set; }

        public HtmlDocument HttpGet(string url)
        {
            lock (this)
            {
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(RoboWebClient.DownloadString(url));

                return htmlDocument;
            }
        }


        public HtmlDocument HttpPost(string url, NameValueCollection parametros)
        {

            var htmlDocument = new HtmlDocument();
            byte[] pagina = RoboWebClient.UploadValues(url, parametros);
            htmlDocument.LoadHtml(Encoding.Default.GetString(pagina, 0, pagina.Count()));

            return htmlDocument;
        }
    }
}
