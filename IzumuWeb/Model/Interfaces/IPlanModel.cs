//-----------------------------------------------------------------------
// <copyright file="IPlanModel" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifred</author>
// <date>28/07/2025 14:53:22</date>
// <summary>Código fuente clase IPlanModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Interfaces
{
    using IzumuWeb.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// IPlanModel.
    /// </summary>
	public interface IPlanModel
    {
        /// <summary>
        /// Method used to Get All Plans.
        /// </summary>
        /// <returns>List With All Plans.</returns>
        Task<List<PlanDto>?> All();

        /// <summary>
        /// Method used to Get One Plan.
        /// </summary>
        /// <param name="id">Plan Id.</param>
        /// <returns>Object with Plan info.</returns>
        Task<PlanDto?> Get(int id);
    }
}
