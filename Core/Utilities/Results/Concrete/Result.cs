﻿using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        

        public Result(bool success, string message):this(success) //Burayı çalıştır aynı zamanda success'i de çalıştır. Bu sayede ister ekrana mesaj veririm ister vermem. This sınıfa iletilecek mesajı içerir.
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}