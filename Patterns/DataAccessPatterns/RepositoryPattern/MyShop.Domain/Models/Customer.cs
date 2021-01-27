using System;

namespace MyShop.Domain.Models
{
    public class Customer
    {
        private byte[] profilePicture;

        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public byte[] ProfilePicture 
        {
            get
            {
                if(profilePicture == null)
                {
                    profilePicture = ProfilePictureService.GetFor();
                }
                return profilePicture;
            }
        }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}
