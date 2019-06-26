using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using graphqldemo.mock;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace graphqldemo.webapi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IWebHost host = CreateWebHostBuilder(args).Build();

			using (IServiceScope scope = host.Services.CreateScope())
			{
				ApplicationDbContextSeed.Initialize(scope);
			}

			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
