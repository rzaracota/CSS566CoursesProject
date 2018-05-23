using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using serviceclient;
using serviceclient.types;

class ModulesPageModel : PageModel {
    private static string endpoint = "http://localhost:1738/module";

    private ServiceClient<Module> client = new ServiceClient<Module>(endpoint);
   
    public List<Module> Modules { get; private set; } 

    public void OnGet()
    {
        Modules = client.Get();
    }
}