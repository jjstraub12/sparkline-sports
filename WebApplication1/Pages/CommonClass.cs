using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public static class CommonClass
    {
        public static ImageField img_path(string url, string cssClass)
        {
            ImageField imgField = new ImageField();
            imgField.DataImageUrlField = url;
            imgField.ItemStyle.CssClass = cssClass;
            return imgField;
        }

        public static BoundField bound_field(string dataField, string headerText, string cssClass, string dataFormatString = "")
        {
            BoundField boundField = new BoundField();
            boundField.DataField = dataField;
            boundField.HeaderText = headerText;
            boundField.ItemStyle.CssClass = cssClass;
            if (dataFormatString != "")
                boundField.DataFormatString = dataFormatString;
            return boundField;
        }
    }
}