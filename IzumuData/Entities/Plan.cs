//-----------------------------------------------------------------------
// <copyright file="Plan" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 11:59:23</date>
// <summary>Código fuente interfaz Plan.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Entities
{
    /// <summary>
    /// Plan.
    /// </summary>
	public class Plan
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Plan"/> class.
        /// </summary>
        public Plan()
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

        /// <summary>
        /// Gets or sets Customers.
        /// </summary>
        public List<Customer>? Customers { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
