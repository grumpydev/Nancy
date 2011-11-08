namespace Nancy.Routing
{
    using System;
    using System.Threading.Tasks;

    public class Route
    {
        public Route(RouteDescription description, Func<dynamic, AsyncResponse> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.Description = description;
            this.Action = action;
        }

        public Route (string method, string path, Func<NancyContext, bool> condition, Func<dynamic, AsyncResponse> action)
            : this(new RouteDescription(method, path, condition), action)
        {
        }

        public Func<dynamic, AsyncResponse> Action { get; set; }

        public RouteDescription Description { get; private set; }

        public AsyncResponse AsyncInvoke(DynamicDictionary parameters)
        {
            return this.GetRouteTask(parameters);
        }

        public Response Invoke(DynamicDictionary parameters)
        {
            var task = this.GetRouteTask(parameters);

            if (task.Status == TaskStatus.Created)
            {
                task.Start();
            }

            return task.Result;
        }

        private AsyncResponse GetRouteTask(DynamicDictionary parameters)
        {
            return this.Action.Invoke(parameters);
        }
    }
}
