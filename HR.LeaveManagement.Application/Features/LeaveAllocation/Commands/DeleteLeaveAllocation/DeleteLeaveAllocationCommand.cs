﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
