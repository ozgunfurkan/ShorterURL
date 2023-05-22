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
                return BadRequest("Girilen url uygun formatta deðil");
            }

            string baseUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";
            return Ok(_shorterUrlBusiness.SaveShorterUrl(req.Url,baseUrl));
        }

        [HttpPost, ActionName("CustomUrl")]
        public IActionResult CustomUrl([FromBody] ShorterUrlRequest req)
        {


            if (!_shorterUrlBusiness.ControlCustomUrl(req.CustomUrl))
            {
                return BadRequest("Lütfen girdiðiniz deðerleri kontrol ediniz. Girilen customUrl'in uzunluðu max 6 olmalý ve özel karakter bulunmamalý");

            }

            if (!_shorterUrlBusiness.ControlUrlIsOk(req.Url))
            {
                return BadRequest("Girilen url uygun formatta deðil");
            }

            string baseUrl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";
            return Ok(_shorterUrlBusiness.SaveShorterUrl(req.Url, baseUrl,req.CustomUrl));
        }
    }
}