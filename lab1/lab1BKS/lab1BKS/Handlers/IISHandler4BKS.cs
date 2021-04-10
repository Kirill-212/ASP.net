using System;
using System.Web;

namespace lab1BKS.Handlers
{
    public class IISHandler4BKS : IHttpHandler
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
            response.ContentType = "text/plain";
            if (int.TryParse(context.Request.Form.Get("X"), out int x)&&
                 int.TryParse(context.Request.Form.Get("Y"),out int y))
            {
                response.Write(x+y);
            }
            else
            {
                response.Write("Error input value");
            }                  
        }

        #endregion
    }
}
