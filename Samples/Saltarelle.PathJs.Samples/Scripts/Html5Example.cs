using System;
using PathApi;
using jQueryApi;

namespace Saltarelle.PathJs.Samples.Scripts
{
    public class Html5Example
    {
        public static void Setup()
        {
            // This example makes use of the jQuery library.

            // You can use any methods as actions in PathJS.  You can define them as I do below,
            // assign them to variables, or use anonymous functions.  The choice is yours.
            Action notFound = () =>
                {
                    jQuery.Select("#output .content").Html("404 Not Found");
                    jQuery.Select("#output .content").AddClass("error");
                };

            Action setPageBackground = () => jQuery.Select("#output .content").RemoveClass("error");

            // Here we define our routes.  You'll notice that I only define three routes, even
            // though there are four links.  Each route has an action assigned to it (via the 
            // `to` method, as well as an `enter` method.  The `enter` method is called before
            // the route is performed, which allows you to do any setup you need (changes classes,
            // performing AJAX calls, adding animations, etc.
            Path.Map("/users")
                .To(() => jQuery.Select("#output .content").Html("Users"))
                .Enter(setPageBackground);

            Path.Map("/about")
                .To(() => jQuery.Select("#output .content").Html("About"))
                .Enter(setPageBackground);

            Path.Map("/contact")
                .To(() => jQuery.Select("#output .content").Html("Contact"))
                .Enter(setPageBackground);

            // The `Path.rescue()` method takes a function as an argument, and will be called when
            // a route is activated that you have not yet defined an action for.  On this example
            // page, you'll notice there is no defined route for the "Unicorns!?" link.  Since no
            // route is defined, it calls this method instead.
            Path.Rescue(notFound);

            jQuery.OnDocumentReady(() =>
                {
                    // This line is used to start the HTML5 PathJS listener.  This will modify the
                    // `window.onpopstate` method accordingly, check that HTML5 is supported, and
                    // fall back to hashtags if you tell it to.  Calling it with no arguments will
                    // cause it to do nothing if HTML5 is not supported
                    Path.History.Listen();

                    // If you would like it to gracefully fallback to Hashtags in the event that HTML5
                    // isn't supported, just pass `true` into the method.

                    // Path.History.Listen(true);

                    jQuery.Select("a").Click(evt =>
                        {
                            evt.PreventDefault();

                            // To make use of the HTML5 History API, you need to tell your click events to
                            // add to the history stack by calling the `Path.history.pushState` method. This
                            // method is analogous to the regular `window.history.pushState` method, but
                            // wraps calls to it around the PathJS dispatched.  Conveniently, you'll still have
                            // access to any state data you assign to it as if you had manually set it via
                            // the standard methods.
                            Path.History.PushState(new {}, "", (string)evt.Target.GetAttribute("href"));
                        });
                });
        }
    }
}
