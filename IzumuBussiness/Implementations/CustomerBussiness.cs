//-----------------------------------------------------------------------
// <copyright file="CustomerBussiness" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:05:00</date>
// <summary>Código fuente interfaz CustomerBussiness.</summary>
//-----------------------------------------------------------------------
namespace IzumuBussiness.Implementations
{
    using AutoMapper;
    using IzumuBussiness.Dtos;
    using IzumuBussiness.Interfaces;
    using IzumuData;
    using IzumuData.Entities;
    using IzumuData.Repositories.Implementations;
    using IzumuData.Repositories.Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// CustomerBussiness.
    /// </summary>
	public class CustomerBussiness : ICustomerBussiness
    {
        #region Attributes

        /// <summary>
        /// Db Context.
        /// </summary>
        private IzumuContext? _context;

        /// <summary>
        /// Customer Repository.
        /// </summary>
        private CustomerRepository? _customerRepository;

        /// <summary>
        /// Mapper.
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBussiness"/> class.
        /// </summary>
        /// <param name="izumuContext">Db Context.</param>
        /// <param name="mapper">Mapper.</param>
        public CustomerBussiness(IzumuContext izumuContext, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = izumuContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Method used to get Customer Repository.
        /// </summary>
        private ICustomerRepository? CustomerRepository
        {
            get
            {
                if (this._context != null && this._customerRepository == null)
                    this._customerRepository = new CustomerRepository(this._context);

                return this._customerRepository;
            }
        }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Customers.
        /// </summary>
        /// <returns>List With All Customers.</returns>
        public List<CustomerDto>? All()
        {
            List<Customer>? customers = this.CustomerRepository?.All();
            return this._mapper.Map<List<CustomerDto>>(customers);
        }

        /// <summary>
        /// Method used to Delete One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        public void Delete(int id)
        {
            this.CustomerRepository?.Delete(id);
        }

        /// <summary>
        /// Method used to Get One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns>Object with Customer info.</returns>
        public CustomerDto? Get(int id)
        {
            Customer? customer = this.CustomerRepository?.Get(id);
            return this._mapper.Map<CustomerDto>(customer);
        }

        /// <summary>
        /// Method used to Insert a new customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        public void Insert(CustomerDto customer)
        {
            Customer customer1 = this._mapper.Map<Customer>(customer);
            if (customer1 != null)
            {
                customer1.CreatedAt = DateTime.Now;
                this.CustomerRepository?.Insert(customer1);
            }
        }

        /// <summary>
        /// Method used to Update the customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        public void Update(CustomerDto customer)
        {
            Customer customer1 = this._mapper.Map<Customer>(customer);
            if (customer1 != null)
            {
                customer1.CreatedAt = DateTime.Now;
                this.CustomerRepository?.Update(customer1);
            }
        }

        #endregion
    }
}
