//-----------------------------------------------------------------------
// <copyright file="CustomerDto" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:16:32</date>
// <summary>Código fuente interfaz CustomerDto.</summary>
//-----------------------------------------------------------------------
using IzumuData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IzumuBussiness.Dtos
{
    /// <summary>
    /// CustomerDto.
    /// </summary>
	public class CustomerDto
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDto"/> class.
        /// </summary>
        public CustomerDto()
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
        /// Gets or sets PlanId.
        /// </summary>
        public int PlanId { get; set; }

        /// <summary>
        /// Gets or sets CreatedAt.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        #endregion

        #region Methods And Functions

        #endregion
    }
}
