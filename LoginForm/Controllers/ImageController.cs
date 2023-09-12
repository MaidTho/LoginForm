using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using LoginForm.Models;

namespace LoginForm.Controllers
{
   
    
        
    public class ImageController : Controller



        {
            private readonly IWebHostEnvironment _webHostEnvironment;
            public ImageController(IWebHostEnvironment webHostEnvironment)
            {
                _webHostEnvironment = webHostEnvironment;
            }



            public IActionResult ImageIndex()
            {
                return View();



            }



            //  public IActionResult RedirectPage()
            // {
            //   return RedirectToAction("Index", "Home");
            // }





            [HttpPost]
            public async Task<IActionResult> AddImage(ImageModel imageModel)
            {
                if (ModelState.IsValid)
                {



                    if (imageModel.UserImg != null)
                    {
                        string folder = "Images/PetImages/";
                        // imageModel.UserImgUrl = await (folder, imageModel.UserImg);
                        folder += Guid.NewGuid().ToString() + "_" + imageModel.UserImg.FileName;
                        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                        await imageModel.UserImg.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    }



                }
                return LocalRedirect("/Image/ImageIndex");



            }



            //private async Task<string> UploadImage (string folderPath, IFormFile file)
            //{
            // folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            // string serverFolder = Path.Combine (_webHostEnvironment.WebRootPath, folderPath);
            // await file.CopyToAsync (new FileStream(serverFolder, FileMode.Create));
            //     return "/" + folderPath;



            // }




        }



    }






