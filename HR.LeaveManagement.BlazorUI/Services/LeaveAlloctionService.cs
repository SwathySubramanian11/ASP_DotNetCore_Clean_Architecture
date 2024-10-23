using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveAlloctionService : BaseHttpService, ILeaveAllocationService
    {
        public LeaveAlloctionService(IClient client) : base(client)
        {
        }
    }
}
