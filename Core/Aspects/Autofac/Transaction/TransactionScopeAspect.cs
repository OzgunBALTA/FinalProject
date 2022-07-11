using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    //Bankacılık işlemi gibi işlemlerde mesela ETF işleminde para gönderenin hesabından düşerken alıcı hesabına yüklenmeli.
    //Eğer alıcı hesabına yüklenirken bir hata olursa para gönderici hesabına tekrar dönmeli. Bu işlemi Transaction ile kontrol ederiz.
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete(); //İşlem başarılıysa 
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); //İşlem başarısız olursa iptal et.
                    throw;
                }
            }
        }
    }
}
