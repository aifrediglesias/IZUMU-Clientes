//-----------------------------------------------------------------------
// <copyright file="DocumentTypeBussiness" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 15:05:40</date>
// <summary>Código fuente interfaz DocumentTypeBussiness.</summary>
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
    /// DocumentTypeBussiness.
    /// </summary>
	public class DocumentTypeBussiness : IDocumentTypeBussiness
    {
        #region Attributes

        /// <summary>
        /// Db Context.
        /// </summary>
        private IzumuContext? _context;

        /// <summary>
        /// Document Type Repository.
        /// </summary>
        private DocumentTypeRepository? _documentTypeRepository;

        /// <summary>
        /// Mapper.
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTypeBussiness"/> class.
        /// </summary>
        /// <param name="izumuContext">Db Context.</param>
        /// <param name="mapper">Mapper.</param>
        public DocumentTypeBussiness(IzumuContext izumuContext, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = izumuContext;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Method used to get Document Type Repository.
        /// </summary>
        private IDocumentTypeRepository? DocumentTypeRepository
        {
            get
            {
                if (this._context != null && this._documentTypeRepository == null)
                    this._documentTypeRepository = new DocumentTypeRepository(this._context);

                return this._documentTypeRepository;
            }
        }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to Get All Documents Types.
        /// </summary>
        /// <returns>List With All Documents Types.</returns>
        public List<DocumentTypeDto>? All()
        {
            List<DocumentType>? documents = this.DocumentTypeRepository?.All();
            return this._mapper.Map<List<DocumentTypeDto>>(documents);
        }

        /// <summary>
        /// Method used to Get One Document Type.
        /// </summary>
        /// <param name="id">Document Type Id.</param>
        /// <returns>Object with Document Type Info.</returns>
        public DocumentTypeDto? Get(int id)
        {
            DocumentType? documentType = this.DocumentTypeRepository?.Get(id);
            return this._mapper.Map<DocumentTypeDto>(documentType);
        }

        #endregion
    }
}
