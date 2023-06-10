using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToyMarket.Data;
using ToyMarket.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToyMarket.Data.Repository;
using ToyMarket.Data.Models;

namespace ToyMarket
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment hostEnv) //IWebHostEnvironment ������ IHostingEnvironment
        {
            //��������� ����� � ������� ���������� ��
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options =>
            {
                options.UseSqlServer(_confString.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //���������� ������ ��� ������ � �������
            services.AddScoped(sp => ShopCart.GetCart(sp));// ��� ��������� ����� ������

            services.AddMvc();
            services.AddMvc (mvcOtions => {
                mvcOtions.EnableEndpointRouting = false;
            });

            //��'�������� ���������� � ���� ����������
            services.AddTransient<IAllToys, ToyRepository>();
            services.AddTransient<IToysCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage(); //³���������� �������
            app.UseStatusCodePages(); //����������� ���� �������
            app.UseStaticFiles(); //��� ����������� ����� �����, �����
                                  //�� ����������, css-����� �� ����
            app.UseSession();
            //app.UseMvcWithDefaultRoute(); //��� ������������� �� ������������
            //��������� ������ ������������� �� url-������
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                /*���� �������� ������� ������ �� ����, ����� ���� ����������������� ���������� Home ���� ���� ������������ �� ������� Index*/
                routes.MapRoute(name: "categoryFilter", template: "Toy/{action}/{category?}", defaults: new
                /*���� ��� ������� �������� �������*/
               {
                   Controller = "Toys",
                   action = "List"
               });
                /*���� ��������� ���������� �� ���� �������, ���� ������ �������*/
            });



            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
