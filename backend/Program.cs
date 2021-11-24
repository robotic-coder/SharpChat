using backend.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "policy",
        builder =>
        {
            builder.WithOrigins("http://localhost:5232", "https://localhost:7074")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

app.UseCors("policy");

app.UseAuthorization();

//app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.Run();
