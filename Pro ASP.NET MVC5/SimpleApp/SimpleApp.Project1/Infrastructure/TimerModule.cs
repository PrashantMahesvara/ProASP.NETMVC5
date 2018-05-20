using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace SimpleApp.Project1.Infrastructure
{
    public class TimerModule : IHttpModule
    {
        private Stopwatch timer;

        public void Init(HttpApplication app)
        {
            app.BeginRequest += HandleEvent;
            app.EndRequest += HandleEvent;
        }

        private void HandleEvent(object src, EventArgs args)
        {
            HttpContext ctx = HttpContext.Current;
            if(ctx.CurrentNotification == RequestNotification.BeginRequest)
            {
                timer = Stopwatch.StartNew();
            }
            else
            {
                ctx.Response.Write(string.Format
                    ("<div calss='alert alert-success'>Elapsed : {0:F5} seconds </div>",
                    ((float) timer.ElapsedTicks) / Stopwatch.Frequency));
            }
        }

        public void Dispose()
        {

        }


    }
}