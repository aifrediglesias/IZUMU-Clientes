//-----------------------------------------------------------------------
// <copyright file="PlanModel" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 22:01:11</date>
// <summary>Código fuente interfaz PlanModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Model.Implementations
{
    using IzumuAdapter;
    using IzumuWeb.Dtos;
    using IzumuWeb.Interfaces;
    using System.Collections.Generic;
    using System.Net.Http.Formatting;

    /// <summary>
    /// PlanModel.
    /// </summary>
    internal class PlanModel : BaseModel<PlanDto>, IPlanModel
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanModel"/> class.
        /// </summary>
        public PlanModel(IConfiguration configuration)
            : base(configuration)
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Plans.
        /// </summary>
        /// <returns>List With All Plans.</returns>
        public async Task<List<PlanDto>?> All()
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/plan/all");
                return await this.WebServicesConsumesManagerAdapter.All(url, new JsonMediaTypeFormatter(), null);
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Get One Plan.
        /// </summary>
        /// <param name="id">Plan Id.</param>
        /// <returns>Object with Plan info.</returns>
        public async Task<PlanDto?> Get(int id)
        {
            try
            {
                if (this.WebServicesConsumesManagerAdapter == null)
                    throw new WebServiceException("Error to Load Adapter");

                Uri url = new($"{this._urlIzumuApi}/plan");
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
