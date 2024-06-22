using Application.Features.Authors.Queries.GetById;
using Application.Features.TitleModOperations.Queries.GetList;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Queries.GetById
{
    public class GetByIdTitleResponse : IResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public bool IsLocked { get; set; }
        public string Slug { get; set; }
        public int EntryCount { get; set; }
        public int FollowersCount { get; set; }
        public int BlockersCount { get; set; }
        public ICollection<GetListTitleModOperationListItemDto> TitleModOperations { get; set; }

        public GetByIdAuthorForTitleGetByIdResponse Author { get; set; }
    }
}
