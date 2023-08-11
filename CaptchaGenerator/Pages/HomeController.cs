﻿using Microsoft.AspNetCore.Mvc;

namespace CaptchaGenerator.Pages
{
    public class HomeController : Controller
    {
    
     
        [Route("get-captcha-image")]
        public IActionResult GetCaptchaImage()
        {
            int width = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }
        [Route("captcha")]
        public IActionResult GetCaptcha()
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
