using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace Lab5B.CustomRouteConstraint
{
    public class EmailConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            Console.WriteLine(values["email"]);
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            MatchCollection matches = regex.Matches(values["email"].ToString());
            if (matches.Count > 0) return true;
            return false;
        }
    }
}