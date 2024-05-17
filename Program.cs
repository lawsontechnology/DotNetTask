
using ApplicationFormTask.Core.Application.Implementation.Service;
using ApplicationFormTask.Core.Application.Interface.Repositories;
using ApplicationFormTask.Core.Application.Interface.Services;
using ApplicationFormTask.Infrastructure.Context;
using ApplicationFormTask.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApplicationForm", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationFormTaskContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("ApplicationForm")));
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IChoiceRepository,  ChoiceRepository>();
builder.Services.AddScoped<ICustomQuestionRepository, CustomQuestionRepository>();
builder.Services.AddScoped<IDateQuestionRepository, DateQuestionRepository>();
builder.Services.AddScoped<IDropdownQuestionRepository, DropdownQuestionRepository>();
builder.Services.AddScoped<IMultipleQuestionRepository, MultipleQuestionRepository>();
builder.Services.AddScoped<INumericQuestionRepository,  NumericQuestionRepository>();
builder.Services.AddScoped<IParagraphQuestionRepository,  ParagraphQuestionRepository>();
builder.Services.AddScoped<IPersonalInformationRepository,  PersonalInformationRepository>();
builder.Services.AddScoped<IProgramEntityRepository, ProgramEntityRepository>();
builder.Services.AddScoped<IYesOrNoQuestionRepository, YesOrNoQuestionRepository>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<ICustomQuestionService, CustomQuestionService>();
builder.Services.AddScoped<IPersonalInformationService,  PersonalInformationService>();
builder.Services.AddScoped<IProgramEntityService,  ProgramEntityService>();
builder.Services.AddScoped<IQuestionTypesService, QuestionTypesService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
