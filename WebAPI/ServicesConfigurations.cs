using DAL.DBContext;
using DAL.Entity;
using Domain.Mappers;
using Domain.Repository;
using Domain.Seeds;
using Domain.Services.AppUserService;
using Domain.Services.ClientService;
using Domain.Services.ContactPersonService;
using Domain.Services.ContractService;
using Domain.Services.DocumentService;
using Domain.Services.InvoiceService;
using Domain.Services.OrderService;
using Domain.Services.ShipService;
using Example.Domain.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Middleware;

namespace WebAPI
{
    public static class ServicesConfigurations
    {
        private static readonly IConfiguration configuration;

        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            ConfigureAppDbContext(builder);
            ConfigureAuthentication(builder);
            ConfigureAuthorization(builder);
            RegisterServices(builder.Services);
            AddMappers(builder.Services);
        }

        private static void ConfigureAppDbContext(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("DAL"));
            });

            builder.Services.AddIdentityCore<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();
        }

        public static async void DatabaseMigrate(this IServiceProvider serviceProvider)
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                context.Database.Migrate();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await RoleInitializer.InitializeRole(roleManager);

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                await SuperAdminInitializer.InitializeSuperAdmin(userManager, configuration);

                var clientInitializer = new ClientInitializer(context);
                clientInitializer.InitializeClients();

                var contactPersonInitializer = new ContactPersonInitializer(context);
                contactPersonInitializer.InitializeContactPersons();

                var shipInitializer = new ShipInitializer(context);
                shipInitializer.InitializeShips();

                var contractInitializer = new ContractInitializer(context);
                contractInitializer.InitializeContracts();

                var orderInitializer = new OrderInitializer(context);
                orderInitializer.InitializeOrders();

                var documentInitializer = new DocumentInitializer(context);
                documentInitializer.InitializeDocuments();

                var invioceInitializer = new InvoiceInitializer(context);
                invioceInitializer.InitializeInvoices();
            }
        }

        private static void ConfigureAuthentication(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])
                    ),
                    ValidateLifetime = true
                };
            });

        }

        private static void ConfigureAuthorization(WebApplicationBuilder builder)
        {
            //builder.Services.AddAuthorization(options =>
            //{
            //    foreach (var permissionId in PermissionIdList.GetPermissions())
            //    {
            //        options.AddPolicy(permissionId, policy =>
            //        {
            //            policy.RequireClaim(CustomClaimsType.PERMISSION_ID, permissionId);
            //        });
            //    }
            //});
        }

        private static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();
            serviceCollection.AddHttpClient();

            serviceCollection.AddScoped<HttpClient>();
            //serviceCollection.AddScoped<JWTService>();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped<AppUserService>();
            serviceCollection.AddScoped<ShipService>();
            serviceCollection.AddScoped<ClientService>();
            serviceCollection.AddScoped<ContactPersonService>();
            serviceCollection.AddScoped<ContractService>();
            serviceCollection.AddScoped<InvoiceService>();
            serviceCollection.AddScoped<OrderService>();
            serviceCollection.AddScoped<DocumentService>();
        }

        private static void AddMappers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ClientMappingProfile));
            serviceCollection.AddAutoMapper(typeof(ContactPersonMappingProfile));
            serviceCollection.AddAutoMapper(typeof(ContractMappingProfile));
            serviceCollection.AddAutoMapper(typeof(OrderMappingProfile));
            serviceCollection.AddAutoMapper(typeof(DocumentMappingProfile));
            serviceCollection.AddAutoMapper(typeof(ShipMappingProfile));
            serviceCollection.AddAutoMapper(typeof(InvoiceMappingProfile));
            serviceCollection.AddAutoMapper(typeof(AppUserMappingProfile));
        }

        public static void RegisterMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
