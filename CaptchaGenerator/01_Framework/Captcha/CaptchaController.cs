using Microsoft.AspNetCore.Mvc;

namespace CaptchaGenerator.api
{
    public class CaptchaController : Controller
    {
      
        //[Route("/[controller]")]
        [Route("/get-captcha-image")]
        public IActionResult OnGet()
        {
            int width = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
            //Stream s = new MemoryStream(result.CaptchaByteData);
            return Json(result.CaptchBase64Data);
            //return new FileStreamResult(s, "image/png");
        }
    }
}
