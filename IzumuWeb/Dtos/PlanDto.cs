//-----------------------------------------------------------------------
// <copyright file="PlanDto" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:16:44</date>
// <summary>Código fuente interfaz PlanDto.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Dtos
{
    /// <summary>
    /// PlanDto.
    /// </summary>
    public class PlanDto
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanDto"/> class.
        /// </summary>
        public PlanDto()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets CreatedAt.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
