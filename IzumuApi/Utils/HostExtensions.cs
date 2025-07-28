//-----------------------------------------------------------------------
// <copyright file="HostExtensions" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifre</author>
// <date>28/07/2025 13:58:46</date>
// <summary>Código fuente interfaz HostExtensions.</summary>
//-----------------------------------------------------------------------
namespace IzumuApi.Utils
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Polly;
    using System;

    /// <summary>
    /// HostExtensions.
    /// </summary>
	public static class HostExtensions
    {
        #region Attributes

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// MigrateDbContext.
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="app"></param>
        /// <param name="seeder"></param>
        /// <returns></returns>
        public static WebApplication MigrateDbContext<TContext>(
            this WebApplication app,
            Action<TContext, IServiceProvider> seeder)
            where TContext : DbContext
        {
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<TContext>();
            var logger = services.GetRequiredService<ILogger<TContext>>();

            try
            {
                logger.LogInformation("Migrando base de datos: {DbContextName}", typeof(TContext).Name);

                var retry = Policy
                    .Handle<SqlException>()
                    .WaitAndRetry([
                        TimeSpan.FromSeconds(3),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(8)
                    ]);

                retry.Execute(() =>
                        {
                            context.Database.Migrate();
                            seeder(context, services);
                        });

                logger.LogInformation("Migración completada: {DbContextName}", typeof(TContext).Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al migrar la base de datos {DbContextName}", typeof(TContext).Name);
                throw;
            }

            return app;
        }
    }

    #endregion

}
