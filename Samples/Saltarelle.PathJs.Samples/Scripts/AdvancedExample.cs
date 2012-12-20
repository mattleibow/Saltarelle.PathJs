using System;
using PathApi;
using jQueryApi;

namespace Saltarelle.PathJs.Samples.Scripts
{
    public class AdvancedExample
    {
        public static void Setup()
        {
            // This example makes use of the jQuery library.

            // The examples in this document work with both the HTML5 History API and the Hashtag
            // methods provided by PathJS.  For a wider range of compatibility, these examples
            // use the Hashtag.

            // If you have not yet read the "Hashtag Basics" and "HTML5 Basics" examples yet, I
            // strongly urge you to do so now.


            // This is our "rescue" method.
            Action notFound = () => jQuery.Select("#output .content").Html("404 Not Found");

            var userList = "<a href='#/users/1'>Mike Trpcic</a><a href='#/users/2'>Garry Whitmore</a><a href='#/users/3'>SlayerS`Boxer`</a>";
            Path.Map("#/users")
                .To(() => jQuery.Select("#output .content").Html(userList));

            // This is an example of a parameterized route. This route will match things such as
            // "#/users/1", "#/users/500", and "#/users/mike".  Inside the action of that route,
            // you have access to the parameters via the `this.params` object.
            Path.Map("#/users/:user_id")
                .To(() => jQuery.Select("#output .content").Html("You selected the user with ID: " + Path.Parameters["user_id"]));

            // This is a route with optional components.  Optional components in a route are contained
            // within brackets.  The route below will match both "#/about" and "#/about/author".
            Path.Map("#/about(/author)")
                .To(() => jQuery.Select("#output .content").Html("About & About/Author share a route!"));

            // This route is an example of execution halting and the filter chain.  You can assign 
            // multiple "enter" methods to any given route.  You can assign them as an array, or by
            // calling the `enter` method multiple times.  When executing the route, PathJS will go
            // through your enter methods in the order they were assigned.  If at any point one of
            // these methods explicitly returns false, execution is halted and the route is never 
            // hit.  In the example below, we halt execution, and the actual action of the "#/contact"
            // route is never invoked.
            Path.Map("#/contact")
                .To(() => jQuery.Select("#output .content").Html("Contact"))
                .Enter(() => jQuery.Select("#output .content").Html("This will work."))
                .Enter(() =>
                    {
                        jQuery.Select("#output .content").Append("Execution Halted!");
                        return false;
                    });

            Path.Root("#/users");

            Path.Rescue(notFound);

            jQuery.OnDocumentReady(Path.Listen);
        }
    }
}
