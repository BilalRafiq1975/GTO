var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. Exception Handling (Safety net)
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Oops! Something broke.");
    });
});

// 2. Custom Middleware (Add a note)
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-MyNote", "Hi from me!");
    await next(context);
});

// 3. Short-Circuiting (Stop early)
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        await context.Response.WriteAsync("Stopped here!");
        return; // Short-circuit
    }
    await next(context);
});

// 4. Built-in Middleware (Secure it)
app.UseHttpsRedirection();

// 5. Final reply
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Made it to the end!");
    await next(context);
});

app.Run();