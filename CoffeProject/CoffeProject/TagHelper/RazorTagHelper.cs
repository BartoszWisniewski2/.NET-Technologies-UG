using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CoffeProject.TagHelper
{
    using CoffeProject.Models;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Text;

    [HtmlTargetElement("employee-details")]
    public class EmployeeDetailTagHelper : TagHelper
    {
        [HtmlAttributeName("for-user")]
        public ApplicationUser EmployeeName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "EmployeeDetails";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();
            sb.AppendFormat("<td> {0} </td>", this.EmployeeName.Name);
            sb.AppendFormat("<td> {0} </td>", this.EmployeeName.Email);
            sb.AppendFormat("<td> {0} </td>", this.EmployeeName.PhoneNumber);

            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}  