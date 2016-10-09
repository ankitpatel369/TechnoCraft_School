using TechnoCraft_School.Controllers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechnoCraft_School.ModelBinders
{
    public class DynamicJsonModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var actionName = controllerContext.RouteData.Values["Action"];
            if (actionName != null)
            {
                string contentText;

                using (var stream = controllerContext.HttpContext.Request.InputStream)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(stream))
                        contentText = reader.ReadToEnd();
                }

                if (string.IsNullOrEmpty(contentText)) return (null);

                return JObject.Parse(contentText);
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}