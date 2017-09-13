using System;

namespace DotNet.Infrastructure.Interface
{
    public interface ICacheWriter
    {
        void Set(string key, object value, DateTime exp);
        void Set(string key, object value);
        object Get(string key);
        void Remove(string key);
    }
}