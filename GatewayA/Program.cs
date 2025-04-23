
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.IdentityModel.Tokens;
//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;
//using Ocelot.Values;
//using System.Security.Claims;
//using System.Text;

//namespace GatewayA
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers().AddJsonOptions(options =>

//            {

//                // Set naming policy to null to preserve property names

//                options.JsonSerializerOptions.PropertyNamingPolicy = null;

//            });
//            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
//            builder.Services.AddOcelot(builder.Configuration);
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();
//            var secretKey = builder.Configuration["ApiSettings:JwtOptions:SecretKey"];
//            if (string.IsNullOrEmpty(secretKey))
//            {
//                throw new ArgumentNullException("ApiSettings:JwtOptions:SecretKey", "SecretKey is missing in configuration.");
//            }
//            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//            {
//                options.TokenValidationParameters = new TokenValidationParameters
//                {
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidateLifetime = true,
//                    ValidateIssuerSigningKey = true,
//                    RoleClaimType = ClaimTypes.Role,
//                    ValidIssuer = builder.Configuration["ApiSettings:JwtOptions:Issuer"],
//                    ValidAudience = builder.Configuration["ApiSettings:JwtOptions:Audience"],
//                    IssuerSigningKey = new SymmetricSecurityKey(
//                        Encoding.UTF8.GetBytes(secretKey)
//                    ),
//                };
//            });

//            builder.Services.AddAuthorization();

//            var app = builder.Build();

//            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

//            // Configure the HTTP request pipeline.

//            if (app.Environment.IsDevelopment())

//            {
//                app.UseSwagger();

//                app.UseSwagger();

//            }

//            app.UseHttpsRedirection();

//            app.UseAuthentication();

//            app.UseAuthorization();


//            app.MapControllers();
//            app.UseOcelot();

//            app.Run();
//        }
//    }
//}
