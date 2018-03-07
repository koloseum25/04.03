using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Moq;
using SportsStore.Domian.Abstract;
using SportsStore.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public  NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object>GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            Mock<IproductRepository> mock = new Mock<IproductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>{
                new Product { Name="Piłka nożna",Price=25},
                new Product { Name="Deska Surfingowa",Price=179},
                new Product { Name="Buty do biegania",Price=95},

            });
            kernel.Bind<IproductRepository>().ToConstant(mock.Object);

        }

    }
}