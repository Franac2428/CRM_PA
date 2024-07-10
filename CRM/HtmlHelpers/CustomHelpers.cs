using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM.HtmlHelpers;

public static class CustomHelpers
{

    public static IHtmlContent Input(this IHtmlHelper helper, int colSpan, string labelName, string inputId, string placeholder, string additionalClass = "", string onChange = "", string inputType = "text")
    {
        var div = new TagBuilder("div");
        div.AddCssClass($"col-span-{colSpan} sm:col-span-1");

        var label = new TagBuilder("label");
        label.Attributes.Add("for", inputId);
        label.AddCssClass("block mb-2 text-sm font-medium text-gray-900 dark:text-white");
        label.InnerHtml.Append(labelName);

        var input = new TagBuilder("input");
        input.Attributes.Add("id", inputId);
        input.Attributes.Add("placeholder", placeholder);
        input.Attributes.Add("type", inputType);
        if (!string.IsNullOrEmpty(onChange))
        {
            input.Attributes.Add("onchange", onChange);
        }
        input.AddCssClass($"bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-800 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 {additionalClass}");

        div.InnerHtml.AppendHtml(label);
        div.InnerHtml.AppendHtml(input);

        return new HtmlContentBuilder().AppendHtml(div);
    }


    public static IHtmlContent Button(this IHtmlHelper helper, string color, string innerText, string onClick, string type, string icon, string additionalClass, string id)
    {
        TagBuilder tb = new TagBuilder("button");
        tb.Attributes.Add("class", $"text-{color}-700 hover:text-white border border-{color}-700 hover:bg-{color}-800 focus:ring-4 focus:outline-none focus:ring-{color}-300 font-medium rounded-lg text-sm px-3 py-2.5 text-center me-2 mb-2 dark:border-{color}-500 dark:text-{color}-500 dark:hover:text-white dark:hover:bg-{color}-500 dark:focus:ring-{color}-800 {additionalClass}");
        tb.Attributes.Add("type", type);
        tb.Attributes.Add("id", id);
        tb.InnerHtml.AppendHtml($"<i class='{icon}'></i> {innerText}");
        tb.MergeAttribute("onclick", onClick);


        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent InputLabel(this IHtmlHelper helper, string labelText, string labelFor)
    {
        TagBuilder tb = new TagBuilder("label");
        tb.Attributes.Add("class", "block mb-2 text-sm font-medium text-gray-900 dark:text-white");
        tb.Attributes.Add("for", labelFor);
        tb.InnerHtml.AppendHtml(labelText);

        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindInput(this IHtmlHelper helper, string id, string name, string type, string placeholder, string additionalClass)
    {
        TagBuilder tb = new TagBuilder("input");
        tb.Attributes.Add("class", $"bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-800 dark: border border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 {additionalClass}");
        tb.Attributes.Add("id", id);
        tb.Attributes.Add("name", name);
        tb.Attributes.Add("type", type);
        tb.Attributes.Add("placeholder", placeholder);


        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindHref(this IHtmlHelper helper, string url, string innerText)
    {
        TagBuilder tb = new TagBuilder("a");
        tb.Attributes.Add("class", "text-sm font-medium text-primary-600 hover:underline dark:text-white");
        tb.Attributes.Add("href", url);
        tb.InnerHtml.AppendHtml(innerText);

        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindBreadCrumb(this IHtmlHelper helper, string[] items)
    {
        TagBuilder tb = new TagBuilder("li");

        var html = $" <li class='inline-flex items-center'><a href='#' class='inline-flex items-center text-sm font-medium text-gray-700 hover:text-blue-600 dark:text-gray-400 dark:hover:text-white'>{items[0]}</a></li>";

        if (items.Length > 1)
        {
            for (int i = 1; i < items.Length; i++)
            {
                var name = items[i];
                html += $"<li aria-current='page'><div class='flex items-center'><svg class='rtl:rotate-180 w-3 h-3 text-gray-400 mx-1' aria-hidden='true' xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 6 10'><path stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='m1 9 4-4-4-4' /></svg><span class='ms-1 text-sm font-medium text-gray-500 md:ms-2 dark:text-gray-400'>{name}</span></div></li>";
            }
        }
        tb.InnerHtml.AppendHtml(html);
        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindBtnOpenModal(this IHtmlHelper helper, string color, string innerText, string onClick, string type, string icon, string additionalClass, string modalId)
    {
        TagBuilder tb = new TagBuilder("button");
        tb.Attributes.Add("class", $"text-{color}-700 hover:text-white border border-{color}-700 hover:bg-{color}-800 focus:ring-4 focus:outline-none focus:ring-{color}-300 font-medium rounded-lg text-sm px-3 py-2.5 text-center me-2 mb-2 dark:border-{color}-500 dark:text-{color}-500 dark:hover:text-white dark:hover:bg-{color}-500 dark:focus:ring-{color}-800 {additionalClass}");
        tb.Attributes.Add("type", type);
        tb.Attributes.Add("data-modal-target", modalId);
        tb.Attributes.Add("data-modal-toggle", modalId);
        tb.InnerHtml.AppendHtml($"<i class='{icon}'></i> {innerText}");
        tb.MergeAttribute("onclick", onClick);


        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindBtnCloseModal(this IHtmlHelper helper, string onClick, string id, string additionalClass, string modalId)
    {
        TagBuilder tb = new TagBuilder("button");
        tb.Attributes["id"] = id;
        tb.Attributes["type"] = "button";
        tb.Attributes["onclick"] = onClick;
        tb.Attributes["class"] = $"text-red-700 hover:text-white border border-red-700 hover:bg-red-800 focus:ring-4 focus:outline-none focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center me-2 mb-2 dark:border-red-500 dark:text-red-500 dark:hover:text-white dark:hover:bg-red-600 dark:focus:ring-red-900 {additionalClass}";
        tb.Attributes["data-modal-toggle"] = modalId;
        tb.InnerHtml.Append("Cerrar");

        return new HtmlContentBuilder().AppendHtml(tb);
    }
    public static IHtmlContent TailwindSelect(this IHtmlHelper helper, string id, string name, IDictionary<string, string> options, string additionalClass)
    {
        TagBuilder tb = new TagBuilder("select");
        tb.Attributes.Add("class", $"bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-800 dark: border border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 {additionalClass}");
        tb.Attributes.Add("id", id);
        tb.Attributes.Add("name", name);

        if (options != null)
        {
            foreach (var option in options)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.Attributes.Add("value", option.Key);
                optionTag.InnerHtml.Append(option.Value);
                tb.InnerHtml.AppendHtml(optionTag);
            }
        }


        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindTableButton(this IHtmlHelper helper, string color, string onClick, string icon, string additionalClass, string id, string title, bool isModal, string idModal)
    {
        TagBuilder tb = new TagBuilder("button");
        tb.Attributes.Add("class", $"text-{color}-700 hover:text-white border border-{color}-700 hover:bg-{color}-800 focus:ring-4 focus:outline-none focus:ring-{color}-300 font-medium rounded-lg text-sm px-3 py-2.5 text-center me-2 mb-2 dark:border-{color}-500 dark:text-{color}-500 dark:hover:text-white dark:hover:bg-{color}-500 dark:focus:ring-{color}-800 {additionalClass}");
        tb.Attributes.Add("type", "button");
        tb.Attributes.Add("id", id);
        tb.Attributes.Add("title", title);
        tb.MergeAttribute("onclick", onClick);
        tb.InnerHtml.AppendHtml($"<i class='{icon}'></i>");

        if (isModal)
        {
            tb.Attributes.Add("data-modal-target", idModal);
            tb.Attributes.Add("data-modal-toggle", idModal);
        }

        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindBadge(this IHtmlHelper helper, string color, string icon, string innerText, string additionalClass)
    {
        TagBuilder tb = new TagBuilder("span");
        var iconBd = $"<i class='{icon} mr-1'></i>";
        var html = $"<span class='{additionalClass} badge bg-{color}-100 text-{color}-800 text-sm font-medium inline-flex items-center px-2.5 py-0.5 rounded me-2 dark:bg-{color}-800 dark:text-{color}-400 border border-{color}-500'>{iconBd} {innerText}</span>";
        tb.InnerHtml.AppendHtml(html);
        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindCheckBox(this IHtmlHelper helper, string id, string color, string additionalValue, string additionalClass, string lblText)
    {
        TagBuilder tb = new TagBuilder("div");
        var html = $"<div class>" +
            $"<div class='flex items-center me-4'>" +
            $"<input checked id='{id}' type='checkbox' value='{additionalValue}' " +
            $"class='w-4 h-4 text-{color}-600 bg-gray-100 border-gray-300 rounded focus:ring-{color}-500 dark:focus:ring-{color}-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600 {additionalClass}'>" +
            $"<label for='{id}' class='ms-2 text-sm font-medium text-gray-900 dark:text-gray-300'>{lblText}</label>" +
            $"</div>";
        tb.InnerHtml.AppendHtml(html);
        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindTextarea(this IHtmlHelper helper, string id, string name, string placeholder, string additionalClass, int rows = 4, int cols = 50)
    {
        TagBuilder tb = new TagBuilder("textarea");
        tb.Attributes.Add("class", $"bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-800 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 {additionalClass}");
        tb.Attributes.Add("id", id);
        tb.Attributes.Add("name", name);
        tb.Attributes.Add("placeholder", placeholder);
        tb.Attributes.Add("rows", rows.ToString());
        tb.Attributes.Add("cols", cols.ToString());

        return new HtmlContentBuilder().AppendHtml(tb);
    }





























}
