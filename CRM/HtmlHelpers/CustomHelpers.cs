using Entities.Entities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CRM.HtmlHelpers;

public static class CustomHelpers
{

    public static IHtmlContent Input1(this IHtmlHelper helper, int colSpan, string labelName, string inputId, string placeholder, string additionalClass = "", string onChange = "", string inputType = "text")
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


    public static IHtmlContent Button(this IHtmlHelper helper, string color, string innerText, string url, string type, string icon, string additionalClass, string id)
    {
        TagBuilder tb = new TagBuilder("button");
        tb.Attributes.Add("class", $"text-{color}-700 hover:text-white border border-{color}-700 hover:bg-{color}-800 focus:ring-4 focus:outline-none focus:ring-{color}-300 font-medium rounded-lg text-sm px-3 py-2.5 text-center me-2 mb-2 dark:border-{color}-500 dark:text-{color}-500 dark:hover:text-white dark:hover:bg-{color}-500 dark:focus:ring-{color}-800 {additionalClass}");
        tb.Attributes.Add("type", type);
        tb.Attributes.Add("id", id);
        tb.InnerHtml.AppendHtml($"<i class='{icon}'></i> {innerText}");
        tb.MergeAttribute("href", url);


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

    public static IHtmlContent Input(this IHtmlHelper helper, string id, string name, string type, string placeholder, string labelText, string additionalClass)
    {
        // Crear el label
        TagBuilder label = new TagBuilder("label");
        label.Attributes.Add("for", id);
        label.Attributes.Add("class", "block mb-2 text-md font-medium text-gray-900 dark:text-white");
        label.InnerHtml.Append(labelText);

        // Crear el input
        TagBuilder input = new TagBuilder("input");
        input.Attributes.Add("class", $"bg-gray-50 border border-gray-300 text-gray-900 text-md rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-800 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 {additionalClass}");
        input.Attributes.Add("id", id);
        input.Attributes.Add("name", name);
        input.Attributes.Add("type", type);
        input.Attributes.Add("placeholder", placeholder);

        HtmlContentBuilder builder = new HtmlContentBuilder();
        builder.AppendHtml(label);
        builder.AppendHtml(input);

        return builder;
    }

    public static IHtmlContent Select(this IHtmlHelper helper, string id, string name, IEnumerable<TipoIdentificacion> tiposIdentificacion, string additionalClass, string labelText)
    {
        // Crear el label
        TagBuilder label = new TagBuilder("label");
        label.Attributes.Add("for", id);
        label.Attributes.Add("class", "block mb-2 text-md font-medium text-gray-900 dark:text-white");
        label.InnerHtml.Append(labelText);

        // Crear el select
        TagBuilder select = new TagBuilder("select");
        select.Attributes.Add("class", $"bg-gray-50 border border-gray-300 text-gray-900 text-md rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-800 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 {additionalClass}");
        select.Attributes.Add("id", id);
        select.Attributes.Add("name", name);

        if (tiposIdentificacion != null)
        {
            foreach (var tipo in tiposIdentificacion)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.Attributes.Add("value", tipo.IdTipoIdentificacion.ToString());
                optionTag.InnerHtml.Append(tipo.Nombre);
                select.InnerHtml.AppendHtml(optionTag);
            }
        }

        HtmlContentBuilder builder = new HtmlContentBuilder();
        builder.AppendHtml(label);
        builder.AppendHtml(select);

        return builder;
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

    public static IHtmlContent TailwindTableButton(this IHtmlHelper helper, string color, string onClick, string icon, string additionalClass, string id, string title,string url)
    {
        TagBuilder tb = new TagBuilder("button");
        tb.Attributes.Add("class", $"text-{color}-700 hover:text-white border border-{color}-700 hover:bg-{color}-800 focus:ring-4 focus:outline-none focus:ring-{color}-300 font-medium rounded-lg text-sm px-3 py-2.5 text-center me-2 mb-2 dark:border-{color}-500 dark:text-{color}-500 dark:hover:text-white dark:hover:bg-{color}-500 dark:focus:ring-{color}-800 {additionalClass}");
        tb.Attributes.Add("type", "button");
        tb.Attributes.Add("id", id);
        tb.Attributes.Add("title", title);
        //tb.MergeAttribute("onclick", onClick);
        tb.InnerHtml.AppendHtml($"<i class='{icon}'></i>");

        if (!string.IsNullOrEmpty(url))
        {
            tb.Attributes.Add("onclick", $"window.location.href='{url}';");
        }

        return new HtmlContentBuilder().AppendHtml(tb);
    }

    public static IHtmlContent TailwindBadge(this IHtmlHelper helper, string color, string icon, string innerText, string additionalClass)
    {
        TagBuilder tb = new TagBuilder("span");
        var iconBd = $"<i class='{icon} mr-1'></i>";
        var html = $"<span class='{additionalClass} badge bg-{color}-100 text-{color}-700 text-sm font-medium inline-flex items-center px-2.5 py-0.5 rounded me-2 dark:bg-{color}-800 dark:text-{color}-500 border border-{color}-500'>{iconBd} {innerText}</span>";
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

    public static IHtmlContent TailwindAlert(this IHtmlHelper helper, string title, string message, string color, string icon, string additionalClass = "")
    {
        var html = $"<div class='flex items-start p-4 mb-4 text-sm text-{color}-800 rounded-lg bg-{color}-200 dark:bg-{color}-800 dark:text-{color}-200 {additionalClass}' role='alert'>" +
                   $"<div class='flex flex-col'>" +
                   $"<span class='font-medium'><i class='{icon} mr-2'></i>{title}</span>" +
                   $"<span class='mt-1'>{message}</span>" +
                   $"</div></div>";

        return new HtmlContentBuilder().AppendHtml(html);
    }

    public static IHtmlContent TailwindWelcomeAlert(this IHtmlHelper helper, string title, string message, string color, string icon, string additionalClass = "")
    {
        var html = $"<div class='flex items-start p-4 mb-4 text-lg text-{color}-800 rounded-lg bg-{color}-200 dark:bg-{color}-800 dark:text-{color}-200 {additionalClass}' role='alert'>" +
                   $"<div class='flex flex-col'>" +
                   $"<span class='font-medium'><i class='{icon} mr-2'></i>{title}</span>" +
                   $"<br>" +
                   $"<span class='mt-1'><i class='fa-solid fa-user mr-2'></i>{message}</span>" +
                   $"</div></div>";

        return new HtmlContentBuilder().AppendHtml(html);
    }


    public static IHtmlContent ActionLink(this IHtmlHelper helper, string color, string innerText, string action, string controller, string icon, string id)
    {
        var html = $"<a href='/{controller}/{action}' class='text-{color}-700 hover:text-white border border-{color}-700 hover:bg-{color}-800 focus:ring-4 focus:outline-none focus:ring-{color}-300 font-medium rounded-lg text-sm px-3 py-2.5 text-center me-2 mb-2 dark:border-{color}-500 dark:text-{color}-500 dark:hover:text-white dark:hover:bg-{color}-500 dark:focus:ring-{color}-800' id='{id}'>" +
                   $"<i class='{icon}'></i> {innerText}</a>";

        return new HtmlContentBuilder().AppendHtml(html);
    }

    public static IHtmlContent Input2(this IHtmlHelper helper, string propertyName, string labelName, string placeholder, string additionalClass = "", string onChange = "", string inputType = "text")
    {
        var metadata = helper.ViewData.ModelMetadata.Properties.FirstOrDefault(p => p.PropertyName == propertyName);
        if (metadata == null)
        {
            throw new ArgumentException($"No se encontró la propiedad '{propertyName}' en el modelo.");
        }

        var div = new TagBuilder("div");
        div.AddCssClass("col-span-1");

        var label = new TagBuilder("label");
        label.Attributes.Add("for", propertyName);
        label.AddCssClass("block mb-2 text-sm font-medium text-gray-900 dark:text-white");
        label.InnerHtml.Append(labelName);

        var input = new TagBuilder("input");
        input.Attributes.Add("id", propertyName);
        input.Attributes.Add("name", propertyName);
        input.Attributes.Add("placeholder", placeholder);
        input.Attributes.Add("type", inputType);
        if (!string.IsNullOrEmpty(onChange))
        {
            input.Attributes.Add("onchange", onChange);
        }
        input.AddCssClass($"bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-800 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 {additionalClass}");

        var span = new TagBuilder("span");
        span.Attributes.Add("data-valmsg-for", propertyName);
        span.Attributes.Add("data-valmsg-replace", "true");
        span.AddCssClass("text-red-600");

        var contentBuilder = new HtmlContentBuilder();
        contentBuilder.AppendHtml(label);
        contentBuilder.AppendHtml(input);
        contentBuilder.AppendHtml(span);

        div.InnerHtml.AppendHtml(contentBuilder);

        return new HtmlContentBuilder().AppendHtml(div);
    }




























}
