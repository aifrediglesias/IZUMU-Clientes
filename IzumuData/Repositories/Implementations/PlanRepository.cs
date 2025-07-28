//-----------------------------------------------------------------------
// <copyright file="PlanRepository" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 12:21:35</date>
// <summary>Código fuente interfaz PlanRepository.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Repositories.Implementations
{
    using IzumuData.Entities;
    using IzumuData.Repositories.Interfaces;
    using IzumuData.UnitOfWork;
    using System.Collections.Generic;

    /// <summary>
    /// PlanRepository.
    /// </summary>
    public class PlanRepository : IPlanRepository
    {
        #region Attributes

        /// <summary>
        /// Unit Of Work.
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// Db Context.
        /// </summary>
        private IzumuContext? _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanRepository"/> class.
        /// </summary>
        /// <param name="izumuContext">Db Context.</param>
        public PlanRepository(IzumuContext izumuContext)
        {
            this._context = izumuContext;
            this._unitOfWork = new UnitOfWork(izumuContext);
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Plans.
        /// </summary>
        /// <returns>List With All Plans.</returns>
        public List<Plan>? All()
        {
            try
            {
                return this._context?.Plans.ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Get One Plan.
        /// </summary>
        /// <param name="id">Plan Id.</param>
        /// <returns>Object with Plan info.</returns>
        public Plan? Get(int id)
        {
            try
            {
                return this._context?.Plans
                    .FirstOrDefault(f => f.Id == id);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        #endregion
    }
}
