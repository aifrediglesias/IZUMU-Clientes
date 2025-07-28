//-----------------------------------------------------------------------
// <copyright file="IPlanBussiness" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 14:53:22</date>
// <summary>Código fuente clase IPlanBussiness.</summary>
//-----------------------------------------------------------------------
namespace IzumuBussiness.Interfaces
{
    using IzumuBussiness.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// IPlanBussiness.
    /// </summary>
	public interface IPlanBussiness
    {
        /// <summary>
        /// Method used to Get All Plans.
        /// </summary>
        /// <returns>List With All Plans.</returns>
        List<PlanDto>? All();

        /// <summary>
        /// Method used to Get One Plan.
        /// </summary>
        /// <param name="id">Plan Id.</param>
        /// <returns>Object with Plan info.</returns>
        PlanDto? Get(int id);
    }
}
