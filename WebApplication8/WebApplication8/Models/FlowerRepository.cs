using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class FlowerRepository : IFlowerRepository
    {
        private List<Flower> flowers;
        public FlowerRepository()
        {
            flowers = new List<Flower>()
            {
                new Flower()
                {
                    AvatarPath = "images/lan1.jpg",
                    TypeF= Dept.Hoa_Lan,
                   
                    Id = 1,
                    Name = "Lan Vàng"
                },
                new Flower()
                {
                    AvatarPath = "images/giaytim.jpg",
                    TypeF= Dept.Hoa_Giấy,
                    
                    Id = 2,
                    Name = "Hoa Giấy Tím"
                }
            };
        }

        public Flower Create(Flower flower)
        {
            flower.Id = flowers.Max(e => e.Id) + 1;
            flower.AvatarPath = "images/lan1.jpg";
            flowers.Add(flower);
            return flower;
        }

        public bool Delete(int id)
        {
            var delEmp = Get(id);
            if (delEmp != null)
            {
                flowers.Remove(delEmp);
                return true;
            }
            return false;
        }

        public Flower Edit(Flower flower)
        {
            var editEmp = Get(flower.Id);
            editEmp.Name = flower.Name;
            
            editEmp.TypeF = flower.TypeF;
            return editEmp;
        }

        public Flower Get(int id)
        {
            return flowers.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Flower> Gets()
        {
            return flowers;
        }
    }
}
