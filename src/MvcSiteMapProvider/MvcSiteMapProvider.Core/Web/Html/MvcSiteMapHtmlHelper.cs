﻿using System;
using System.Web.Mvc;
using MvcSiteMapProvider.Core.Mvc;
using MvcSiteMapProvider.Core.SiteMap;
using System.Web;

namespace MvcSiteMapProvider.Core.Web.Html
{
    /// <summary>
    /// MvcSiteMapHtmlHelper class
    /// </summary>
    public class MvcSiteMapHtmlHelper
    {
        /// <summary>
        /// Gets or sets the HTML helper.
        /// </summary>
        /// <value>The HTML helper.</value>
        public HtmlHelper HtmlHelper { get; protected set; }

        ///// <summary>
        ///// Gets or sets the sitemap provider.
        ///// </summary>
        ///// <value>The sitemap provider.</value>
        //public SiteMapProvider Provider { get; protected set; }

        /// <summary>
        /// Gets or sets the sitemap provider.
        /// </summary>
        /// <value>The sitemap provider.</value>
        public ISiteMap SiteMap { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcSiteMapHtmlHelper"/> class.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="provider">The sitemap provider.</param>
        public MvcSiteMapHtmlHelper(HtmlHelper htmlHelper, ISiteMap siteMap)
        {
            if (htmlHelper == null)
                throw new ArgumentNullException("htmlHelper");
            if (siteMap == null)
                throw new ArgumentNullException("siteMap");

            MvcSiteMapProviderViewEngine.Register();
            HtmlHelper = htmlHelper;
            SiteMap = siteMap;
        }

        /// <summary>
        /// Creates the HTML helper for model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public HtmlHelper<TModel> CreateHtmlHelperForModel<TModel>(TModel model)
        {
            return new HtmlHelper<TModel>(HtmlHelper.ViewContext, new ViewDataContainer<TModel>(model));
        }
    }
}