DisplayAspRequest
=================

Displays the information in an ASP.net web request, so that you can debug
the values provided to your handler:

 * The `HttpRequest` object
 * Environment variables
 * Application Settings

The included `Web.config` redirects all requests to the handler, so that
you can `GET` or `POST` arbitrary requests to see how ASP.net provides this
information to your handler.

