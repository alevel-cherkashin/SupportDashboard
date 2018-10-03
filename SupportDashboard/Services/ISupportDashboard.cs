using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDashboard.Services
{
    interface ISupportDashboard <T>
    {
        Task<List<T>> GetAll();

        Task<T> Get(int id);
    }
}
