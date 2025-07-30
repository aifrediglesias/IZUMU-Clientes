//-----------------------------------------------------------------------
// <copyright file="CustomerModel" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 20:33:33</date>
// <summary>Código fuente interfaz CustomerModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Model.Implementations
{
    using IzumuAdapter;
    using IzumuWeb.Dtos;
    using IzumuWeb.Interfaces;
    using IzumuWeb.Model;
    using System.Collections.Generic;
    using System.Net.Http.Formatting;

    /// <summary>
    /// CustomerModel.
    /// </summary>
    internal class CustomerModel : BaseModel<CustomerDto>, ICustomerModel
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerModel"/> class.
        /// </summary>
        public CustomerModel(IConfiguration configuration)
            : base(configuration)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Customers.
        /// </summary>
        /// <returns>List With All Customers.</returns>
        public async Task<List<CustomerDto>?> All()
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/Customer/all");
                return await this.WebServicesConsumesManagerAdapter.All(url, new JsonMediaTypeFormatter(), null);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Delete One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        public async Task Delete(int id)
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/Customer?id={id}");
                await this.WebServicesConsumesManagerAdapter.Delete(url, new JsonMediaTypeFormatter(), null, id);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Get One Customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns>Object with Customer info.</returns>
        public async Task<CustomerDto?> Get(int id)
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/Customer?id={id}");
                return await this.WebServicesConsumesManagerAdapter.Get(url, new JsonMediaTypeFormatter(), null);

            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Insert a new customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        public async Task Insert(CustomerDto customer)
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/Customer");
                await this.WebServicesConsumesManagerAdapter.Post(url, new JsonMediaTypeFormatter(), null, customer);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Update the customer.
        /// </summary>
        /// <param name="customer">Objet that containt the new customer.</param>
        public async Task Update(CustomerDto customer)
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/Customer");
                await this.WebServicesConsumesManagerAdapter.Put(url, new JsonMediaTypeFormatter(), null, customer);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        #endregion
    }
}
