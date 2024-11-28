using AutoMapper;
using Cmail.Mailbox.Application.Dto.Master;
using Cmail.Mailbox.Dmain.Repositoy.Master;

namespace Cmail.Mailbox.Application.Services.Master;

public interface IFolderService
{
    Task<List<FolderDto>?> GetFoldersAsync();
}

public class FolderService : IFolderService
{
    private readonly IFolderRepository _folderRepository;
    private readonly IMapper _mapper;

    public FolderService(IFolderRepository folderRepository, IMapper mapper)
    {
        _folderRepository = folderRepository;
        _mapper = mapper;
    }

    public async Task<List<FolderDto>?> GetFoldersAsync()
    {
        var data = await _folderRepository.GetFoldersAsync();

        if (data != null && data.Any())
        {
            return _mapper.Map<List<FolderDto>>(data);
        }

        return null;
    }
}
