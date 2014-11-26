using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopMVC.WebShopWCF;

namespace WebShopMVC
{
   public class ViewModelConsoleGenre
    {
        public ModelKonsolDTO[] Consoles { get; set; }
        public ModelGenreDTO[] Genres { get; set; }
        public ModelPersonDTO Person { get; set; }

    }
}
