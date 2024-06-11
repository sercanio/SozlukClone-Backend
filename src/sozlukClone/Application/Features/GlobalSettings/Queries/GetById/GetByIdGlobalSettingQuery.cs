using Application.Features.GlobalSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.GlobalSettings.Queries.GetById;

//public class GetByIdGlobalSettingQuery : IRequest<GetByIdGlobalSettingResponse>, ISecuredRequest
public class GetByIdGlobalSettingQuery : IRequest<GetByIdGlobalSettingResponse>
{
    public int Id { get; set; }

    //public string[] Roles => [Admin, Read];

    public class GetByIdGlobalSettingQueryHandler : IRequestHandler<GetByIdGlobalSettingQuery, GetByIdGlobalSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGlobalSettingRepository _globalSettingRepository;
        private readonly GlobalSettingBusinessRules _globalSettingBusinessRules;

        public GetByIdGlobalSettingQueryHandler(IMapper mapper, IGlobalSettingRepository globalSettingRepository, GlobalSettingBusinessRules globalSettingBusinessRules)
        {
            _mapper = mapper;
            _globalSettingRepository = globalSettingRepository;
            _globalSettingBusinessRules = globalSettingBusinessRules;
        }

        public async Task<GetByIdGlobalSettingResponse> Handle(GetByIdGlobalSettingQuery request, CancellationToken cancellationToken)
        {
            GlobalSetting? globalSetting = await _globalSettingRepository.GetAsync(
                predicate: gs => gs.Id == request.Id,
                include: gs => gs.Include(gs => gs.DefaultAuthorGroup),
                cancellationToken: cancellationToken);
            await _globalSettingBusinessRules.GlobalSettingShouldExistWhenSelected(globalSetting);

            GetByIdGlobalSettingResponse response = _mapper.Map<GetByIdGlobalSettingResponse>(globalSetting);
            return response;
        }
    }
}