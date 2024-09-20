using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DeployDemo
{

    //  adds /api/ to the beginning of the route for each controller
    //you can do it also with the [Route] attribute on the controller
    
    public class RoutingConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.Selectors.Any())
            {
                controller.Selectors[0].AttributeRouteModel = new AttributeRouteModel(
                    new RouteAttribute("/api/" + controller.ControllerName));
            }
            else
            {
                controller.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(
                        new RouteAttribute("/api/" + controller.ControllerName))
                });
            }
        }
    }
}
