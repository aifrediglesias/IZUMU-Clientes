//-----------------------------------------------------------------------
// <copyright file="PlanController" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:41:30</date>
// <summary>Código fuente interfaz PlanController.</summary>
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
    public class PlanController : BaseController
    {
        #region Attributes

        /// <summary>
        /// Attribute used to application Logger.
        /// </summary>
        private readonly ILogger<PlanController> _logger;

        /// <summary>
        /// Attribute used to plan bussiness.
        /// </summary>
        private readonly IPlanBussiness _planBussiness;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanController"/> class.
        /// </summary>
        /// <param name="planBussiness"></param>
        /// <param name="logger">Application Logger.</param>
        public PlanController(IPlanBussiness planBussiness, ILogger<PlanController> logger)
            : base(logger)
        {
            this._planBussiness = planBussiness;
            this._logger = logger;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Plans.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IActionResult All()
        {
            try
            {
                List<PlanDto>? plans = this._planBussiness.All();
                return this.HandleResponse(plans, EResponseMessage.OperacionOk().Message);

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, "It wasn't posible process request.");
            }
        }

        /// <summary>
        /// Method used to Get Plan by Id.
        /// </summary>
        /// <param name="id">Plan Id.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                PlanDto? plan = this._planBussiness.Get(id);
                return this.HandleResponse(plan, EResponseMessage.OperacionOk().Message);

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
