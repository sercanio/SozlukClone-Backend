using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleSettings.Queries.GetById;

public class GetByIdTitleSettingResponse : IResponse
{
    public uint Id { get; set; }
    public byte MinTitleLength { get; set; }
    public byte MaxTitleLength { get; set; }
    public bool TitleCanHaveLink { get; set; }
    public bool TitleCanHaveSpecialCharacter { get; set; }
    public bool TitleCanHavePunctuation { get; set; }
}