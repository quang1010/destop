using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Cake> categorys { get; set; }
        public string TitleName { get; set; }
    }
}
