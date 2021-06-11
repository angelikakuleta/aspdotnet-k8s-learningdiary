using LearningDiary.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LearningDiary.Application.Behaviours
{
    class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : BaseResponse
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().Name;

            var timer = Stopwatch.StartNew();
            var response = await next();
            timer.Stop();

            _logger.LogInformation("{request} has finished in {time}ms with status {code}", requestName, timer.ElapsedMilliseconds, response.Status);
            return response;
        }
    }
}
