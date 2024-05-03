﻿using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.ViewModels.CarViewModel;
using AutoService.Domain.Entities.ViewModels.NewsViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Queries
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IEnumerable<UserCar>>
    {
        private readonly IAppDbContext _context;

        public GetAllCarQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserCar>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Cars.ToListAsync(cancellationToken);
            return res.Skip(request.PageIndex - 1)
                    .Take(request.Size)
                            .ToList(); 
        }
    }
}
