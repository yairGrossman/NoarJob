using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNoarJob
{
    public partial class SignupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignupBtn_Click(object sender, EventArgs e)
        {
            if (email.Text == "test@gmail.com"
                && myPassword.Text == "123"
                && fName.Text == "Yair"
                && lName.Text == "Grossman"
                && phone.Text == "0123456789")
            {
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}