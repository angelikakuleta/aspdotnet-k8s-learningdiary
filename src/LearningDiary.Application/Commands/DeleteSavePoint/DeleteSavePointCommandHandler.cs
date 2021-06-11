using AutoMapper;
using LearningDiary.Application.Responses;
using LearningDiary.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LearningDiary.Application.Commands.DeleteSavePoint
{
    public class DeleteSavePointCommandHandler : IRequestHandler<DeleteSavePointCommand, BaseResponse>
    {
        private readonly ISavePointRepository _repository;

        public DeleteSavePointCommandHandler(ISavePointRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(DeleteSavePointCommand request, CancellationToken cancellationToken)
        {
            var isSuccess = await _repository.DeleteAsync(request.Id);
            if (!isSuccess)
            {
                return new BaseResponse(ResponseStatus.NotFound);
            }

            return new BaseResponse();
        }
    }
}
