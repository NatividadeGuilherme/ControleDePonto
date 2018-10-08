using System.Web;
using System.Web.Mvc;

namespace Cadastro_Cliente_Ponto
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
