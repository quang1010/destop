using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.ViewModel;

namespace WebApplication5.Models
{
    public interface ICakeRepository
    {
        IEnumerable<Cake> Gets();
        D Get(int id);
        Cake Create(Cake s);
        Cake Edit(Cake s);
        bool Delete(int id);
    }
}
