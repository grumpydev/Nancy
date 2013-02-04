namespace Nancy.Tests.Functional.Modules
{
    using Nancy.Tests.Functional.Models;

    public class RazorTestModule : NancyModule
    {
        public RazorTestModule()
        {
            Get["/razor-viewbag"] = _ =>
                {
                    this.ViewBag.Name = "Bob";

                    return View["RazorPage"];
                };

            Get["/just-model"] = _ => new MyModel();
        }
    }
}
