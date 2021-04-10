using System;
using System.Web;

namespace lab1BKS.Handlers
{
    public class IISHandler6BKS : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            response.ContentType = "text/html; charset=utf-8";
            if (context.Request.HttpMethod == "GET")
            {

                response.WriteFile("../html/index6.html");
                response.StatusCode = 200;
            }
            else if (context.Request.HttpMethod == "POST")
            {
                if (int.TryParse(context.Request.Form.Get("X"), out int x) &&
                 int.TryParse(context.Request.Form.Get("Y"), out int y))
                {
                    response.Write(x * y);
                    response.StatusCode = 200;
                }
                else
                {
                    response.Write("Error input value");
                    response.StatusCode = 404;
                }
            }
            else
            {
                response.Write("Error input data");
                response.StatusCode = 404;
            }
        }

        #endregion
    }
}
