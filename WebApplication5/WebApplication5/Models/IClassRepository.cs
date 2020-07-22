using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public interface IClassRepository
    {
        IEnumerable<Category> Gets();
        Category Get(int id);
        Category Create(Category classss);
        Category Edit(Category classs);
        bool Delete(int id);
    }
}
