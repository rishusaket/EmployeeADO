using EmployeeADO.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmployeeADO.EmployeeModelBinder
{
    public class EmployeeModelBinderClass : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Employee))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;
                //int formId = Convert.ToInt32(request.Form.Get("Id").ToString());
                string formFirstName = request.Form.Get("FirstName").ToString();
                string formLastName = request.Form.Get("LastName").ToString();
                string formGender = request.Form.Get("gender").ToString();
                string formLocation = request.Form.Get("location").ToString();

                return new Employee
                {
                    /*Id = formId*/
                    name = formFirstName + "" + formLastName,
                    gender = formGender,
                    location = formLocation
                };
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}
