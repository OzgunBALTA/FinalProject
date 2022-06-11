using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder) //Program her başlatıldığında çalışır.
        {
            //Instance oluşturmayı API StartUpta yapmak yerine burada yapmak daha iyi. Birden fazla API olabilir çünkü. 
            //Autofac bize AOP imkanı da sağlar.
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); // Biri senden IProductService isterse ona ProductManager ver. SingleInstance ile tek instance oluşturulur. Tüm işlemler onun üzerinden yapılır.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //Çalışan program içerisinde

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() // implemente edilmiş interface'leri bul.
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() // Onlar için AspectInterceptorSelector'ı çalıştır. 
                }).SingleInstance();

        }
    }
}
