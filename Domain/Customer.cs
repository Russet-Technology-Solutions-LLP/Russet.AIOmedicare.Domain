 using System.Collections.Generic;
using System.Linq;

namespace Russet.AIOmedicare.Domain.Domain
{
    public sealed class Customer : Person
    {
        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>The addresses.</value>
        public IList<Address> Addresses { get; set; }

        /// <summary>
        /// Gets the default address.
        /// </summary>
        /// <value>The default address.</value>
        public Address DefaultAddress
        {
            get
            {
                if (Addresses == null)
                {
                    return null;
                }
                return Addresses.Where(x => x.IsDefault).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>The orders.</value>
        //public IList<Order> Orders { get; set; }

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="address">The address.</param>
        public void AddAddress(Address address)
        {
            if (Addresses == null)
            {
                Addresses = new List<Address>();
            }
            if (Addresses.Where(x => x.IsDefault).Count() < 1)
            {
                address.IsDefault = true;
            }
            if (!Addresses.Any(x => x.PrimaryKey == address.PrimaryKey))
            {
                Addresses.Add(address);
            }
        }

        /// <summary>
        /// Removes the address.
        /// </summary>
        /// <param name="address">The address.</param>
        public void RemoveAddress(Address address)
        {
            if (Addresses != null && Addresses.Contains(address))
            {
                Addresses.Remove(address);
                if (address.IsDefault)
                {
                    Addresses.FirstOrDefault().IsDefault = true;
                }
            }
        }

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /*
        public void AddOrder(Order order)
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
            Orders.Add(order);
        }
        */

        /// <summary>
        /// Removes the order.
        /// </summary>
        /// <param name="order">The order.</param>
        /*
        public void RemoveOrder(Order order)
        {
            if (Orders != null && Orders.Contains(order))
            {
                Orders.Remove(order);
            }
        }
        */
    }
}
