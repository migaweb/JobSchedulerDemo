using AutoMapper;
using JobSchedulerDemo.Application.Dtos;
using JobSchedulerDemo.Domain;

namespace JobSchedulerDemo.Application.Profiles;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    #region ScheduledJobStatus

    CreateMap<ScheduledJobStatus, ScheduledJobStatusDto>().ReverseMap();

    #endregion

    #region ScheduledJob

    CreateMap<ScheduledJob, ScheduledJobDto>().ReverseMap();
    CreateMap<ScheduledJob, CreateScheduledJobDto>().ReverseMap();

    #endregion
  }
}
