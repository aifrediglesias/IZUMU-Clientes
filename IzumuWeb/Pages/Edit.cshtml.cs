using IzumuWeb.Dtos;
using IzumuWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IzumuWeb.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPlanModel? _planModel;
        private readonly IDocumentTypeModel? _documentTypeModel;
        private readonly ICustomerModel? _customerModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditModel"/> class.
        /// </summary>
        /// <param name="documentTypeModel"></param>
        /// <param name="planModel"></param>
        /// <param name="logger"></param>
        /// <param name="customerModel"></param>
        public EditModel(ICustomerModel customerModel, IPlanModel planModel, IDocumentTypeModel documentTypeModel, ILogger<IndexModel> logger)
        {
            this._planModel = planModel;
            this._documentTypeModel = documentTypeModel;
            this._logger = logger;
            this._customerModel = customerModel;
        }

        /// <summary>
        /// Gets or sets Plans.
        /// </summary>
        public List<SelectListItem>? Plans { get; set; }

        /// <summary>
        /// Gets or sets DocumentsTypes.
        /// </summary>
        public List<SelectListItem>? DocumentsTypes { get; set; }

        /// <summary>
        /// Gets or sets DocumentTypeSelected.
        /// </summary>
        [BindProperty]
        public int DocumentTypeSelected { get; set; }

        /// <summary>
        /// Gets or sets PlanSelected.
        /// </summary>
        [BindProperty]
        public int PlanSelected { get; set; }

        /// <summary>
        /// Gets or sets Customer.
        /// </summary>
        [BindProperty]
        public CustomerDto Customer { get; set; }

        /// <summary>
        /// IsReadOnly.
        /// </summary>
        [BindProperty]
        public bool IsReadOnly { get; set; } = false;

        /// <summary>
        /// OnGet.
        /// </summary>
        public async Task OnGetAsync()
        {
            await this.LoadCombosAsync();
        }

        /// <summary>
        /// OnGetAsync.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="readOnly"></param>
        /// <returns></returns>
        public async Task OnGetLoadCustomerAsync(int id, bool readOnly)
        {
            await LoadCombosAsync();
            if (this._customerModel != null)
                this.Customer = await this._customerModel.Get(id);

            if (this.Customer != null)
            {
                this.DocumentTypeSelected = this.Customer.DocumentTypeId;
                this.PlanSelected = this.Customer.PlanId;
            }
            this.IsReadOnly = readOnly;
        }

        /// <summary>
        /// OnPostAsync.
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (this._customerModel != null && this.Customer != null && this.Customer.Id == 0)
                    await this._customerModel.Insert(this.Customer);

                if (this._customerModel != null && this.Customer != null && this.Customer.Id > 0)
                    await this._customerModel.Update(this.Customer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return RedirectToPage("Index");
        }

        /// <summary>
        /// LoadCombosAsync.
        /// </summary>
        /// <returns></returns>
        private async Task LoadCombosAsync()
        {
            if (this._documentTypeModel != null)
            {
                var documentsTypes = await this._documentTypeModel.All();
                this.DocumentsTypes = documentsTypes?
                    .Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                    }).ToList();
            }

            if (this._planModel != null)
            {
                var plans = await this._planModel.All();
                this.Plans = plans?
                    .Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString(),
                    }).ToList();
            }
        }
    }
}
