using Microsoft.AspNetCore.Mvc;

namespace ViewToHTML.Services
{
    public interface IViewRendererService
    {
        Task<string> RenderViewToStringAsync(ControllerContext actionContext, string viewPath, object model);
    }
}