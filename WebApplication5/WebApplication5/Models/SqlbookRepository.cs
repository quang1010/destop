using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.ViewModel;

namespace WebApplication5.Models
{
    public class SqlbookRepository : ICakeRepository
    {
        private readonly AppDbContext context;
        public SqlbookRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Cake Create(Cake s)
        {
            context.cake.Add(s);
            context.SaveChanges();
            return s;
        }

        public bool Delete(int id)
        {
            var delStd = context.cake.Find(id);
            if (delStd != null)
            {
                context.cake.Remove(delStd);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Cake Edit(Cake s)
        {
            var editStd = context.cake.Attach(s);
            editStd.State = EntityState.Modified;
            context.SaveChanges();
            return s;
        }

        public Cake Get(int id)
        {
            return context.cake.Find(id);
        }

        public IEnumerable<Cake> Gets()
        {
            return context.cake;
        }

        D ICakeRepository.Get(int id)
        {
            var data = (from st in context.cake
                        join t in context.Category
                        on st.CategoryId equals
                        t.CategoryId
                        where st.Id == id
                        select new D()
                        {
                            Id = st.Id,
                            nameCake = st.nameCake,
                            ThanhPhan = st.ThanhPhan,
                            
                            Hsd = st.Hsd,
                            Nsx = st.Nsx,
                            GiaBan = st.GiaBan,
                            DaXoa=st.DaXoa,


                            CategoryName = t.CategoryName


                        }).FirstOrDefault();
            return data;
        }
    }
}
