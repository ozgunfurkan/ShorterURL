using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repos
{
    public class ShorterUrlRepo : IShorterUrl
    {
        public UrlMapping? GetRedirectUrl(string url)
        {
            try
            {
                

                using (var ctx = new ShorterUrlDBContext())
                {
                   return ctx.urlMappings.FirstOrDefault(x=>x.ShortUrl == url);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Url getirilirken hata oluştu..", ex);
            }
        }

        public UrlMapping SaveUrl(string url, string customUrl)
        {
            try
            {
                UrlMapping mapping = new UrlMapping();
                mapping.Url = url;
                mapping.ShortUrl = customUrl;
                
                using (var ctx = new ShorterUrlDBContext())
                { 
                    ctx.urlMappings.Add(mapping);
                    ctx.SaveChanges();
                }

                return mapping; 
            }
            catch(Exception ex)
            {
                throw new Exception("Url kaydedilirken hata oluştu..", ex);
            }
        }
    }
}
