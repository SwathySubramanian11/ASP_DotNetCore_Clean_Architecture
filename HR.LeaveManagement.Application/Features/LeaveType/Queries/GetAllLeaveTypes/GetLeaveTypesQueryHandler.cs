﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //Convert data objects to DTO objects
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);  //Possible from the leaveType Mapping profile

            //retrun list of DTO object
            _logger.LogInformation("Leave types were retrieved successfully");
            return data;
        }
    }
}
