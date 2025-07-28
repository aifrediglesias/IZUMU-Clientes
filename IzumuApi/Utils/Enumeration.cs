//-----------------------------------------------------------------------
// <copyright file="Enumeration.cs" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>Aifred</author>
// <date>28/07/2025 15:54:53</date>
// <summary>Código fuente clase Enumeration.</summary>
//-----------------------------------------------------------------------
namespace IzumuApi.Utils
{
    /// <summary>
    /// Clase usada para customizar un Enum.
    /// </summary>
    public abstract class Enumeration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        protected Enumeration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="value">Valor del mensaje.</param>
        /// <param name="id">Id del objeto.</param>
        protected Enumeration(string value, int id)
        {
            Value = value;
            Id = id;
            Message = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="id">Id del objeto.</param>
        /// <param name="value">Valor del mensaje.</param>
        /// <param name="param">Parametro que debe ser formateados en el mensaje.</param>
        protected Enumeration(int id, string value, string param)
        {
            Value = value;
            Id = id;
            Message = string.Format(value, param);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumeration"/> class.
        /// </summary>
        /// <param name="id">Id del objeto.</param>
        /// <param name="value">Valor del mensaje.</param>
        /// <param name="parameters">Parametros que van ser formateados en el mensaje.</param>
        protected Enumeration(int id, string value, string[] parameters)
        {
            Value = value;
            Id = id;
            Message = string.Format(value, string.Join(",", parameters));
        }

        /// <summary>
        /// Gets or sets Propiedad que almacena el valor.
        /// </summary>
        /// <value>Valor de la propiedad.</value>
        public string? Value { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena el id.
        /// </summary>
        /// <value>Id de la propiedad.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena el parametro.
        /// </summary>
        /// <value>Parametro de la propiedad.</value>
        public string? Param { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena los parametros.
        /// </summary>
        /// <value>Parametros de la propiedad.</value>
        public string[]? Params { get; set; }

        /// <summary>
        /// Gets or sets Propiedad que almacena el mensaje resultado.
        /// </summary>
        /// <value>Mensaje de la propiedad.</value>
        public string? Message { get; set; }

    }
}
