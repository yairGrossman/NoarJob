using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebNoarJob
{
    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {

        }

        protected void SearchByDomainBtn_Click(object sender, EventArgs e)
        {
            searchByTxtDiv.Attributes.Add("class", "visibleFalse");

            searchByDomainDiv.Attributes.Remove("class");
            searchByDomainDiv.Attributes.Add("class", "row");

        }
    }
}