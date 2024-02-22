using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Obilet.Presentation.WebApp.Helpers
{
    public static class HtmlHelper
    {
        public static IHtmlContent LocationDropDownListFor<TModel, TValue>(
        this IHtmlHelper<TModel> helper,
        Expression<Func<TModel, TValue>> expression,
        IEnumerable<SelectListItem> optionList,
        string labelText,
        string onChangeEvent = null,
        bool isMultiple = false,
        bool isDisabled = false)
        {
            var attributes = new Dictionary<string, object>();

            if (Nullable.GetUnderlyingType(typeof(TValue)) != null)
            {
                attributes.Add("required", "true");
                labelText = "* " + labelText;
            }

            // CSS
            attributes.Add("class", "form-control border-0 shadow-none obilet-select");

            attributes.Add("data-live-search", "true");

            // Attributes
            if (isMultiple)
                attributes.Add("multiple", "multiple");

            if (isDisabled)
                attributes.Add("disabled", true);

            if (!string.IsNullOrEmpty(onChangeEvent))
                attributes.Add("onchange", onChangeEvent);

            // HTML
            var div = new TagBuilder("div");
            div.MergeAttribute("class", "form-group");
            div.InnerHtml.AppendHtml(helper.LabelFor(expression, labelText,new {@class = "text-primary fw-bold ms-2"} ));
            div.InnerHtml.AppendHtml(helper.DropDownListFor(expression, optionList, attributes));
            div.InnerHtml.AppendHtml(helper.ValidationMessageFor(expression, "", new { @class = "text-danger" }));

            return div;
        }

    }
}
