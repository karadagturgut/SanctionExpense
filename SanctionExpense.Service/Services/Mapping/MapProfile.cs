﻿using AutoMapper;
using SanctionExpense.Core.Models;
using SanctionExpense.Core.Models.DTO;
using SanctionExpense.Core.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionExpense.Service.Services.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Expense,ExpenseDTO>().ReverseMap();
            CreateMap<ExpenseDTO,Expense>();

            CreateMap<Expense,ExpenseViewModel>().ReverseMap();
            CreateMap<ExpenseViewModel, Expense>();
        }
        
    }
}
