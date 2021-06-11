using AutoMapper;
using LearningDiary.Application.Responses;
using LearningDiary.Domain.Contracts;
using LearningDiary.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LearningDiary.Application.Commands.CreateSavePoint
{
    class CreateSavePointCommandHandler : IRequestHandler<CreateSavePointCommand, BaseResponse<Guid>>
    {
        private readonly ISavePointRepository _repository;
        private readonly IMapper _mapper;

        public CreateSavePointCommandHandler(IMapper mapper, ISavePointRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseResponse<Guid>> Handle(CreateSavePointCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSavePointCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new BaseResponse<Guid>(validatorResult);

            var savePoint = _mapper.Map<SavePoint>(request);
            var result = await _repository.AddAsync(savePoint);

            return new BaseResponse<Guid>(result.Id);
        }
    }
}
