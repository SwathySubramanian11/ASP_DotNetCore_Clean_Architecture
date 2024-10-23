using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext.Repositories;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
    }

    public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        throw new NotImplementedException();
    }
}