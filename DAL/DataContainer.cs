using DTO.Money;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataContainer
    {
        public DataContainer(IServiceCollection services)
        {
            //services.AddScoped<ExpensesDTO>();
            //services.AddScoped<IncomeDTO>();
            //services.AddScoped<SummaryDTO>();
        }
    }
}
