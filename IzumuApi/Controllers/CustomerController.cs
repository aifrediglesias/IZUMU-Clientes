//-----------------------------------------------------------------------
// <copyright file="CustomerController" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:41:11</date>
// <summary>Código fuente interfaz CustomerController.</summary>
//-----------------------------------------------------------------------
namespace IzumuApi.Controllers
{
    using IzumuBussiness.Dtos;
    using IzumuBussiness.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    /// <summary>
    /// Class.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        #region Attributes

        /// <summary>
        /// Attribute used to application Logger.
        /// </summary>
        private readonly ILogger<CustomerController> _logger;

        /// <summary>
        /// Attribute used to Customer bussiness.
        /// </summary>
        private readonly ICustomerBussiness _customerBussiness;

        #endregion

        #region Constructors



        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerBussiness"></param>
        /// <param name="logger">Application Logger.</param>
        public CustomerController(ICustomerBussiness customerBussiness, ILogger<CustomerController> logger)
            : base(logger)
        {
            this._customerBussiness = customerBussiness;
            this._logger = logger;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IActionResult All()
        {
            try
            {
                List<CustomerDto>? customer = this._customerBussiness.All();
                return this.HandleResponse(customer, EResponseMessage.OperacionOk().Message);

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, "It wasn't posible process request.");
            }
        }

        /// <summary>
        /// Method used to Get Customer by Id.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                CustomerDto? customer = this._customerBussiness.Get(id);
                return this.HandleResponse(customer, EResponseMessage.OperacionOk().Message);

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, "It wasn't posible process request.");
            }
        }

        /// <summary>
        /// Method used to insert new customer.
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert(CustomerDto customerDto)
        {
            try
            {
                this._customerBussiness.Insert(customerDto);
                return this.HandleResponse(null, EResponseMessage.OperacionOk().Message);

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, "It wasn't posible process request.");
            }
        }

        /// <summary>
        /// Method used to Remove a customer.
        /// </summary>
        /// <param name="id">Customer Id.</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            try
            {
                this._customerBussiness.Delete(id);
                return this.HandleResponse(null, EResponseMessage.OperacionOk().Message);

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, "It wasn't posible process request.");
            }
        }

        /// <summary>
        /// Method used to updates a customer.
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CustomerDto customerDto)
        {
            try
            {
                this._customerBussiness.Update(customerDto);
                return this.HandleResponse(null, EResponseMessage.OperacionOk().Message);

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, "It wasn't posible process request.");
            }
        }

        #endregion
    }
}
