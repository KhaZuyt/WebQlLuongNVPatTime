using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly int[] _allowedRoles;

    public RoleAuthorizeAttribute(params int[] allowedRoles)
    {
        _allowedRoles = allowedRoles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Lấy VaiTrò từ Session
        var vaiTro = context.HttpContext.Session.GetInt32("VaiTro");

        // Nếu không đăng nhập hoặc VaiTrò không nằm trong danh sách được phép
        if (vaiTro == null || !_allowedRoles.Contains(vaiTro.Value))
        {
            // Chuyển hướng đến trang AccessDenied
            context.Result = new RedirectToActionResult("AccessDenied", "Home", null);
        }
    }
}
