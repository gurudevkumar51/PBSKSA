using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminDal.Common
{
    public static class HtmlHelperExt
    {
        public static bool ActivePage(this HtmlHelper helper, string action, string controller)
        {
            bool classValue = false;
            string currentController = helper.ViewContext.RouteData.Values["controller"].ToString();
            string currentAction = helper.ViewContext.RouteData.Values["action"].ToString();
            if (currentController.ToLower() == controller.ToLower() && currentAction.ToLower() == action.ToLower())
            {
                classValue = true;
            }
            return classValue;
        }

        private static string defaultImage = ConfigurationManager.AppSettings["DefaultImagePath"].ToString();
        private static string uploadsDirectory = ConfigurationManager.AppSettings["DealerSchemePath"].ToString();
        private static string uploadsDirectory1 = ConfigurationManager.AppSettings["RetailerSchemePath"].ToString();
        private static string defaultUserImage = ConfigurationManager.AppSettings["DefaultUserImagePath"].ToString();
        private static string uploadsDirectory2 = ConfigurationManager.AppSettings["ProfileImagePath"].ToString();
        //dealer
        public static string ImageOrDefaultD(this HtmlHelper helper, string filename)
        {
            var imagePath = uploadsDirectory + filename;
            var imageSrc = File.Exists(HttpContext.Current.Server.MapPath(imagePath))
                               ? imagePath : defaultImage;
            return imageSrc;
        }
        //retailer
        public static string ImageOrDefaultR(this HtmlHelper helper, string filename)
        {
            var imagePath = uploadsDirectory1 + filename;
            var imageSrc = File.Exists(HttpContext.Current.Server.MapPath(imagePath))
                               ? imagePath : defaultImage;
            return imageSrc;
        }

        //user
        public static string ImageOrDefaultUser(this HtmlHelper helper, string filename)
        {
            var imagePath = uploadsDirectory2 + filename;
            var imageSrc = File.Exists(HttpContext.Current.Server.MapPath(imagePath))
                               ? imagePath : defaultUserImage;
            return imageSrc;
        }
        public static MvcHtmlString Image(this HtmlHelper helper, string id, string src, string alt, object htmlAttributes = null)
        {
            // Create tag builder
            var builder = new TagBuilder("img");
            // Create valid id
            builder.GenerateId(id);
            // Add attributes
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
