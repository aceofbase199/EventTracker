using EventTracker.Configuration;
using EventTracker.JsonServer;
using EventTracker.Services;
using EventTracker.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace EventTracker
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
      services.AddAuthentication(options =>
        {
          options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddOpenIdConnect(options =>
        {
          options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.Authority = Configuration["Okta:Domain"] + "/oauth2/default";
          options.RequireHttpsMetadata = true;
          options.ClientId = Configuration["Okta:ClientId"];
          options.ClientSecret = Configuration["Okta:ClientSecret"];
          options.ResponseType = OpenIdConnectResponseType.Code;
          options.GetClaimsFromUserInfoEndpoint = true;
          options.Scope.Add("openid");
          options.Scope.Add("profile");
          options.SaveTokens = true;
          options.TokenValidationParameters = new TokenValidationParameters
          {
            NameClaimType = "name",
            RoleClaimType = "groups",
            ValidateIssuer = true
          };
        });

      services.AddAuthorization();
      services.AddControllersWithViews();

      services.AddSingleton<IJsonServerApi, JsonServerApi>();
      services.AddSingleton<IConnectionService, ConnectionService>();
      services.AddTransient<IUserService, UserService>();

      var appSettings = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettings);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
