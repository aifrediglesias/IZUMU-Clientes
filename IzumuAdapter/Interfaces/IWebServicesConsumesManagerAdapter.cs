//-----------------------------------------------------------------------
// <copyright file="IWebServicesConsumesManagerAdapter.cs" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>Aifred</author>
// <date>29/03/2020 17:02:19</date>
// <summary>Código fuente clase IWebServicesConsumesManagerAdapter.</summary>
//-----------------------------------------------------------------------
namespace IzumuAdapter.Interfaces
{
    using System;
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Se definen los métodos de gestionar cualquier consumo con un api de tercero.
    /// </summary>
    public interface IWebServicesConsumesManagerAdapter<T>
    {
        /// <summary>
        /// Metodo usado para hacer el consumo por GET y obtener
        /// un objeto como respuesta. <see cref="IQueryable<T>"/>
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="getParam">Array de parámetro que van a ser usados para realizar la consulta.</param>
        /// <returns>Objeto como respuesta. <see cref="IQueryable<T>"/></returns>
        Task<List<T>?> All(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue? authorize, string[]? getParam = null);

        /// <summary>
        /// Metodo usado para hacer el consumo por GET y obtener
        /// un objeto como respuesta. <see cref="IQueryable<T>"/>
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="getParam">Array de parámetro que van a ser usados para realizar la consulta.</param>
        /// <returns>Objeto como respuesta. <see cref="IQueryable<T>"/></returns>
        Task<T?> Get(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue? authorize, string[]? getParam = null);

        /// <summary>
        /// Metodo usado para hacer el consumo por POST dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        Task<T?> Post(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue? authorize, object? entidad);

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        Task<bool?> Put(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue? authorize, T? entidad);

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="idEntidad">Id de la entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        Task<bool?> Delete(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue? authorize, int idEntidad);
    }
}