using System.ComponentModel.DataAnnotations;

namespace Sayaratech.Services.Dtos.Blobs
{

    public class SaveBlobInputDto
    {
        public byte[] Content { get; set; }

        [Required]
        public Guid Id { get; set; }
    }
}
