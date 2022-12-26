using System.Web.Mvc;

namespace Pagen
{
    public class FilterConfig
    {
        #region Public methods

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        #endregion
    }
}