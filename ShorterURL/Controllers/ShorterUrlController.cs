using BusinessLayer;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ShorterURL.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShorterUrlController : ControllerBase
    {
        private readonly IShorterUrlBusinessInterface _shorterUrlBusiness;
        public ShorterUrlController(IShorterUrlBusinessInterface businessInterface)
        {
            _shorterUrlBusiness = businessInterface;
        }
        [HttpPost, ActionName("ShortUrl")]
        public IActionResult Post([FromBody]ShorterUrlRequest req)
        {
            

            if (!_shorterUrlBusiness.ControlUrlIsOk(req.Url))
            {
                return BadRequest("Girilen url uygun formatta de�il");
            }

            string baseUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";
            return Ok(_shorterUrlBusiness.SaveShorterUrl(req.Url,baseUrl));
        }

        [HttpPost, ActionName("CustomUrl")]
        public IActionResult CustomUrl([FromBody] ShorterUrlRequest req)
        {


            if (!_shorterUrlBusiness.ControlCustomUrl(req.CustomUrl))
            {
                return BadRequest("L�tfen girdi�iniz de�erleri kontrol ediniz. Girilen customUrl'in uzunlu�u max 6 olmal� ve �zel karakter bulunmamal�");

            }

            if (!_shorterUrlBusiness.ControlUrlIsOk(req.Url))
            {
                return BadRequest("Girilen url uygun formatta de�il");
            }

            string baseUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";
            return Ok(_shorterUrlBusiness.SaveShorterUrl(req.Url, baseUrl,req.CustomUrl));
        }
    }
}