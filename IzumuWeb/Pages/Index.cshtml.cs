//-----------------------------------------------------------------------
// <copyright file="IndexModel" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifred</author>
// <date>28/07/2025 21:52:10</date>
// <summary>Código fuente interfaz IndexModel.</summary>
//-----------------------------------------------------------------------
namespace IzumuWeb.Pages
{
    using IzumuWeb.Dtos;
    using IzumuWeb.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICustomerModel? _customerModel;

        /// <summary> 
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="customerModel"></param>
        /// <param name="logger"></param>
        public IndexModel(ICustomerModel customerModel, ILogger<IndexModel> logger)
        {
            this._customerModel = customerModel;
            this._logger = logger;
        }

        /// <summary>
        /// Gets or sets Customers.
        /// </summary>
        public IList<CustomerDto>? Customers { get; set; }

        /// <summary>
        /// Gets or sets Customer.
        /// </summary>
        [BindProperty]
        public CustomerDto Customer { get; set; }

        /// <summary>
        /// ShowModal.
        /// </summary>
        [BindProperty]
        public bool ShowModal { get; set; }

        /// <summary>
        /// OnGetAsync.
        /// </summary>
        public async Task OnGetAsync()
        {
            try
            {
                if (this._customerModel != null)
                    this.Customers = await this._customerModel.All();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        /// <summary>
        /// OnGetDeleteCustomerAsync.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnGetDeleteCustomerAsync(int id)
        {
            try
            {
                if (this._customerModel != null)
                    await this._customerModel.Delete(id);

                if (this._customerModel != null)
                    this.Customers = await this._customerModel.All();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

    }
}
