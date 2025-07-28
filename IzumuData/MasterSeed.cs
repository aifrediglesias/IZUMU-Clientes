//-----------------------------------------------------------------------
// <copyright file="MasterSeed" company="Chubb">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 13:02:40</date>
// <summary>Código fuente interfaz MasterSeed.</summary>
//-----------------------------------------------------------------------
namespace IzumuData
{
    using IzumuData.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// MasterSeed.
    /// </summary>
	public static class MasterSeed
    {
        #region Attributes

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Seed.
        /// </summary>
        /// <param name="izumuContext"></param>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async void Seed(IzumuContext izumuContext, IServiceProvider serviceProvider)
        {
            if (izumuContext == null)
                return;

            using (izumuContext)
            {
                izumuContext.Database.Migrate();
                if (!izumuContext.DocumentsTypes.Any())
                {
                    izumuContext.DocumentsTypes.AddRange(GetPreconfiguredDocumentsTypes());
                    await izumuContext.SaveChangesAsync();
                }
                if (!izumuContext.Plans.Any())
                {
                    izumuContext.Plans.AddRange(GetPreconfiguredPlans());
                    await izumuContext.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// GetPreconfiguredDocumentsTypes.
        /// </summary>
        /// <returns></returns>
        static IEnumerable<DocumentType> GetPreconfiguredDocumentsTypes()
        {
            return
           [
               new DocumentType() {  Name = "Cédula de ciudadanía (CC)", Description = "", CreatedAt = DateTime.Now, Customers = null },
               new DocumentType() {  Name = "Pasaporte (PP)", Description = "", CreatedAt = DateTime.Now, Customers = null },
               new DocumentType() {  Name = "Cédula de extranjería (CE)", Description = "", CreatedAt = DateTime.Now, Customers = null },
               new DocumentType() {  Name = "Tarjeta de Identidad (TI)", Description = "", CreatedAt = DateTime.Now, Customers = null }
           ];
        }

        /// <summary>
        /// GetPreconfiguredPlans.
        /// </summary>
        /// <returns></returns>
        static IEnumerable<Plan> GetPreconfiguredPlans()
        {
            return
            [
                new Plan() {  Name = "Plan Diamante", Description = "", CreatedAt = DateTime.Now, Customers = null },
                new Plan() {  Name = "Plan Zafiro", Description = "", CreatedAt = DateTime.Now, Customers = null },
                new Plan() {  Name = "Plan Rubí", Description = "", CreatedAt = DateTime.Now, Customers = null },
                new Plan() {  Name = "Plan Oro", Description = "", CreatedAt = DateTime.Now, Customers = null },
                new Plan() {  Name = "Plan Básico", Description = "", CreatedAt = DateTime.Now, Customers = null },
                new Plan() {  Name = "Plan Plata", Description = "", CreatedAt = DateTime.Now, Customers = null }
            ];
        }

        #endregion
    }
}
