using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CZBK.ItcastOA.IDAL;
using System.Reflection;
using CZBK.ItcastOA.DAL;

namespace CZBK.ItcastOA.DALFactory
{
    public class AbstarctFactory
    {
        public static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        public static readonly string NameSpace = ConfigurationManager.AppSettings["NameSpace"];
        public static IUserInfoDal CreateUserInfoDal()
        {
            string fullClassName = NameSpace + ".UserInfoDal";
            return CreateInstance(fullClassName) as UserInfoDal;
        }

        private static object CreateInstance(string className)
        {
            var assembly = Assembly.Load(AssemblyPath);
            return assembly.CreateInstance(className);
        }
    }
}
