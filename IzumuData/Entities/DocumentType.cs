//-----------------------------------------------------------------------
// <copyright file="DocumentType" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 11:55:50</date>
// <summary>Código fuente interfaz DocumentType.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Entities
{
    /// <summary>
    /// DocumentType.
    /// </summary>
	public class DocumentType
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentType"/> class.
        /// </summary>
        public DocumentType()
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
        public virtual List<Customer>? Customers { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
