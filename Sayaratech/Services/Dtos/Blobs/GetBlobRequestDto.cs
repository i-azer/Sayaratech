using System.ComponentModel.DataAnnotations;

namespace Sayaratech.Services.Dtos.Blobs
{
    public class GetBlobRequestDto
    {
        [Required]
        public Guid Id { get; set; }
    }
}
