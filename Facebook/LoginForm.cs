using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace Facebook
{
    public partial class LoginForm : Form
    {
        private const string AppId = "1401298499950254";
        private Uri _loginUrl;
        private const string _ExtendedPermissions = "user_about_me";
        FacebookClient fbClient = new FacebookClient();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Login();
        }
        public void Login()
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = AppId;
            parameters.redirect_uri = "http://localhost:8080/facebook/";
            parameters.response_type = "token";
            parameters.display = "popup";
            if (!string.IsNullOrWhiteSpace(_ExtendedPermissions))
                parameters.scope = _ExtendedPermissions;
            _loginUrl = fbClient.GetLoginUrl(parameters);
            webBrowser1.Navigate(_loginUrl);
        }
    }
}
