﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Forum1._0.Startup))]
namespace Forum1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
