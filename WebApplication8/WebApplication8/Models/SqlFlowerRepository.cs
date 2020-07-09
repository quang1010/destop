using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class SqlFlowerRepository : IFlowerRepository
    {
        private readonly AppDbContext context;

        public SqlFlowerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Flower Create(Flower flower)
        { 
            context.Flowers.Add(flower);
            context.SaveChanges();
            return flower;
        }

        public bool Delete(int id)
        {
            var delEmp = context.Flowers.Find(id);
            if (delEmp != null)
            {
                context.Flowers.Remove(delEmp);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Flower Edit(Flower flower)
        {
            var editEmp = context.Flowers.Attach(flower);
            editEmp.State = EntityState.Modified;
            context.SaveChanges();
            return flower;
        }

        public Flower Get(int id)
        {
            return context.Flowers.Find(id);
        }

        public IEnumerable<Flower> Gets()
        {
            return context.Flowers;
        }
    }
}
