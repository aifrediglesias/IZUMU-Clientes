//-----------------------------------------------------------------------
// <copyright file="IDocumentTypeModel" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 14:52:55</date>
// <summary>Código fuente clase IDocumentTypeModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Interfaces
{
    using IzumuWeb.Dtos;
    using System.Collections.Generic;

    /// <summary>
    /// IDocumentTypeModel.
    /// </summary>
	public interface IDocumentTypeModel
    {
        /// <summary>
        /// Method used to Get All Documents Types.
        /// </summary>
        /// <returns>List With All Documents Types.</returns>
        Task<List<DocumentTypeDto>?> All();

        /// <summary>
        /// Method used to Get One Document Type.
        /// </summary>
        /// <param name="id">Document Type Id.</param>
        /// <returns>Object with Document Type Info.</returns>
        Task<DocumentTypeDto?> Get(int id);
    }
}
