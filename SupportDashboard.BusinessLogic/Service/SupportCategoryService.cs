using SupportDashboard.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SupportDashboard.BusinessLogic.Service
{
    public class SupportCategoryService : AppService<Category>
    {
        public SupportCategoryService() 
        {
            _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "categories.txt");
            _items = JsonConvert.DeserializeObject<List<Category>>(File.ReadAllText(_file));
        }

        public override void Add(Category item)
        {
            item.Id = GetMaxId();
            _items.Add(item);
            _save();
        }

        public override void Delete(int id)
        {
            var item = Get(id);

            if (item != null)
            {
                _items.Remove(item);
                _save();
            }
        }

        public override Category Get(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        protected override int GetMaxId()
        {
            const int seed = 1;

            if (_items == null || !_items.Any())
                return seed;

            return _items.Max(x => x.Id) + seed;
        }

        public override void Update(Category item)
        {
            var category = Get(item.Id);
            category.Title = item.Title;
            _save();
        }
    }
}
