using System;
using System.Net;

namespace ICarros.Crawler.Robo
{
    public class RoboWebClient : WebClient
    {

        public CookieContainer _cookie = new CookieContainer();
        public bool _allowAutoRedirect;


        protected override WebRequest GetWebRequest(Uri address)
        {

            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).ServicePoint.Expect100Continue = false;
                (request as HttpWebRequest).CookieContainer = _cookie;
                (request as HttpWebRequest).KeepAlive = false;
                (request as HttpWebRequest).AllowAutoRedirect = _allowAutoRedirect;
            }

            return request;
        }
    }
}
