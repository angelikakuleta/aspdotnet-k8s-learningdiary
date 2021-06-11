using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace LearningDiary.Application.Responses
{
    public class BaseResponse
    {
        private readonly ResponseStatus _status;
        private readonly string _message;
        private readonly List<string> _validationErrors;

        public BaseResponse(ResponseStatus status = ResponseStatus.Success)
        {          
            _status = status;
            _message = "";
        }

        public BaseResponse(ResponseStatus status, string message)
        {
            _status = status;
            _message = message;
        }

        public BaseResponse(ValidationResult validationResult)
        {
            _validationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            _status = _validationErrors.Count > 0 ? ResponseStatus.ValidationError : ResponseStatus.Success;
        }

        public ResponseStatus Status => _status;

        public bool Success => Status == ResponseStatus.Success;

        public object Result => Status == ResponseStatus.ValidationError ? _validationErrors : _message;
    }
}
