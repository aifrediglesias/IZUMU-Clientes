//-----------------------------------------------------------------------
// <copyright file="ICustomerModel" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifred</author>
// <date>28/07/2025 14:52:27</date>
// <summary>Código fuente clase ICustomerModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Interfaces
{
    using IzumuWeb.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// ICustomerModel.
    /// </summary>
	public interface ICustomerModel
    {
        /// <summary>
        /// Method used to Get All Customers.
        /// </summary>
        /// <returns>List With All Customers.</returns>
        Task<List<CustomerDto>?> All();

        /// <summary>
        /// Method used to Delete One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        Task Delete(int id);

        /// <summary>
        /// Method used to Get One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns>Object with Customer info.</returns>
        Task<CustomerDto?> Get(int id);

        /// <summary>
        /// Method used to Insert a new customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        Task Insert(CustomerDto customer);

        /// <summary>
        /// Method used to Update the customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        Task Update(CustomerDto customer);
    }
}
