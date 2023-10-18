using Sayaratech.Services.Dtos.Blobs;
using Volo.Abp.Application.Services;

namespace Sayaratech.Services.Contracts
{
    public interface IBlobAppService : IApplicationService
    {
        Task SaveBlobAsync(SaveBlobInputDto input);
        Task<BlobDto> GetBlobAsync(GetBlobRequestDto input);
    }
}
