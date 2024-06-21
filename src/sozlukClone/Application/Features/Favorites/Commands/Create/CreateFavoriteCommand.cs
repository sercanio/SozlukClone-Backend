using Application.Features.Favorites.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Favorites.Commands.Create;

public class CreateFavoriteCommand : IRequest<CreatedFavoriteResponse>
{
    public required int EntryId { get; set; }
    public required int AuthorId { get; set; }

    public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand, CreatedFavoriteResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly FavoriteBusinessRules _favoriteBusinessRules;

        public CreateFavoriteCommandHandler(IMapper mapper, IFavoriteRepository favoriteRepository,
                                         FavoriteBusinessRules favoriteBusinessRules)
        {
            _mapper = mapper;
            _favoriteRepository = favoriteRepository;
            _favoriteBusinessRules = favoriteBusinessRules;
        }

        public async Task<CreatedFavoriteResponse> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
        {
            await _favoriteBusinessRules.FavoriteShouldGivenToOtherAuthors(request.EntryId, request.AuthorId, cancellationToken);

            Favorite favorite = _mapper.Map<Favorite>(request);

            await _favoriteRepository.AddAsync(favorite);

            CreatedFavoriteResponse response = _mapper.Map<CreatedFavoriteResponse>(favorite);
            return response;
        }
    }
}