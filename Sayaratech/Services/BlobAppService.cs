using Microsoft.AspNetCore.Mvc;
using Sayaratech.Services.Contracts;
using Sayaratech.Services.Dtos.Blobs;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace Sayaratech.Services
{
    public class BlobAppService : ApplicationService, IBlobAppService
    {
        private readonly IBlobContainer<BlobContainer> _blobContainer;
        public BlobAppService(IBlobContainer<BlobContainer> blobContainer)
        {
            _blobContainer = blobContainer;
        }
        public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
        {
            var blob = await _blobContainer.GetAllBytesAsync(input.Id.ToString());
            return new BlobDto
            {
                Id = input.Id,
                Content = blob
            };
        }

        public async Task SaveBlobAsync(SaveBlobInputDto input)
        {
            await _blobContainer.SaveAsync(input.Id.ToString(), input.Content, true);
        }
    }
}
