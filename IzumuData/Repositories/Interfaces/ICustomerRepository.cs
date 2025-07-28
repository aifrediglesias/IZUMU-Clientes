//-----------------------------------------------------------------------
// <copyright file="ICustomerRepository" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 12:18:54</date>
// <summary>Código fuente clase ICustomerRepository.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Repositories.Interfaces
{
    using IzumuData.Entities;

    /// <summary>
    /// ICustomerRepository.
    /// </summary>
	public interface ICustomerRepository
    {
        /// <summary>
        /// Method used to Get All Customers.
        /// </summary>
        /// <returns>List With All Customers.</returns>
        List<Customer>? All();

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
        Customer? Get(int id);

        /// <summary>
        /// Method used to Insert a new customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        void Insert(Customer customer);

        /// <summary>
        /// Method used to Update the customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        void Update(Customer customer);
    }
}
