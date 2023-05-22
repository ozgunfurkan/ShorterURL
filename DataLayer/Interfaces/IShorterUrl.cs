using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IShorterUrl
    {
        public UrlMapping SaveUrl(string url, string customUrl);
        public UrlMapping? GetRedirectUrl(string url);

    }
}
