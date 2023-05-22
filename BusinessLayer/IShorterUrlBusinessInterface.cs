using DTO;

namespace BusinessLayer
{
    public interface IShorterUrlBusinessInterface
    {
        public ShorterUrlResponse? CheckUrl(string url);
        ShorterUrlResponse SaveShorterUrl(string url, string baseUrl);
        public ShorterUrlResponse SaveShorterUrl(string url, string baseUrl, string customUrl);
        public bool ControlUrlIsOk(string url);
        public bool ControlCustomUrl(string customUrl);

    }
}
