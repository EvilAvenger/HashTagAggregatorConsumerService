﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HashTagAggregatorConsumer.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5020/")
                .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .UseApplicationInsights()
                .Build();
    }
}
