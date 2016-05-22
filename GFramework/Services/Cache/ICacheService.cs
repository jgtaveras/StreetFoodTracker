using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFramework.Services.Cache
{
    public interface ICacheService
    {
        Task InsertObject<T>(string key, T value, DateTimeOffset? expiration);
        Task<T> GetObject<T>(string key);
        Task<IEnumerable<T>> GetObjects<T>();
        Task RemoveObject(string key);

    }
}
