using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http.ModelBinding;

namespace EfConcurrency.Web.WebHelper
{
    public static class WebExtensions
    {
        public static string GetIpAddress(HttpRequestBase request)
        {
            string ip;
            try
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (!string.IsNullOrEmpty(ip))
                {
                    if (ip.IndexOf(",", StringComparison.Ordinal) > 0)
                    {
                        var ipRange = ip.Split(',');
                        var le = ipRange.Length - 1;
                        ip = ipRange[le];
                    }
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch { ip = null; }

            return ip;
        }

        public static string GetBrowserInfo(this HttpRequestBase request)
        {
            var browser = request.Browser;
            var brwInfo = "Type = " + browser.Type + "<br />"
                          + "Name = " + browser.Browser + "<br />"
                          + "Version = " + browser.Version + "<br />"
                          + "Major Version = " + browser.MajorVersion + "<br />"
                          + "Minor Version = " + browser.MinorVersion + "<br />"
                          + "Platform = " + browser.Platform + "<br />"
                          + "Is Beta = " + browser.Beta + "<br />"
                          + "Is Crawler = " + browser.Crawler + "<br />"
                          + "Is AOL = " + browser.AOL + "<br />"
                          + "Is Win16 = " + browser.Win16 + "<br />"
                          + "Is Win32 = " + browser.Win32 + "<br />"
                          + "Supports Frames = " + browser.Frames + "<br />"
                          + "Supports Tables = " + browser.Tables + "<br />"
                          + "Supports Cookies = " + browser.Cookies + "<br />"
                          + "Supports VBScript = " + browser.VBScript + "<br />"
                          + "Supports JavaScript = " + browser.EcmaScriptVersion + "<br />"
                          + "Supports Java Applets = " + browser.JavaApplets + "<br />"
                          + "Supports ActiveX Controls = " + browser.ActiveXControls + "<br />"
                          + "Supports JavaScript Version = " + browser["JavaScriptVersion"] + "<br />";

            return brwInfo;
        }

        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            var list = new List<string>();
            foreach (var state in modelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    var key = state.Key;
                    var value = string.IsNullOrEmpty(error.ErrorMessage) ? error.Exception.Message : error.ErrorMessage;

                    list.Add($"{key}: {value}");
                }
            }

            return list;
        }
    }
}