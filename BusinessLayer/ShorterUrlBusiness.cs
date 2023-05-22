using DataLayer.Interfaces;
using DataLayer.Repos;
using DTO;
using System;

namespace BusinessLayer
{
    public class ShorterUrlBusiness : IShorterUrlBusinessInterface
    {
        private readonly IShorterUrl _shorterUrl;

        public ShorterUrlBusiness(IShorterUrl shorterUrl)
        {
            _shorterUrl = shorterUrl;
        }
        public ShorterUrlResponse? CheckUrl(string url)
        {
            var getDbResponse = _shorterUrl.GetRedirectUrl(url);

            if(getDbResponse== null)
            {
                return null;
            }

            return BindResponseData(getDbResponse.Url, getDbResponse.ShortUrl);

        }
        public ShorterUrlResponse SaveShorterUrl(string url, string baseUrl)
        {
            string shortUrl = baseUrl + GetRandomUrl();
            var getDbResponse = _shorterUrl.SaveUrl(url,shortUrl);

            return BindResponseData(getDbResponse.Url, getDbResponse.ShortUrl);

        }

        public ShorterUrlResponse SaveShorterUrl(string url, string baseUrl,string customUrl)
        {
            string shortUrl = baseUrl + customUrl;
            var getDbResponse = _shorterUrl.SaveUrl(url, shortUrl);

            return BindResponseData(getDbResponse.Url, getDbResponse.ShortUrl);

        }

        public bool ControlUrlIsOk(string url)
        {
            Uri validatedUri;

            if (Uri.TryCreate(url, UriKind.Absolute, out validatedUri)) 
            {
                return (validatedUri.Scheme == Uri.UriSchemeHttp || validatedUri.Scheme == Uri.UriSchemeHttps);
            }
            return false;
        }

        private ShorterUrlResponse BindResponseData(string url, string shortUrl)
        {
            ShorterUrlResponse resp = new ShorterUrlResponse();
            resp.Url = url;
            resp.ShortUrl = shortUrl;
            return resp;
        }

      

        private string GetRandomUrl()
        {
            var chars = "qwertyuoasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        private bool HasSpecialChars(string customUrl)
        {
            return customUrl.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private bool ValidLength(string customUrl)
        {
            return customUrl.Length >0 && customUrl.Length <= 6;
        }

        public bool ControlCustomUrl(string customUrl)
        {
            if (HasSpecialChars(customUrl))
            {
                return false;
            }
            else if(!ValidLength(customUrl))
            {
                return false;
            }

            return true;
        }
    }
}
