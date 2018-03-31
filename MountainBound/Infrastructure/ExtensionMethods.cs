using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MountainBound.Infrastructure
{
    public static class ExtensionMethods
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            var serializeObj = JsonConvert.SerializeObject(value);
            session.SetString(key, serializeObj);
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }

        

    }
}
