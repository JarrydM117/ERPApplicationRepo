using ERPApplication.ApplicationLayer.Common;
using ERPApplication.ApplicationLayer.DTOs.LeaveRequest;
using ERPApplication.ApplicationLayer.Mapper;
using ERPApplication.DomainLayer.Models.Common;
using ERPApplication.DomainLayer.Models.Leave;
using ERPApplication.InfrastructureLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Services
{
    public class LeaveRequestService
    {
        private readonly LeaveRequestRepository _leaveRequestRepository;
        private readonly LeaveRequestMapper _leaveRequestMapper;
        private readonly LeaveRepository _leaveRepository;
        public LeaveRequestService(LeaveRequestRepository leaveRequestRepository, LeaveRequestMapper leaveMapper, LeaveRepository leaveRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveRequestMapper = leaveMapper;
            _leaveRepository = leaveRepository;
        }


        public async Task<Result> GetAllSubordinateLeaveRequests(int employeeId, int statusId)
        {
            var leaveRequests = await _leaveRequestRepository.GetSubordinatesAllLeaveRequests(employeeId, statusId);
            var presentation = _leaveRequestMapper.LeaveToPresenation(leaveRequests);
            return Result<List<LeaveRequestPresentationDTO>>.Success(presentation);
        }

        public async Task<Result> GetEmployeeLeaveRequests(int employeeId)
        {
            var leaveRequests = await _leaveRequestRepository.GetEmployeeLeaveRequests(employeeId);
            var presentation = _leaveRequestMapper.LeaveToPresenation(leaveRequests);
            return Result<List<LeaveRequestPresentationDTO>>.Success(presentation);
        }

        public async Task<Result> CreateLeaveRequest(LeaveRequestCreateDTO create)
        {
            var leaveRequest = _leaveRequestMapper.CreateToLeaveRequest(create);
            leaveRequest.CreateLeaveRequest();
            if (leaveRequest.CalculateDaysTaken() == 0)
                return Result.Unsuccessful(ErrorType.InvalidOperation, "You cannot take zero days of leave.");
            if (await ValidateLeaveDate(leaveRequest))
                return Result.Unsuccessful(ErrorType.InvalidOperation,"You cannot take leave, if a successful application already exists for the requested day.");
            var leave = await GetLeave(leaveRequest.EmployeeId,leaveRequest.LeaveTypeId);
            if (!leave.ValidateLeave(leaveRequest.CalculateDaysTaken()))
                return Result.Unsuccessful(ErrorType.InvalidData, "Insufficient amount of leave days.");
            return await Create(leaveRequest) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedInsertion,"Could not insert request.");
        }

        public async Task<Result> UpdateLeaveStatus(LeaveRequestUpdateDTO update)
        {
            var leaveRequest = await Get(update.Id);
            if (leaveRequest == null)
                return Result.Unsuccessful(ErrorType.NotFound, "Could not find leave request.");
            leaveRequest.EditLeaveStatus(update.LeaveStatusId);
            return leaveRequest.LeaveStatusId == 2 ? await ApproveLeave(leaveRequest) : await RejectLeave(leaveRequest);
        }


        public async Task<Result> CancelLeaveRequest(LeaveRequestUpdateDTO update)
        {
            var leaveRequest = await Get(update.Id);
            if (leaveRequest == null)
                return Result.Unsuccessful(ErrorType.NotFound, "Could not find leave request.");
            if(leaveRequest.LeaveStatusId == 2)
            {
                var leave = await GetLeave(leaveRequest.EmployeeId, leaveRequest.LeaveTypeId);
                if (leave == null)
                    return Result.Unsuccessful(ErrorType.NotFound, "Could not find leave, please contact your administrator.");
                leave.AddLeaveBack(leaveRequest.CalculateDaysTaken());
                leaveRequest.EditLeaveStatus(update.LeaveStatusId);
                return await LeaveTransaction(leaveRequest, leave) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate, "Could not update leave request and leave values, please try again.");
            }
            leaveRequest.EditLeaveStatus(update.LeaveStatusId);
            return await Update(leaveRequest) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate, "Could not update leave request and leave values, please try again.");
        }


        private async Task<Result> ApproveLeave(LeaveRequest leaveRequest)
        {
            var leave = await GetLeave(leaveRequest.EmployeeId, leaveRequest.LeaveTypeId);
            if (leave == null)
                return Result.Unsuccessful(ErrorType.NotFound, "Could not find leave, please contact your administrator.");
            leave.SubtractLeave(leaveRequest.CalculateDaysTaken());
            return await LeaveTransaction(leaveRequest, leave) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate,"Could not update leave request and leave values, please try again.");
        }

        private async Task<Result> RejectLeave(LeaveRequest leaveRequest)
        {
            return await Update(leaveRequest) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedInsertion,"Could not cancel leave request.");
        }

        private async Task<bool> Create(LeaveRequest leaveRequest) => await _leaveRequestRepository.Create(leaveRequest) == 1;
        private async Task<bool> Update(LeaveRequest leaveRequest) => await _leaveRequestRepository.Update(leaveRequest) == 1;
        private async Task<LeaveRequest?> Get(int Id) => await _leaveRequestRepository.Get(Id);
        private async Task<bool> ValidateLeaveDate(LeaveRequest leaveRequest) => await _leaveRequestRepository.ValidateOverlap(leaveRequest);
        private async Task<Leave?> GetLeave(int employeeId, int leaveTypeId) => await _leaveRepository.Get(employeeId, leaveTypeId);
        private async Task<bool> LeaveTransaction(LeaveRequest leaveRequest, Leave leave) => await  _leaveRequestRepository.LeaveTransaction(leaveRequest, leave);
    }
}
