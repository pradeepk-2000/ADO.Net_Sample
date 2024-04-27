
using PerfectSql.Interfaces;
using PerfectSql.Repository;
using PerfectSql.SqlDbFactory.Interfaces;
using PerfectSql.SqlDbFactory.SqlRepository;

namespace PerfectSql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("EmployeeManagementConnection");

            // Add services to the container.
            builder.Services.AddTransient<IconnectionFactory>(provider =>
                new ConnectionFactory(connectionString));
            builder.Services.AddTransient<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddTransient<ISqlReaderMapper, SqlReaderMapper>();

            builder.Services.AddControllers();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
