using FluentValidation.Results;

namespace LearningDiary.Application.Responses
{
    public class BaseResponse<T> : BaseResponse
    {
        public T Body { get; set; }

        public BaseResponse(T body) : base(ResponseStatus.Success)
        {
            Body = body;
        }

        public BaseResponse(ResponseStatus status = ResponseStatus.Success) : base(status)
        {
        }

        public BaseResponse(ResponseStatus status, string message) : base(status, message)
        {
        }

        public BaseResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
    }
}
