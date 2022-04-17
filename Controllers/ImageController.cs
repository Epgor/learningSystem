using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace learningSystem.Controllers //todo refactor to outer service
{
    [Route("image")]
    public class ImageController : ControllerBase
    {
        [HttpGet("names")]
        public ActionResult GetImageNames()
        {
            var rootPath = Directory.GetCurrentDirectory();

            var filePath = $"{rootPath}/Images/";
            DirectoryInfo d = new DirectoryInfo(filePath);
            FileInfo[] Files = d.GetFiles("*.jpg");
            string str = "";
            foreach(FileInfo file in Files)
            {
                str = str + "https://localhost:7038/image/" + file.Name + "\n";
            }
            return Ok(str);
        }
        [HttpGet("{imageName}")]
        public ActionResult GetImage([FromRoute] string imageName)
        {
            //var fileName = "image.png";
            var rootPath = Directory.GetCurrentDirectory();

            var filePath = $"{rootPath}/Images/{imageName}";

            var fileExists = System.IO.File.Exists(filePath);
            if (!fileExists)
            {
                return NotFound();
            }

            var contentProvider = new FileExtensionContentTypeProvider();
            contentProvider.TryGetContentType(imageName, out string contentType);

            var fileContents = System.IO.File.ReadAllBytes(filePath);

            return File(fileContents, contentType, imageName);
        }

        [HttpPost]
        public ActionResult Upload([FromForm]IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var rootPath = Directory.GetCurrentDirectory();
                var fileName = file.FileName;
                var fullPath = $"{rootPath}/Images/{fileName}";
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok();
            }

            return BadRequest();
        }
    }
}
