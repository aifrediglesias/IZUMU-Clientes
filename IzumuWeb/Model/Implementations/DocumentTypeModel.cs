//-----------------------------------------------------------------------
// <copyright file="DocumentTypeModel" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 22:02:58</date>
// <summary>Código fuente interfaz DocumentTypeModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Model.Implementations
{
    using IzumuAdapter;
    using IzumuWeb.Dtos;
    using IzumuWeb.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Formatting;

    /// <summary>
    /// DocumentTypeModel.
    /// </summary>
	internal class DocumentTypeModel : BaseModel<DocumentTypeDto>, IDocumentTypeModel
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTypeModel"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public DocumentTypeModel(IConfiguration configuration)
            : base(configuration)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Documents Types.
        /// </summary>
        /// <returns>List With All Documents Types.</returns>
        public async Task<List<DocumentTypeDto>?> All()
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/DocumentType/all");
                return await this.WebServicesConsumesManagerAdapter.All(url, new JsonMediaTypeFormatter(), null);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Get One Document Type.
        /// </summary>
        /// <param name="id">Document Type Id.</param>
        /// <returns>Object with Document Type Info.</returns>
        public async Task<DocumentTypeDto?> Get(int id)
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/DocumentType");
                return await this.WebServicesConsumesManagerAdapter.Get(url, new JsonMediaTypeFormatter(), null);

            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        #endregion
    }
}
