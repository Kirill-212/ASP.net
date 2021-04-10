using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.IO;

namespace Lab5A2.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch
        [AcceptVerbs("get","post")]
        public string c01()
        {
            StringBuilder result = new StringBuilder();
          
                result.Append("method- "+HttpContext.Request.HttpMethod.ToString()+ "\nquery-" );
                result.Append(HttpContext.Request.QueryString.ToString());
                result.Append("\nuri-"+HttpContext.Request.Url.ToString());
                result.Append("\nheaders-" + HttpContext.Request.Headers.ToString());
            result.Append("\nform-" + HttpContext.Request.Form.ToString());
            if (HttpContext.Request.HttpMethod == "POST") 
            {
                result.Append("\nform-" + HttpContext.Request.Form.ToString());
                using (StreamReader reader = new StreamReader(Request.InputStream))
                {
                    result.Append("\nbody-"+reader.ReadToEnd());
                }
                
            }
            
            return result.ToString();
            
        }
        [AcceptVerbs("get", "post")]
        public string c02()
        {
            StringBuilder result = new StringBuilder();

            result.Append("\nstatus-" + HttpContext.Response.StatusCode);
            result.Append("\nheaders-" + HttpContext.Request.Headers.ToString());

            result.Append("\nform-" + HttpContext.Request.Form.ToString());
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                result.Append("\nbody-" + reader.ReadToEnd());
            }


            return result.ToString();
        }


    }
}