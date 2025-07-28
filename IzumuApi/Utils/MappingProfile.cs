//-----------------------------------------------------------------------
// <copyright file="MappingProfile" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>18/07/2025 20:57:14</date>
// <summary>Código fuente interfaz MappingProfile.</summary>
//-----------------------------------------------------------------------

namespace IzumuApi.Utils
{
    using AutoMapper;
    using IzumuBussiness.Dtos;
    using IzumuData.Entities;

    /// <summary>
    /// MappingProfile.
    /// </summary>
    internal class MappingProfile : Profile
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Plan, PlanDto>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        #endregion
    }
}
