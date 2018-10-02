using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace SupportDashboard.BusinessLogic.Service
{
    public abstract class AppService<T>
    {
        protected string _file;
        protected List<T> _items;

        public abstract void Add(T item);
        public abstract void Update(T item);
        public abstract void Delete(int id);

        public abstract T Get(int id);
        protected abstract int GetMaxId();

        public List<T> GetAll()
        {
            return _items;
        }

        protected void _save()
        {
            string items = JsonConvert.SerializeObject(_items);
            File.WriteAllText(_file, items);
        }
    }
}
