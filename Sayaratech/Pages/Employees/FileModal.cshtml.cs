using Microsoft.AspNetCore.Mvc;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Blobs;
using System.ComponentModel.DataAnnotations;

namespace Sayaratech.Pages.Employees
{
    public class FileModalModel : EmployeesPageModel
    {
        [BindProperty]
        public UploadFileDto UploadFileDto { get; set; }
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }


        private readonly IBlobAppService _blobAppService;

        public bool Uploaded { get; set; } = false;

        public FileModalModel(IBlobAppService blobAppService)
        {
            _blobAppService = blobAppService;
        }

        public void OnGet()
        {
            UploadFileDto = new UploadFileDto { Id = Id };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                await UploadFileDto.File.CopyToAsync(memoryStream);

                await _blobAppService.SaveBlobAsync(
                    new SaveBlobInputDto
                    {
                        Id = UploadFileDto.Id,
                        Content = memoryStream.ToArray()
                    }
                );
            }

            return NoContent();
        }
    }

    public class UploadFileDto
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile File { get; set; }

        [HiddenInput]
        public Guid Id { get; set; }
    }
}