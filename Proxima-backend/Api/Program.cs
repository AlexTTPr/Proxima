using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
if(app.Environment.IsDevelopment())
{
	app.MapScalarApiReference(opt =>
	{
		opt
			.WithTitle("Proxima API")
			.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.Axios)
			.WithTheme(ScalarTheme.Alternate);
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
