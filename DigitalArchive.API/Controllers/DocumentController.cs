using Azure.Storage.Blobs;
using DigitalArchive.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DocumentController : BaseController
    {
        private readonly IDocumentAppService _documentAppService;
        private readonly string _storageConnectionString;
        private readonly string _storageContainerName;
        public DocumentController(IDocumentAppService documentAppService, IConfiguration configuration)
        {
            _documentAppService = documentAppService;
            _storageConnectionString = configuration.GetValue<string>("BlobConnectionString");
            _storageContainerName = configuration.GetValue<string>("BlobContainerName");
        }

        [HttpPost("UploadDocument")]
        public async Task<IActionResult> UploadDocument()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file == null)
                {
                    return BadRequest();
                }
                var folderName = Path.Combine("StaticFiles", "Documents");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var recordDocumentId =await _documentAppService.CreateAndGetDocumentId(fileName, file.ContentType);
                
                return Ok(new UploadedDocumentInfo
                {
                    DocumentId = recordDocumentId,
                    DocumentName = fileName,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpPost("UploadDocumentToAzure")]
        public async Task<IActionResult> UploadDocumentToAzure(IFormFile file)
       {
            BlobContainerClient container = new (_storageConnectionString, _storageContainerName);

            try
            {
                //var file = Request.Form.Files[0];

                if (file == null)
                {
                    return BadRequest();
                }
                
                string fileExtension = Path.GetExtension(file.FileName);

                string result = file.FileName.Substring(0, file.FileName.Length - fileExtension.Length);

                string fileName = result +"-"+ DateTime.UtcNow.ToString(); 


                string newFileName = string.Join(string.Empty,fileName,fileExtension);
               
                // Get a reference to the blob just uploaded from the API in a container from configuration settings
                BlobClient blob = container.GetBlobClient(newFileName);

                await blob.UploadAsync(file.OpenReadStream());

                var recordDocumentId = await _documentAppService.CreateAndGetDocumentId(newFileName, file.ContentType);
                
                return Ok(new UploadedDocumentInfo
                {
                    DocumentId = recordDocumentId,
                    DocumentName = newFileName,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        public class UploadedDocumentInfo
        {
            public int DocumentId { get; set; }
            public string DocumentName { get; set; }
        }
    }
}
