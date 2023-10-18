using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Blobs;
using Volo.Abp.AspNetCore.Mvc;

namespace Sayaratech.Controllers
{
    public class FileController : AbpController
    {
        private readonly IBlobAppService _fileAppService;

        public FileController(IBlobAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        [HttpGet]
        [Route("download/{fileName}")]
        public async Task<IActionResult> DownloadAsync(string fileName)
        {
            var fileDto = await _fileAppService.GetBlobAsync(new GetBlobRequestDto { Id = Guid.Parse(fileName) });

            return File(fileDto.Content, "application/octet-stream", fileDto.Id.ToString());
        }
    }
}