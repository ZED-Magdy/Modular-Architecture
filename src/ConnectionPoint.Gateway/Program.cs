using ConnectionPoint.Core.Application;
using ConnectionPoint.Inventory.Application;
using ConnectionPoint.Voucher.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddControllers();
builder.Services
    .AddACommonServices(builder.Configuration)
    .AddAInventoryModule(builder.Configuration)
    .AddAVoucherModule(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseHsts();
app.UseAuthorization();

app.MapControllers();

app.Run();