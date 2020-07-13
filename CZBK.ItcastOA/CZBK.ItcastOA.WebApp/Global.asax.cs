using CZBK.ItcastOA.WebApp.Models;
using log4net;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CZBK.ItcastOA.WebApp
{
    public class MvcApplication : SpringMvcApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();//读取配置中的Log4Net的配置i西南西
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //开启一个线程扫描异常信息队列(从线程池中取一个线程)
            string filePath = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (true)
                {
                    if (MyExceptionAttribute.ExceptionQueue.Count > 0)
                    {
                        //从队列中取出异常信息并进行记录
                        Exception ex = MyExceptionAttribute.ExceptionQueue.Dequeue();
                        if (ex != null)
                        {
                            //string fileName = DateTime.Now.ToString("yyyy-MM-dd")+".txt";
                            //File.AppendAllText(filePath+fileName,ex.Message,Encoding.UTF8);
                            ILog logger = LogManager.GetLogger("errMsg");
                            logger.Error(ex.Message);
                        }
                        else
                        {
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        //如果队列中没有数据,则线程休息
                        Thread.Sleep(3000);
                    }
                }
            });
        }
    }
}
