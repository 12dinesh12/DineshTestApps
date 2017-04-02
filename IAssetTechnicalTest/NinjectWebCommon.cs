using IAssetTechnicalTest.Services;
using Ninject.Modules;

namespace IAssetTechnicalTest
{
    public class NinjectWebCommon : NinjectModule
    {
        public override void Load()
        {
            Bind<IGlobalWeatherService>().To<GlobalWeatherService>();
        }
    }
}