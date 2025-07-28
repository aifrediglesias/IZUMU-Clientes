//-----------------------------------------------------------------------
// <copyright file="Customer" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 12:01:26</date>
// <summary>Código fuente interfaz Customer.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Customer.
    /// </summary>
	public class Customer
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets DocumentTypeId.
        /// </summary>
        public int DocumentTypeId { get; set; }

        /// <summary>
        /// Gets or sets DocumentType.
        /// </summary>
        [ForeignKey("DocumentTypeId")]
        public DocumentType? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets DocumentNumber.
        /// </summary>
        public string? DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets SecondName.
        /// </summary>
        public string? SecondName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets SecondLastName.
        /// </summary>
        public string? SecondLastName { get; set; }

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets PhoneNumber.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets CreatedAt.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets PlanId.
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// Gets or sets Plan.
        /// </summary>
        [ForeignKey("PlanId")]
        public Plan? Plan { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
