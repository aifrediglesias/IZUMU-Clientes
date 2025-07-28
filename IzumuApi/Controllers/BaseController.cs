//-----------------------------------------------------------------------
// <copyright file="BaseController" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifred</author>
// <date>28/07/2025 15:54:53</date>
// <summary>Código fuente interfaz BaseController.</summary>
//-----------------------------------------------------------------------
namespace IzumuApi.Controllers
{
    using IzumuApi.Utils;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    /// <summary>
    /// Class.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BaseController : Controller
    {
        #region Attributes

        /// <summary>
        /// Attribute used to application Logger.
        /// </summary>
        private readonly ILogger<BaseController> _logger;

        #endregion

        #region Constructors



        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="logger">Application Logger.</param>
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="code">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleErrorResponse(HttpStatusCode code, object? message)
        {
            return this.StatusCode((int)code, ResponseResult.CreateError(message, new object()));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="code">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <param name="data">objeto respuesta.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleErrorResponse(HttpStatusCode code, string? message, object? data)
        {
            return this.StatusCode((int)code, ResponseResult.CreateError(message, data));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="data">Enumerado con el error asosiado.</param>
        /// <param name="message">Mensaje asociado el error.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleResponse(object? data, string? message)
        {
            return this.Ok(ResponseResult.CreateResponse(true, message, data));
        }

        /// <summary>
        /// Gestiona los mensajes de error que envían como respuesta a una petición.
        /// </summary>
        /// <param name="data">Enumerado con el error asosiado.</param>
        /// <returns>Resultado de la solicitud.</returns>
        protected IActionResult HandleResponse(object? data)
        {
            return this.Ok(ResponseResult.CreateResponse(true, null, data));
        }

        #endregion
    }
}
