using MediatR;
using System.Diagnostics;

namespace AOP.Application.Person
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Before Handling {typeof(TRequest).Name}");

            var response = await next();

            Console.WriteLine($"After Handling {typeof(TRequest).Name}");

            return response;
        }
    }
    public class AddPerson
    {
        public class Query : IRequest<Response>
        {
            public List<Model.Person> persons { get; set; }

        }
        public class Handler : IRequestHandler<Query, Response>
        {
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var pers = request.persons.ToList();
                Console.WriteLine("This is From MediatR");
                return new Response
                {
                    persons = pers,
                };
            }
        }
        public class Response
        {
            public List<Model.Person> persons { get; set; }
        }
    }
}
