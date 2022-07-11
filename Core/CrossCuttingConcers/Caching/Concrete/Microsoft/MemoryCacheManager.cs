using Core.CrossCuttingConcers.Caching.Abstract;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcers.Caching.Concrete.Microsoft
{      
    //Adapter Pattern: varolan sistemi kendi sistemimize uyarladık.
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache; //Microsoftun kendi Cache yönteminin interface'i
        // Consracter ile çalıştıramayız. Çünkü zincir içinde değil. Bunlar Cross Cuting Concer.
        //O yüzden ICoreModule ile enjekte edilmeli.

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _); //Birşey döndürmek istemediğimiz için _ yaptık. C#ta bişey döndürme demek böyle
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern) //Çalışma anında bellekten silmeye yarar.
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //Çalışırken git belleğe bak MemoryCache türünde (.Net bunları EnteriesCollection ismiyle tutar) olanları getir.
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            // Onların içinde _memoryCache olanları bul
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //Yazılan pattern bu özelliklerde olacak.
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
            //yazdığımız patterne göre filtrele uygun olanları listele
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key); //listenin içindekileri bellekten sil.
            }
        }
    }
}
