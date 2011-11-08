namespace Nancy
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class AsyncResponse : Task<Response>
    {
        public AsyncResponse(Func<Response> function)
            : base(function)
        {
        }

        public AsyncResponse(Func<Response> function, CancellationToken cancellationToken)
            : base(function, cancellationToken)
        {
        }

        public AsyncResponse(Func<Response> function, TaskCreationOptions creationOptions)
            : base(function, creationOptions)
        {
        }

        public AsyncResponse(Func<Response> function, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
            : base(function, cancellationToken, creationOptions)
        {
        }

        public AsyncResponse(Func<object, Response> function, object state)
            : base(function, state)
        {
        }

        public AsyncResponse(Func<object, Response> function, object state, CancellationToken cancellationToken)
            : base(function, state, cancellationToken)
        {
        }

        public AsyncResponse(Func<object, Response> function, object state, TaskCreationOptions creationOptions)
            : base(function, state, creationOptions)
        {
        }

        public AsyncResponse(Func<object, Response> function, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
            : base(function, state, cancellationToken, creationOptions)
        {
        }

        public static implicit operator AsyncResponse(Response response)
        {
            return new AsyncResponse(() => response);
        }

        public static implicit operator AsyncResponse(string contents)
        {
            return new AsyncResponse(() => contents);
        }

        public static implicit operator AsyncResponse(HttpStatusCode statusCode)
        {
            return new Response { StatusCode = statusCode };
        }

        public static implicit operator AsyncResponse(int statusCode)
        {
            return new Response { StatusCode = (HttpStatusCode)statusCode };
        }

        public static implicit operator AsyncResponse(Action<Stream> streamFactory)
        {
            return new Response { Contents = streamFactory };
        }
    }
}