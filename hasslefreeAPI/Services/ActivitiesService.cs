using AutoMapper;
using hasslefreeAPI.Entities;
using hasslefreeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hasslefreeAPI.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly HassleFreeContext _context;
        private readonly IMapper _mapper;

        public ActivitiesService(HassleFreeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ActivitiesDto> GetAllActivities()
        {
            return _mapper.Map<ActivitiesDto[]>(_context.Activities.ToArray().Where(x => x.FlagActive == true));
        }

        public ActivitiesDto GetActivityById(int activityId)
        {
            return _mapper.Map<ActivitiesDto>(_context.Activities.
               SingleOrDefault(x => x.ActivityId == activityId && x.FlagActive == true));
        }

        public ActivitiesDto CreateActivity(ActivitiesDto objActivitiesDto)
        {
            Activities objActivities = _mapper.Map<Activities>(objActivitiesDto);
            objActivities.CreatedDateTime = DateTime.Now;
            objActivities.CreatedBy = 1;
            _context.Activities.Add(objActivities);
            _context.SaveChanges();

            return _mapper.Map<ActivitiesDto>(_context.Activities.
               SingleOrDefault(x => x.ActivityId == objActivitiesDto.ActivityId));
        }

        public ActivitiesDto UpdateActivity(ActivitiesDto objActivitiesDto)
        {
            Activities objActivities = _mapper.Map<Activities>(objActivitiesDto);
            Activities objActivitiesData = _context.Activities.Find(objActivitiesDto.ActivityId);
            objActivities.ModifiedDateTime = DateTime.Now;
            objActivities.ModifiedBy = 1;
            _context.Entry(objActivitiesData).CurrentValues.SetValues(objActivities);
            _context.SaveChanges();
            return _mapper.Map<ActivitiesDto>(_context.Activities.
               SingleOrDefault(x => x.ActivityId == objActivitiesDto.ActivityId));
        }

        public void DeleteActivity(int activityId)
        {
            Activities objActivities = _context.Activities.Find(activityId);
            objActivities.FlagActive = false;
            _context.Entry(objActivities).CurrentValues.SetValues(objActivities);
            _context.SaveChanges();
        }
    }
}
