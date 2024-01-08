namespace YANLib.Controllers;

public class HomeController : AbpController
{
    public ActionResult Index() => Redirect("~/swagger");
}
