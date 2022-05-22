using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) //:base(...) Base sınıfa yani DataResulta yazılı bilgileri iletir.
        {
            // data ve mesaj döner
        }
        public SuccessDataResult(T data) : base(data, true)
        {
            // sadece data döner ekrana mesaj yazdırmaz
        }
        public SuccessDataResult(string message) : base(default, true, message)
        {
            //datanın default halini getirir mesaj ile birlikte
        }
        public SuccessDataResult() : base(default, true)
        {
            //datanın default halini getirir
        }
    }
}
