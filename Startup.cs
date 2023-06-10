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

        public Startup(IWebHostEnvironment hostEnv) //IWebHostEnvironment замість IHostingEnvironment
        {
            //отримання файлу зі строкою підключення БД
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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //підключення сервісу для роботи з сессіями
            services.AddScoped(sp => ShopCart.GetCart(sp));// для створення різних корзин

            services.AddMvc();
            services.AddMvc (mvcOtions => {
                mvcOtions.EnableEndpointRouting = false;
            });

            //зв'язування інтерфейсу з його реалізацією
            services.AddTransient<IAllToys, ToyRepository>();
            services.AddTransient<IToysCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage(); //Відображення помилок
            app.UseStatusCodePages(); //відображення коду сторінки
            app.UseStaticFiles(); //для відображення різних файлів, таких
                                  //як зображення, css-файли та інше
            app.UseSession();
            //app.UseMvcWithDefaultRoute(); //для маршрутизації за замовчування
            //прописуємо власну маршрутизацію та url-адреси
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                /*вище дефолтна функція заходу на сайт, тобто буде використовуватися контроллер Home який буде адресуватися на сторінку Index*/
                routes.MapRoute(name: "categoryFilter", template: "Toy/{action}/{category?}", defaults: new
                /*вище для фільтру категорій функція*/
               {
                   Controller = "Toys",
                   action = "List"
               });
                /*вище дефолтний контроллер та його функція, якщо фільтр невірний*/
            });



            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
