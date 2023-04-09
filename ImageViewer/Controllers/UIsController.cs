using DeviceOnLoan_WebApp.Data;
using ImageViewer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ImageViewer.Controllers
{
    public class UIsController : Controller
    {

        private readonly AppSettingsDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;

        public UIsController(AppSettingsDbContext dbContext, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _webHostEnvironment = hostEnvironment;
            _configuration = configuration;
        }




        // Upload Image ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult UploadImage ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage (UI image)
        {
            SaveImage(image);
            _dbContext.Images.Add(image);
            _dbContext.SaveChanges();

            return RedirectToAction("ShowImage","UIs");
        }




        // Show Image ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public IActionResult ShowImage ()
        {
            List <UI> images = _dbContext.Images.ToList();
            ViewBag.Images = images;
            return View();
        }




        // Save Image in wwwroot/images ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async void SaveImage (UI image)
        {
            if (image.ImageFile != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                string extension = Path.GetExtension(image.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                image.UrlImage = fileName;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await image.ImageFile.CopyToAsync(fileStream);
                }
            }
        }
    
    }
}
