using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Lazy
{
    public class CustomerProxy : Customer
    {
        private readonly Customer c;

        public CustomerProxy()
        {
        }
        public CustomerProxy(Customer c)
        {
            this.c = c;
        }
        public override byte[] ProfilePicture
        {
            get
            {
                if (base.ProfilePicture == null)
                {
                    base.ProfilePicture = ProfilePictureService.GetFor(Name);
                }

                return base.ProfilePicture;
            }
        }
    }
}
