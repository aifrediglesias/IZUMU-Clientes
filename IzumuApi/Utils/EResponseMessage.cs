//-----------------------------------------------------------------------
// <copyright file="EResponseMessage.cs" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>Aifred</author>
// <date>28/07/2025 15:54:53</date>
// <summary>Código fuente clase EResponseMessage.</summary>
//-----------------------------------------------------------------------
namespace IzumuApi
{
    using IzumuApi.Utils;

    /// <summary>
    /// Se define la estructura de mensajes personalizados de la clase <see cref="EResponseMessage"/>.
    /// </summary>
    public class EResponseMessage : Enumeration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EResponseMessage"/> class.
        /// </summary>
        /// <param name="id">Id del mensaje.</param>
        /// <param name="name">Valor del mensaje.</param>
        private EResponseMessage(int id, string name)
        : base(name, id)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EResponseMessage"/> class.
        /// </summary>
        /// <param name="id">Id del mensaje.</param>
        /// <param name="name">Valor del mensaje.</param>
        /// <param name="param">Nombre del parametro.</param>
        private EResponseMessage(int id, string name, string param)
        : base(id, name, param)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EResponseMessage"/> class.
        /// </summary>
        /// <param name="id">Id del mensaje.</param>
        /// <param name="name">Valor del mensaje.</param>
        /// <param name="param">Lista de los nombres de los parametros.</param>
        private EResponseMessage(int id, string name, string[] param)
        : base(id, name, param)
        {
        }

        /// <summary>
        /// Metodo usado para obtener un mensaje de error general.
        /// </summary>
        /// <returns>Mensaje de error general.</returns>
        public static EResponseMessage ErrorGral()
        {
            return new EResponseMessage(3, "No es posible procesar la solicitud.");
        }

        /// <summary>
        /// Metodo usado para obtener un mensaje con los nombres los parametros.
        /// </summary>
        /// <param name="param">Lista de nombres de parametros.</param>
        /// <returns>Mensaje de error general.</returns>
        public static EResponseMessage ParamsNull(string[] param)
        {
            return new EResponseMessage(4, "Los parametros {0} están vacíos", param);
        }

        /// <summary>
        /// Metodo usado para obtener un mensaje con el nombre del parametro.
        /// </summary>
        /// <param name="param">Nombre del parametro.</param>
        /// <returns>Mensaje de error general.</returns>
        public static EResponseMessage ParamNull(string param)
        {
            return new EResponseMessage(5, "El parametro {0} está vacío.", param);
        }

        /// <summary>
        /// Metodo usado para obtener un mensaje de Fail.
        /// </summary>
        /// <returns>Mensaje de error general.</returns>
        public static EResponseMessage OperacionFail()
        {
            return new EResponseMessage(2, "Operación Fallida");
        }

        /// <summary>
        /// Metodo usado para obtener un mensaje de ok.
        /// </summary>
        /// <returns>Mensaje de error general.</returns>
        public static EResponseMessage OperacionOk()
        {
            return new EResponseMessage(1, "Operación Exitosa");
        }
    }
}
