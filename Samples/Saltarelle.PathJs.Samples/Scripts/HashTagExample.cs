using System;
using PathApi;
using jQueryApi;

namespace Saltarelle.PathJs.Samples.Scripts
{
    public class HashTagExample
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
            Path.Map("#/users")
                .To(() => jQuery.Select("#output .content").Html("Users"))
                .Enter(setPageBackground);

            Path.Map("#/about")
                .To(() => jQuery.Select("#output .content").Html("About"))
                .Enter(setPageBackground);

            Path.Map("#/contact")
                .To(() => jQuery.Select("#output .content").Html("Contact"))
                .Enter(setPageBackground);

            // Here we set a "root route".  You may have noticed that when you landed on this
            // page you were automatically "redirected" to the "#/users" route.  The definition
            // below tells PathJS to load this route automatically if one isn't provided.
            Path.Root("#/users");

            // The `Path.rescue()` method takes a function as an argument, and will be called when
            // a route is activated that you have no yet defined an action for.  On this example
            // page, you'll notice there is no defined route for the "Unicorns!?" link.  Since no
            // route is defined, it calls this method instead.
            Path.Rescue(notFound);

            // This line is used to start the PathJS listener.  It's good practice to put this
            // call inside some sort of "document ready" listener, in case the default route
            // relies on DOM elements that may not yet be ready.
            jQuery.OnDocumentReady(Path.Listen);
        }
    }
}
