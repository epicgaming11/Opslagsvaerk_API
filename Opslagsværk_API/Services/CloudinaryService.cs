//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CloudinaryDotNet;
//using CloudinaryDotNet.Actions;

//namespace Opslagsværk_API.Services
//{
//    public class CloudinaryService
//    {
//        private readonly Cloudinary _cloudinary;

//        public CloudinaryService()
//        {
//            string cloudServer = "dzexza5hm";
//            string cloudPass = "784545789638541";
//            string cloudKey = "p4NoaaEWbIhKgPG3OU8Z2BnKP1A";

//            var account = new Account(
//                cloudServer,
//                cloudPass,
//                cloudKey
//            );

//            _cloudinary = new Cloudinary(account);
//            _cloudinary.Api.Secure = true;
//        }

//        public async Task<string> UploadImageAsync(IFormFile file)
//        {
//            if (file == null || file.Length == 0)
//            {
//                throw new ArgumentException("File is empty.");
//            }

//            using var stream = file.OpenReadStream();

//            var uploadParams = new ImageUploadParams
//            {
//                File = new FileDescription(file.FileName, stream),
//                Transformation = new Transformation().Width(500).Height(500).Crop("limit"),
//                Folder = "hardware-images"
//            };

//            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

//            return uploadResult.SecureUrl.AbsoluteUri;
//        }
//    }
//}