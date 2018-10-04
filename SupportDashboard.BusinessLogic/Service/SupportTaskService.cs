using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SupportDashboard.BusinessLogic.Models;

namespace SupportDashboard.BusinessLogic.Service
{
    public class SupportTaskService : AppService<Models.Task>
    {

        public SupportTaskService()
        {
            _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "tasks.txt");
            _items = JsonConvert.DeserializeObject<List<Models.Task>>(File.ReadAllText(_file));
        }

        public override void Add(Models.Task item)
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

        public override Models.Task Get(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Models.Task item)
        {
            var task = Get(item.Id);

            task.Title = item.Title;
            task.Decription = item.Decription;
            task.CategoryId = item.CategoryId;

            _save();
        }

        protected override int GetMaxId()
        {
            const int seed = 1;

            if (_items == null || !_items.Any())
                return seed;

            return _items.Max(x => x.Id) + seed;
        }
    }
}
