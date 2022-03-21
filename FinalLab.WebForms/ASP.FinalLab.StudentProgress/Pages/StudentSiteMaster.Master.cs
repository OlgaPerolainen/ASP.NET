using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.FinalLab.StudentProgress.Pages
{
    public partial class StudentSiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }
}