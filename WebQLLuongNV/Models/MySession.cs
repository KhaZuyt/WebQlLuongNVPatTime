using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebQLLuongNV.Models
{
    public static class MySessions
    {
        // Lấy giá trị từ Session
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        // Đặt giá trị vào Session
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
