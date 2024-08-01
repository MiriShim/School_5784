using IBL;
using SchoolBL;
using SchoolDAL;
using Microsoft.Extensions.DependencyInjection;

namespace Accessories;

public static  class AddDependencies
{
    public static  void  AddAllDependencies(this  IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddBLDependencies( )
            .AddDALDependencies() ;
         
    }
}
