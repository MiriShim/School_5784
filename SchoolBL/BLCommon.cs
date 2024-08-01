using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBL
{
    /// <summary>
    /// מנהל תלויות שקשורות לשכבת ה- BL
    /// </summary>
    public static  class BLCommon
    {
        public static IServiceCollection AddBLDependencies(this IServiceCollection collection)
        {
            collection.AddTransient(typeof(IBL.IBL), typeof(SchoolBL.UserBL));

            collection.AddScoped(typeof(IBL.IGroupBL), typeof(SchoolBL.GroupBL));

            return collection;

        }
    }
}
