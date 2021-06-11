using AutoMapper;
using LearningDiary.Application.Responses;
using LearningDiary.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningDiary.Application.Queries.GetSavePoint
{
    class GetSavePointQueryHandler : IRequestHandler<GetSavePointQuery, BaseResponse<SavePointDetailsVM>>
    {
        private readonly ISavePointRepository _repository;
        private readonly IMapper _mapper;

        public GetSavePointQueryHandler(IMapper mapper, ISavePointRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseResponse<SavePointDetailsVM>> Handle(GetSavePointQuery request, CancellationToken cancellationToken)
        {
            var savePoint = await _repository.FindByIdAsync(request.Id);
            if (savePoint == null)
            {
                return new BaseResponse<SavePointDetailsVM>(ResponseStatus.NotFound);
            }

            return new BaseResponse<SavePointDetailsVM>(_mapper.Map<SavePointDetailsVM>(savePoint));
        }
    }
}
