//-----------------------------------------------------------------------
// <copyright file="IDocumentTypeBussiness" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 14:52:55</date>
// <summary>Código fuente clase IDocumentTypeBussiness.</summary>
//-----------------------------------------------------------------------
namespace IzumuBussiness.Interfaces
{
    using IzumuBussiness.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// IDocumentTypeBussiness.
    /// </summary>
	public interface IDocumentTypeBussiness
    {
        /// <summary>
        /// Method used to Get All Documents Types.
        /// </summary>
        /// <returns>List With All Documents Types.</returns>
        List<DocumentTypeDto>? All();

        /// <summary>
        /// Method used to Get One Document Type.
        /// </summary>
        /// <param name="id">Document Type Id.</param>
        /// <returns>Object with Document Type Info.</returns>
        DocumentTypeDto? Get(int id);
    }
}
