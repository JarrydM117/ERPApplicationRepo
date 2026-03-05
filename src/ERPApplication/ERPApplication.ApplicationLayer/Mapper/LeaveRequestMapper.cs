using ERPApplication.ApplicationLayer.DTOs.LeaveRequest;
using ERPApplication.DomainLayer.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Mapper
{
    public class LeaveRequestMapper
    {
        public LeaveRequest CreateToLeaveRequest(LeaveRequestCreateDTO create)
        {
            return new LeaveRequest(create.EmployeeId, create.StartDate, create.EndDate, create.LeaveTypeId);
        }

        public LeaveRequestPresentationDTO LeaveToPresenation(LeaveRequest leaveRequest)
        {
            return new LeaveRequestPresentationDTO(leaveRequest.Id, leaveRequest.EmployeeId, leaveRequest.StartDate, leaveRequest.EndDate, leaveRequest.LeaveTypeId,leaveRequest.DateApplied, leaveRequest.LeaveStatusId);
        }

        public List<LeaveRequestPresentationDTO> LeaveToPresenation(List<LeaveRequest> leaveRequest)
        {
            List<LeaveRequestPresentationDTO> presentation = new List<LeaveRequestPresentationDTO>();
            foreach(var l in leaveRequest)
            {
                presentation.Add(LeaveToPresenation(l));
            }
            return presentation;
        }

    }
}
