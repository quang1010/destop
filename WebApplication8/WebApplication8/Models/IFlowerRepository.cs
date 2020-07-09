using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public interface IFlowerRepository
    {
        IEnumerable<Flower> Gets();
        Flower Get(int id);
        Flower Create(Flower flower);
        Flower Edit(Flower flower);
        bool Delete(int id);
    }
}
