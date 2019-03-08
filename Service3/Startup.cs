using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Service3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Consul 新增 IApplicationLifetime appLifeTime参数
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifeTime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //注册Consul 
            string ip = "localhost";
            string port = "39993";
            string serviceName = "DemoService";
            string serviceId = serviceName + Guid.NewGuid();
            using (var consulClient = new ConsulClient(ConsulConfig))
            {
                AgentServiceRegistration asr = new AgentServiceRegistration
                {
                    Address = ip,
                    Port = Convert.ToInt32(port),
                    ID = serviceId,
                    Name = serviceName,
                    Check = new AgentServiceCheck
                    {
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                        HTTP = $"http://{ip}:{port}/api/Health",
                        Interval = TimeSpan.FromSeconds(10),
                        Timeout = TimeSpan.FromSeconds(5),
                    },
                };
                consulClient.Agent.ServiceRegister(asr).Wait();
            }

            //注销Consul 
            appLifeTime.ApplicationStopped.Register(() =>
            {
                using (var consulClient = new ConsulClient(ConsulConfig))
                {
                    consulClient.Agent.ServiceDeregister(serviceId).Wait();
                }
            });
        }

        //Consul 配置委托
        private void ConsulConfig(ConsulClientConfiguration config)
        {
            config.Address = new Uri("http://127.0.0.1:8500"); //Demo硬编码Consul的地址
            config.Datacenter = "dc1";
        }
    }
}
