﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        app.UseNancy();
        app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

    }
}