using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using StoreApplication.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder (args);
builder.Services.AddDependencies ();
builder.Services.AddServiceProviders ();
builder.Services.AddDatabase (builder.Configuration.GetConnectionString ("DefaultConnection"));
WebApplication app = builder.Build ();
if (app.Environment.IsDevelopment ())
{
    app.UseDeveloperExceptionPage ();
    app.UseSwagger ();
    app.UseSwaggerUI (options => options.SwaggerEndpoint ("/api-docs/swagger.json", "STORE API V1"));
}
else
{
    app.UseExceptionHandler ();
    app.UseHsts ();
}

app.UseHttpsRedirection ();
app.UseCookiePolicy ();
app.UseRouting ();
app.MapControllers ();
app.UseCors ("*");
app.UseAuthentication ();
app.UseAuthorization ();
app.Run ();
