using AutoMapper;
using LearningDiary.Application.Responses;
using LearningDiary.Domain.Contracts;
using LearningDiary.Domain.ValueObjects;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LearningDiary.Application.Queries.GetSavePointsByAppUser
{
    class GetSavePointsByAppUserQueryHandler : IRequestHandler<GetSavePointsByAppUserQuery, BaseResponse<List<SavePointVM>>>
    {
        private readonly ISavePointRepository _repository;
        private readonly IMapper _mapper;

        public GetSavePointsByAppUserQueryHandler(IMapper mapper, ISavePointRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseResponse<List<SavePointVM>>> Handle(GetSavePointsByAppUserQuery request, CancellationToken cancellationToken)
        {
            var appUser = _mapper.Map<AppUser>(request.Nickname);
            var savePoints = await _repository.GetAllByAppUserAsync(appUser);
            savePoints = savePoints.OrderByDescending(x => x.CreatedDate).ToList();

            return new BaseResponse<List<SavePointVM>>(_mapper.Map<List<SavePointVM>>(savePoints));
        }
    }
}
