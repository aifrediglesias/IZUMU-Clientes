//-----------------------------------------------------------------------
// <copyright file="CustomerRepository" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 12:20:29</date>
// <summary>Código fuente interfaz CustomerRepository.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Repositories.Implementations
{
    using IzumuData.Entities;
    using IzumuData.Repositories.Interfaces;
    using IzumuData.UnitOfWork;
    using System.Collections.Generic;

    /// <summary>
    /// CustomerRepository.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        #region Attributes

        /// <summary>
        /// Unit Of Work.
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// Db Context.
        /// </summary>
        private IzumuContext? _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="izumuContext">Db Context.</param>
        public CustomerRepository(IzumuContext izumuContext)
        {
            this._context = izumuContext;
            this._unitOfWork = new UnitOfWork(izumuContext);
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Customers.
        /// </summary>
        /// <returns>List With All Customers.</returns>
        public List<Customer>? All()
        {
            try
            {
                return this._context?.Customers.ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Delete One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        public void Delete(int id)
        {
            try
            {
                Customer? customer = this._context?.Customers.FirstOrDefault(x => x.Id == id);
                if (customer != null)
                {
                    this._context?.Customers.Remove(customer);
                    this._unitOfWork.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Get One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns>Object with Customer info.</returns>
        public Customer? Get(int id)
        {
            try
            {
                return this._context?.Customers
                    .FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Insert a new customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        public void Insert(Customer customer)
        {
            try
            {
                this._context?.Customers.Add(customer);
                this._unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Update the customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        public void Update(Customer customer)
        {
            try
            {
                this._context?.Customers.Update(customer);
                this._unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        #endregion
    }
}
