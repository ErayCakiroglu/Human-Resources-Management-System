using HRMS.Business.Abstract;
using HRMS.Business.Concrete;
using HRMS.Business.Helper.Abstract;
using HRMS.Business.Helper.Concrete;
using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Concrete;
using HRMS.DataAccess.Concrete.EntityFramework;
using HRMS.Entities.DTOs.Employee;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HRMSDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IEmployeeDal, EfEmployeeDal>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<IDepartmentDal, EfDepartmentDal>();
builder.Services.AddScoped<IDepartmentRoleService, DepartmentRoleManager>();
builder.Services.AddScoped<IDepartmentRoleDal, EfDepartmentRoleDal>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IRoleDal, EfRoleDal>();
builder.Services.AddScoped<ICodeGenerator<CreateEmployeeDTO>, EmployeeCodeGenerator>();
builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IDepartmentRelationService, DepartmentRelationManager>();
builder.Services.AddScoped<IEmployeeDepartmentRoleDal, EfEmployeeDepartmentRoleDal>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
