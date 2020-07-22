using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext context;
        public ClassRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Category Create(Category classss)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Edit(Category classs)
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            return context.Category.Find(id);
        }

        public IEnumerable<Category> Gets()
        {
            return context.Category;
        }
    }
}
