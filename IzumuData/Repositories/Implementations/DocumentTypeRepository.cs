//-----------------------------------------------------------------------
// <copyright file="DocumentTypeRepository" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 12:22:23</date>
// <summary>Código fuente interfaz DocumentTypeRepository.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.Repositories.Implementations
{
    using IzumuData.Entities;
    using IzumuData.Repositories.Interfaces;
    using IzumuData.UnitOfWork;
    using System.Collections.Generic;

    /// <summary>
    /// DocumentTypeRepository.
    /// </summary>
    public class DocumentTypeRepository : IDocumentTypeRepository
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
        /// Initializes a new instance of the <see cref="DocumentTypeRepository"/> class.
        /// </summary>
        /// <param name="izumuContext">Db Context.</param>
        public DocumentTypeRepository(IzumuContext izumuContext)
        {
            this._context = izumuContext;
            this._unitOfWork = new UnitOfWork(izumuContext);
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Documents Types.
        /// </summary>
        /// <returns>List With All Documents Types.</returns>
        public List<DocumentType>? All()
        {
            try
            {
                return this._context?.DocumentsTypes.ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        /// <summary>
        /// Method used to Get One Document Type.
        /// </summary>
        /// <param name="id">Document Type Id.</param>
        /// <returns>Object with Document Type Info.</returns>
        public DocumentType? Get(int id)
        {
            try
            {
                return this._context?.DocumentsTypes
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
