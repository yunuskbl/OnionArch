using Microsoft.AspNetCore.Mvc.Filters;

namespace OnionArch.WebAPI.Filters
{
    public class LoggingFiltersAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerType = context.Controller.GetType();
            string managerType = "Bilinmeyen Manager";

            var baseType = controllerType.BaseType;

            if (baseType != null && baseType.IsGenericType)
            {
                var genericArg = baseType.GenericTypeArguments;
                if (genericArg.Length >= 3)
                {
                    // Manager type'ını al
                    managerType = genericArg[2].Name;

                    // "IProductManager" gibi interface adından "I" prefix'ini kaldır
                    if (managerType.StartsWith("I"))
                    {
                        managerType = managerType.Substring(1);
                    }
                }
            }
            Console.WriteLine($"[LOG] {controllerType.Name} --> {managerType} metodu çalıştı");

    
            base.OnActionExecuting(context);
        }
    }
}
