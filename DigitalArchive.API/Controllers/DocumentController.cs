using DigitalArchive.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace DigitalArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DocumentController : BaseController
    {
        private readonly IDocumentAppService _documentAppService;
        public DocumentController(IDocumentAppService documentAppService)
        {
            _documentAppService = documentAppService;
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
        public class UploadedDocumentInfo
        {
            public int DocumentId { get; set; }
            public string DocumentName { get; set; }
        }
    }
}
