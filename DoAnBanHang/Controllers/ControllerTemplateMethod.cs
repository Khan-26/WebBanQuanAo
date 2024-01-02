using System;

using System.Web.Mvc;


namespace DoAnBanHang.Controllers
{
    public abstract class ControllerTemplateMethod : Controller
    {
        protected abstract void PrintRoute();
        protected abstract void PrintDIs();

        //Template Method

        public static string PrintInforMation()
        {
            return "The index action was invoked";
        }
    }
}