//-----------------------------------------------------------------------
// <copyright file="PlanBussiness" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:05:22</date>
// <summary>Código fuente interfaz PlanBussiness.</summary>
//-----------------------------------------------------------------------
namespace IzumuBussiness.Implementations
{
    using AutoMapper;
    using IzumuBussiness.Dtos;
    using IzumuBussiness.Interfaces;
    using IzumuData;
    using IzumuData.Entities;
    using IzumuData.Repositories.Implementations;
    using IzumuData.Repositories.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// PlanBussiness.
    /// </summary>
	public class PlanBussiness : IPlanBussiness
    {
        #region Attributes

        /// <summary>
        /// Db Context.
        /// </summary>
        private IzumuContext? _context;

        /// <summary>
        /// Plan Repository.
        /// </summary>
        private PlanRepository? _planRepository;

        /// <summary>
        /// Mapper.
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanBussiness"/> class.
        /// </summary>
        /// <param name="izumuContext">Db Context.</param>
        /// <param name="mapper">Mapper.</param>
        public PlanBussiness(IzumuContext izumuContext, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = izumuContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Method used to get Plan Repository.
        /// </summary>
        private IPlanRepository? PlanRepository
        {
            get
            {
                if (this._context != null && this._planRepository == null)
                    this._planRepository = new PlanRepository(this._context);

                return this._planRepository;
            }
        }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Plans.
        /// </summary>
        /// <returns>List With All Plans.</returns>
        public List<PlanDto>? All()
        {
            List<Plan>? plans = this.PlanRepository?.All();
            return this._mapper.Map<List<PlanDto>>(plans);
        }

        /// <summary>
        /// Method used to Get One Plan.
        /// </summary>
        /// <param name="id">Plan Id.</param>
        /// <returns>Object with Plan info.</returns>
        public PlanDto? Get(int id)
        {
            Plan? plan = this.PlanRepository?.Get(id);
            return this._mapper.Map<PlanDto>(plan);
        }

        #endregion
    }
}
