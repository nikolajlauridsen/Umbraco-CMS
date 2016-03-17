using System;
using System.Collections.Generic;
using System.Threading;
using Umbraco.Core;
using Umbraco.Core.Media;
using Umbraco.Web.Mvc;
using Umbraco.Web.Routing;
using Umbraco.Web.Trees;
using Umbraco.Web.WebApi;
using umbraco;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;
using Umbraco.Web.Models.Trees;
using Umbraco.Web._Legacy.Actions;

namespace Umbraco.Web
{
	/// <summary>
	/// Extension methods for the PluginTypeResolver
	/// </summary>
	public static class PluginManagerExtensions
	{
        /// <summary>
        /// Returns all available IAction in application
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable<Type> ResolveActions(this PluginManager resolver)
        {
            return resolver.ResolveTypes<IAction>();
        }
        /// <summary>
        /// Returns all available TreeApiController's in application that are attribute with TreeAttribute
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        internal static IEnumerable<Type> ResolveAttributedTreeControllers(this PluginManager resolver)
        {
            return resolver.ResolveTypesWithAttribute<TreeController, TreeAttribute>();
        }

        internal static IEnumerable<Type> ResolveSurfaceControllers(this PluginManager resolver)
		{
			return resolver.ResolveTypes<SurfaceController>();
		}

        internal static IEnumerable<Type> ResolveUmbracoApiControllers(this PluginManager resolver)
        {
            return resolver.ResolveTypes<UmbracoApiController>();
        }

		/// <summary>
		/// Returns all available ITrees in application
		/// </summary>
		/// <param name="resolver"></param>
		/// <returns></returns>
		internal static IEnumerable<Type> ResolveTrees(this PluginManager resolver)
		{
			return resolver.ResolveTypes<BaseTree>();
		}


		/// <summary>
		/// Returns all classes attributed with XsltExtensionAttribute attribute
		/// </summary>
		/// <param name="resolver"></param>
		/// <returns></returns>
		internal static IEnumerable<Type> ResolveXsltExtensions(this PluginManager resolver)
		{
			return resolver.ResolveAttributedTypes<Umbraco.Core.Macros.XsltExtensionAttribute>();
		}

		/// <summary>
		/// Returns all IThumbnailProvider classes
		/// </summary>
		/// <param name="resolver"></param>
		/// <returns></returns>
		internal static IEnumerable<Type> ResolveThumbnailProviders(this PluginManager resolver)
		{
			return resolver.ResolveTypes<IThumbnailProvider>();
		}

        /// <summary>
        /// Returns all IImageUrlProvider classes
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        internal static IEnumerable<Type> ResolveImageUrlProviders(this PluginManager resolver)
        {
            return resolver.ResolveTypes<IImageUrlProvider>();
        }

    }
}