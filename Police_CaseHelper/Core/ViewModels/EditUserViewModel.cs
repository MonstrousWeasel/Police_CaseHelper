using Microsoft.AspNetCore.Mvc.Rendering;
using Police_CaseHelper.Areas.Identity.Data;

namespace Police_CaseHelper.Core.ViewModels
{
    public class EditUserViewModel
    {
        public ApplicationUser  User { get; set; }
        public IList<SelectListItem> Roles { get; set; }
    }
}
