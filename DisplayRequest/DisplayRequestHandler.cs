using System;
using System.Configuration;
using System.Web;

namespace DisplayRequest
{
    public class DisplayRequestHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            response.Write("<html>");

            response.Write("<head>");
            response.Write("<style>");
            response.Write("* { font-family: Arial, Helvetica, sans-serif; }");
            response.Write("th, td { vertical-align: top; text-align: left; }");
            response.Write("</style>");
            response.Write("</head>");

            response.Write("<body>");
            response.Write("<h1>ASP.net Request Information</h1>");

            response.Write("<h2>Request</h2>");

            response.Write("<table>");
            WriteRow(response, "AcceptTypes", request.AcceptTypes);
            WriteRow(response, "AnonymousID", request.AnonymousID);
            WriteRow(response, "ApplicationPath", request.ApplicationPath);
            WriteRow(response, "AppRelativeCurrentExecutionFilePath", request.AppRelativeCurrentExecutionFilePath);
            WriteRow(response, "Browser", request.Browser);
            WriteRow(response, "ClientCertificate", request.ClientCertificate);
            WriteRow(response, "ContentEncoding", request.ContentEncoding);
            WriteRow(response, "ContentLength", request.ContentLength);
            WriteRow(response, "ContentType", request.ContentType);
            WriteRow(response, "Cookies", request.Cookies);
            WriteRow(response, "CurrentExecutionFilePath", request.CurrentExecutionFilePath);
            WriteRow(response, "CurrentExecutionFilePathExtension", request.CurrentExecutionFilePathExtension);
            WriteRow(response, "FilePath", request.FilePath);
            WriteRow(response, "Files", request.Files);
            WriteRow(response, "Filter", request.Filter);
            WriteRow(response, "Form", request.Form);
            WriteRow(response, "Headers", request.Headers);
            WriteRow(response, "HttpChannelBinding", request.HttpChannelBinding);
            WriteRow(response, "HttpMethod", request.HttpMethod);
            WriteRow(response, "InputStream", request.InputStream);
            WriteRow(response, "IsAuthenticated", request.IsAuthenticated);
            WriteRow(response, "IsLocal", request.IsLocal);
            WriteRow(response, "IsSecureConnection", request.IsSecureConnection);
            WriteRow(response, "LogonUserIdentity", request.LogonUserIdentity);
            WriteRow(response, "Params", request.Params);
            WriteRow(response, "Path", request.Path);
            WriteRow(response, "PathInfo", request.PathInfo);
            WriteRow(response, "PhysicalApplicationPath", request.PhysicalApplicationPath);
            WriteRow(response, "PhysicalPath", request.PhysicalPath);
            WriteRow(response, "QueryString", request.QueryString);
            WriteRow(response, "RawUrl", request.RawUrl);
            WriteRow(response, "ReadEntityBodyMode", request.ReadEntityBodyMode);
            WriteRow(response, "RequestContext", request.RequestContext);
            WriteRow(response, "RequestType", request.RequestType);
            WriteRow(response, "ServerVariables", request.ServerVariables);
            WriteRow(response, "TimedOutToken", request.TimedOutToken);
            WriteRow(response, "TlsTokenBindingInfo", request.TlsTokenBindingInfo);
            WriteRow(response, "TotalBytes", request.TotalBytes);
            WriteRow(response, "Unvalidated", request.Unvalidated);
            WriteRow(response, "Url", request.Url);
            WriteRow(response, "UrlReferrer", request.UrlReferrer);
            WriteRow(response, "UserAgent", request.UserAgent);
            WriteRow(response, "UserHostAddress", request.UserHostAddress);
            WriteRow(response, "UserHostName", request.UserHostName);
            WriteRow(response, "UserLanguages", request.UserLanguages);
            response.Write("</table>");

            response.Write("<h2>Environment</h2>");
            response.Write("<table>");

            foreach (System.Collections.DictionaryEntry env in System.Environment.GetEnvironmentVariables())
            {
                WriteRow(response, env.Key.ToString(), env.Value);
            }

            response.Write("</table>");


            response.Write("<h2>AppSettings</h2>");
            response.Write("<table>");

            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                WriteRow(response, key, ConfigurationManager.AppSettings.Get(key));
            }
            response.Write("</table>");

            response.Write("</body>");
            response.Write("</html>");
        }

        private void WriteRow(HttpResponse response, string key, string value)
        {
            response.Write("<tr>");
            response.Write("<th>");
            response.Write(key);
            response.Write("</th>");
            response.Write("<td>");
            response.Write(value);
            response.Write("</td>");
            response.Write("</tr>");
        }

        private void WriteRow(HttpResponse response, string key, string[] values)
        {
            WriteRow(response, key, String.Join(", ", values));
        }

        private void WriteRow(HttpResponse response, string key, bool value)
        {
            WriteRow(response, key, value ? "True" : "False");
        }

        private void WriteRow(HttpResponse response, string key, object value)
        {
            WriteRow(response, key, value == null ? "" : value.ToString());
        }
    }
}
