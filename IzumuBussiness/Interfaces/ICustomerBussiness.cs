//-----------------------------------------------------------------------
// <copyright file="ICustomerBussiness" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 14:52:27</date>
// <summary>Código fuente clase ICustomerBussiness.</summary>
//-----------------------------------------------------------------------
namespace IzumuBussiness.Interfaces
{
    using IzumuBussiness.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// ICustomerBussiness.
    /// </summary>
	public interface ICustomerBussiness
    {
        /// <summary>
        /// Method used to Get All Customers.
        /// </summary>
        /// <returns>List With All Customers.</returns>
        List<CustomerDto>? All();

        /// <summary>
        /// Method used to Delete One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        void Delete(int id);

        /// <summary>
        /// Method used to Get One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns>Object with Customer info.</returns>
        CustomerDto? Get(int id);

        /// <summary>
        /// Method used to Insert a new customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        void Insert(CustomerDto customer);

        /// <summary>
        /// Method used to Update the customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        void Update(CustomerDto customer);
    }
}
