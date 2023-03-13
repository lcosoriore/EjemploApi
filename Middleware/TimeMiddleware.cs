namespace EjemploApi.Middleware
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;

        public TimeMiddleware(RequestDelegate nextRequest)
        {
            next= nextRequest;
        }

        public async Task Invoke(HttpContext context)
        {
            await next(context);
            if (context.Request.Query.Any(p =>p.Key=="time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            }
            
        }

    }
}
