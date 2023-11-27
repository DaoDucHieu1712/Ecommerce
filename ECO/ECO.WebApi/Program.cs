using ECO.Infrastructure;
using ECO.Infrastructure.MailHelper;
using ECO.WebApi;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.Configure<MailSettingModel>(config.GetSection("MailSettings"));
builder.Services
    .AddIdentityECO(config)
    .AddAuthentication(config)  
    .AddRepository()
    .AddBusinessService()
    .AddWebAPI()
    .AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
