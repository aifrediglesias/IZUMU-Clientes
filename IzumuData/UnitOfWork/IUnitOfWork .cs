//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifred</author>
// <date>18/07/2025 17:52:05</date>
// <summary>Código fuente clase IUnitOfWork.</summary>
//-----------------------------------------------------------------------
namespace IzumuData.UnitOfWork
{
    /// <summary>
    /// IUnitOfWork.
    /// </summary>
	internal interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Managmenting the storage when the changes were made.
        /// </summary>
        Task SaveChanges();

        /// <summary>
        /// Managmenting the storage when the changes were made asynchronously.
        /// </summary>
        Task SaveChangesAsync();
    }
}
