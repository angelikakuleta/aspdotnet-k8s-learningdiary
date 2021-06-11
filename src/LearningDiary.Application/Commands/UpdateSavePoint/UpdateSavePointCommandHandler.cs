using AutoMapper;
using LearningDiary.Application.Responses;
using LearningDiary.Domain.Contracts;
using LearningDiary.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LearningDiary.Application.Commands.UpdateSavePoint
{
    class UpdateSavePointCommandHandler : IRequestHandler<UpdateSavePointCommand, BaseResponse<Guid>>
    {
        private readonly ISavePointRepository _repository;
        private readonly IMapper _mapper;

        public UpdateSavePointCommandHandler(IMapper mapper, ISavePointRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseResponse<Guid>> Handle(UpdateSavePointCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSavePointCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new BaseResponse<Guid>(validatorResult);

            var savePoint = await _repository.FindByIdAsync(request.Id);
            if (savePoint == null)
            {
                return new BaseResponse<Guid>(ResponseStatus.NotFound);
            }

            _mapper.Map(request, savePoint);
            var result = await _repository.UpdateAsync(savePoint);

            return new BaseResponse<Guid>(result.Id);
        }
    }
}
