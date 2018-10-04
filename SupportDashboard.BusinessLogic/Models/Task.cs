using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDashboard.BusinessLogic.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Decription { get; set; }

        public int CategoryId { get; set; }
    }
}
