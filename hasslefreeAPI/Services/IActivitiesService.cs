using hasslefreeAPI.Models;
using System.Collections.Generic;

namespace hasslefreeAPI.Services
{
    public interface IActivitiesService
    {
        IEnumerable<ActivitiesDto> GetAllActivities();
        ActivitiesDto GetActivityById(int activityId);
        ActivitiesDto CreateActivity(ActivitiesDto objActivitiesDto);
        ActivitiesDto UpdateActivity(ActivitiesDto objActivitiesDto);
        void DeleteActivity(int activityId);
    }
}
