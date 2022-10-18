using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class PathConstants
    {
        public static string ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images");
    }
}
