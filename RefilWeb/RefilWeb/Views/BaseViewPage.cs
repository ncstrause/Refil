using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefilWeb.Authentication;

namespace RefilWeb.Views
{
    public class BaseViewPage : WebViewPage
    {
        public virtual new RefilPrincipal User { get { return base.User as RefilPrincipal; } }

        public override void Execute()
        {
        }
    }
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new RefilPrincipal User { get { return base.User as RefilPrincipal; } }
    }
}