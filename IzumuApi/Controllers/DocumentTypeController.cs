//-----------------------------------------------------------------------
// <copyright file="DocumentTypeController" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:41:46</date>
// <summary>Código fuente interfaz DocumentTypeController.</summary>
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
    public class DocumentTypeController : BaseController
    {
        #region Attributes

        /// <summary>
        /// Attribute used to application Logger.
        /// </summary>
        private readonly ILogger<DocumentTypeController> _logger;

        /// <summary>
        /// Attribute used to Document Type bussiness.
        /// </summary>
        private readonly IDocumentTypeBussiness _documentTypeBussiness;

        #endregion

        #region Constructors



        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTypeController"/> class.
        /// </summary>
        /// <param name="documentTypeBussiness"></param>
        /// <param name="logger">Application Logger.</param>
        public DocumentTypeController(IDocumentTypeBussiness documentTypeBussiness, ILogger<DocumentTypeController> logger)
            : base(logger)
        {
            {
                this._documentTypeBussiness = documentTypeBussiness;
                this._logger = logger;
            }
        }
        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Documents Types.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IActionResult All()
        {
            try
            {
                List<DocumentTypeDto>? documentTypeDtos = this._documentTypeBussiness.All();
                return this.HandleResponse(documentTypeDtos, EResponseMessage.OperacionOk().Message);

            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return this.HandleErrorResponse(HttpStatusCode.InternalServerError, "It wasn't posible process request.");
            }
        }

        /// <summary>
        /// Method used to Get Document Type by Id.
        /// </summary>
        /// <param name="id">Document Type Id.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                DocumentTypeDto? documentTypeDto = this._documentTypeBussiness.Get(id);
                return this.HandleResponse(documentTypeDto, EResponseMessage.OperacionOk().Message);

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
