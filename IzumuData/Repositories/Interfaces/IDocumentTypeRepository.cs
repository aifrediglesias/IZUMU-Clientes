//-----------------------------------------------------------------------
// <copyright file="IDocumentTypeRepository" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 12:19:57</date>
// <summary>Código fuente clase IDocumentTypeRepository.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Repositories.Interfaces
{
    using IzumuData.Entities;

    /// <summary>
    /// IDocumentTypeRepository.
    /// </summary>
	public interface IDocumentTypeRepository
    {
        /// <summary>
        /// Method used to Get All Documents Types.
        /// </summary>
        /// <returns>List With All Documents Types.</returns>
        List<DocumentType>? All();

        /// <summary>
        /// Method used to Get One Document Type.
        /// </summary>
        /// <param name="id">Document Type Id.</param>
        /// <returns>Object with Document Type Info.</returns>
        DocumentType? Get(int id);
    }
}
