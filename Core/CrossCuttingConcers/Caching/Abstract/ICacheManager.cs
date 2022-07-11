using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcers.Caching.Abstract
{
    public interface ICacheManager
    {
        //Bir kişi yakın zamanda herhangi bir business operasyonunu çaığırdığında o operasyonda bir
        //değişim olmadıysa belirli süre bellekte tutarız. Yeniden istek yapan kişiye database gitmeden
        //o veriyi vermek için.
        T Get<T>(string key); //Generik şekilde Cache döndürdük. Her türden nesne olabilir.
        object Get(string key); //Cache döndürdük. Generik şekilde döndürdüğümüzle aynı işi yapıyor. Burada tip dönüşümü yapmak zorundayız.
        void Add(string key, object value, int duration); //Metoda cache ekledik. duration bellekte tutulacağı süre.
        bool IsAdd(string key); //Cashe'te var mı diye kontrol ederiz. Yoksa bilgi databaseden gelir varsa Cache'ten.
        void Remove(string key); //Cache'i silme
        void RemoveByPattern(string pattern); //Cache'i silme. Mesela metodun adının içinde Get olanları sil.
    }
}
