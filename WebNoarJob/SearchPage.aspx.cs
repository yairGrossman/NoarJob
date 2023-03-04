using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebNoarJob
{
    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["buttonCreated"] != null)
            {
                if ((bool)ViewState["buttonCreated"])
                {
                    myButton();
                }
            }
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

        protected void SearchByTxtBtn_Click(object sender, EventArgs e)
        {
            searchByDomainDiv.Attributes.Add("class", "visibleFalse");

            searchByTxtDiv.Attributes.Remove("class");
        }

        protected void DomainBtn_Click(object sender, EventArgs e)
        {
            myButton();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
        }

        private void myButton()
        {
            HtmlButton button = new HtmlButton();
            button.Attributes.Add("class", "btn btn-outline-light mb-2 btn-lg px-3 myBtn float-end");
            button.Attributes.Add("runat", "server");
            button.InnerText = "Hello World";
            button.ServerClick += button_Click;
            btnDiv.Controls.Add(button);
            ViewState["buttonCreated"] = true;
        }
    }
}