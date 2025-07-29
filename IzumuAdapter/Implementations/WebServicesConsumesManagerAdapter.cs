//-----------------------------------------------------------------------
// <copyright file="WebServicesConsumesManagerAdapter.cs" company="None">
//     All rights reserved.
// </copyright>
// <author>aiglesias</author>
// <date>29/03/2020 17:00:47</date>
// <summary>Código fuente clase WebServicesConsumesManagerAdapter.</summary>
//-----------------------------------------------------------------------
namespace IzumuAdapter.Implementations
{
    using IzumuAdapter.Interfaces;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Clase usada como manejadora de consumos a servicios web.
    /// </summary>
    public class WebServicesConsumesManagerAdapter<T> : IWebServicesConsumesManagerAdapter<T?>
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebServicesConsumesManagerAdapter<T>"/> class.
        /// </summary>
        public WebServicesConsumesManagerAdapter()
        {
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets a value indicating whether Objeto que realiza la peticion Http.
        /// </summary>
        /// <value>Objeto que realiza la peticion Http.</value>
        public HttpClient? Client { get; set; }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="idEntidad">Id de la entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        public async Task<bool> Delete(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, int idEntidad)
        {
            try
            {
                using (Client = new HttpClient())
                {
                    Client.DefaultRequestHeaders.Authorization = authorize;
                    HttpResponseMessage result = await Client.DeleteAsync(url);
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        /// <summary>
        /// Metodo usado para hacer el consumo por GET y obtener
        /// un objeto como respuesta. <see cref="IQueryable<T>"/>
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="getParam">Array de parámetro que van a ser usados para realizar la consulta.</param>
        /// <returns>Objeto como respuesta. <see cref="IQueryable<T>"/></returns>
        public async Task<T?> Get(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, string[] getParam)
        {
            try
            {
                T resultadoEntidad = default;
                using (Client = new HttpClient())
                {
                    Client.DefaultRequestHeaders.Authorization = authorize;
                    HttpResponseMessage result = await Client.GetAsync(url);
                    if (result.IsSuccessStatusCode)
                    {
                        resultadoEntidad = await result.Content.ReadAsAsync<T>();
                    }
                }

                return resultadoEntidad;
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        /// <summary>
        /// Metodo usado para hacer el consumo por POST dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        public async Task<T?> Post(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, object entidad)
        {
            try
            {
                using (Client = new HttpClient())
                {
                    Client.DefaultRequestHeaders.Authorization = authorize;
                    HttpResponseMessage result = await Client.PostAsync(url, entidad, mediaTypeFormatter);
                    if (result.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
                    }
                }

                return default;
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        /// <summary>
        /// Metodo usado para hacer el consumo por PUT dado un
        /// objeto de tipo T definido por el usuario.
        /// </summary>
        /// <param name="url">Url de endPoint.</param>
        /// <param name="mediaTypeFormatter">Tipo de contenido.</param>
        /// <param name="authorize">Autorizacion del endpoint.</param>
        /// <param name="entidad">Entidad que va ser procesada.</param>
        /// <returns>True, si se ejecuto exitosamente.</returns>
        public async Task<bool?> Put(Uri url, MediaTypeFormatter mediaTypeFormatter, AuthenticationHeaderValue authorize, T entidad)
        {
            try
            {
                using (Client = new HttpClient())
                {
                    Client.DefaultRequestHeaders.Authorization = authorize;
                    HttpResponseMessage result = await Client.PutAsync(url, entidad, mediaTypeFormatter);
                    if (result.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                throw new WebServiceException(e.Message, e);
            }
        }

        #endregion
    }
}