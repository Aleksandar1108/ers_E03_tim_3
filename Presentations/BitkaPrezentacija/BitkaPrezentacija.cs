using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Services;
using Services.BitkaServisi;
namespace Presentations.BitkaPrezentacija
{
    public class BitkaPrezentacija
    {
        private readonly IServisBitka bitka_servis; 

        public BitkaPrezentacija(IServisBitka bitka_servis)
        {
            this.bitka_servis = bitka_servis;
        }
    }
}
