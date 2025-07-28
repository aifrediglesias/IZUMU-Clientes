//-----------------------------------------------------------------------
// <copyright file="IPlanRepository" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 12:19:34</date>
// <summary>Código fuente clase IPlanRepository.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Repositories.Interfaces
{
    using IzumuData.Entities;

    /// <summary>
    /// IPlanRepository.
    /// </summary>
	public interface IPlanRepository
    {
        /// <summary>
        /// Method used to Get All Plans.
        /// </summary>
        /// <returns>List With All Plans.</returns>
        List<Plan>? All();

        /// <summary>
        /// Method used to Get One Plan.
        /// </summary>
        /// <param name="id">Plan Id.</param>
        /// <returns>Object with Plan info.</returns>
        Plan? Get(int id);
    }
}
