﻿using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
//using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile() 
        {
            CreateMap<LeaveAllocationDto, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationDto>();
            //CreateMap<CreateLeaveAllocationCommand,LeaveAllocation>();
            //CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }
    }
}
