using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolDAL.Model;
using Microsoft.EntityFrameworkCore.SqlServer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolDAL
{
    /// <summary>
    /// מנהל את כל התלויות שקשורות לשכבת ה- DAL
    /// </summary>
    public static class DalCommon
    {
        public static IServiceCollection AddDALDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IDAL.IObjectDAL), typeof(SchoolDAL.UserDal));

            serviceCollection.AddScoped(typeof(IDAL.IGroupDal), typeof(SchoolDAL.GroupDal));

            //הזרקת הקונטקסט לכל מקום בו הוא נדרש:
            serviceCollection.AddDbContext<SchoolDbContext>();
                 
            return serviceCollection;
        }
    }
}
