using System;
using System.Web;

namespace lab1BKS.Handlers
{
    public class IISHandler1BKS : IHttpHandler//http://localhost:56367/handler/bks/1?ParmA=1f&ParmB=ffff
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
            // response.Write("hello");
            response.ContentType = "text/plain";
            response.Write(
                "GET-Http-BKS:ParmA = " + context.Request.QueryString.Get("ParmA") +
                " ,ParmB = " + context.Request.QueryString.Get("ParmB"));
        }

        #endregion
    }
}
