using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //JWT ile istek yapan herkes için bir context oluşur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //Attribute'den gelen elemanlarla (admin,user) bir dizi oluşturur.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation) //Metottan önce çalıştır.
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //Kullanıcının rollerini bul
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return; //ilgili rol varsa çalıştırmaya devam et.
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
