using RoomCoder.Application.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoomCoder.Pages
{
    public class HostPageModel : PageModel
    {
        public HostPageModel(PostFormService postFormService)
        {
            PostFormService = postFormService;
        }

        private PostFormService PostFormService { get; }

        public void OnPost()
        {
            PostFormService.Form = Request.Form;
        }
    }
}
