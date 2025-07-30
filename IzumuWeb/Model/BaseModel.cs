//-----------------------------------------------------------------------
// <copyright file="BaseModel" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 21:52:10</date>
// <summary>Código fuente interfaz BaseModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Model
{
    using IzumuAdapter.Implementations;
    using IzumuAdapter.Interfaces;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// BaseModel.
    /// </summary>
	internal class BaseModel<T>
    {
        #region Attributes

        /// <summary>
        /// WebServicesConsumesManagerAdapter.
        /// </summary>
        private IWebServicesConsumesManagerAdapter<T>? _webServicesConsumesManagerAdapter;

        /// <summary>
        /// Url Izumu API.
        /// </summary>
        protected string? _urlIzumuApi;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModel"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public BaseModel(IConfiguration configuration)
        {
            this._urlIzumuApi = configuration["Url_IzumuApi"];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets WebServicesConsumesManagerAdapter.
        /// </summary>
        protected IWebServicesConsumesManagerAdapter<T>? WebServicesConsumesManagerAdapter
        {
            get
            {
                this._webServicesConsumesManagerAdapter ??= new WebServicesConsumesManagerAdapter<T>();
                return this._webServicesConsumesManagerAdapter;
            }
        }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
