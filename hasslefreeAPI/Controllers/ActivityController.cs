using hasslefreeAPI.Models;
using hasslefreeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        private readonly IActivitiesService _activitiesService;
        public ActivityController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpGet("GetActivities")]
        public IEnumerable<ActivitiesDto> GetAllActivities()
        {
            return _activitiesService.GetAllActivities();
        }

        [HttpGet("GetActivityById")]
        public ActivitiesDto GetActivity(int activityId)
        {
            return _activitiesService.GetActivityById(activityId);
        }

        [HttpPost("PostActivity")]
        public ActivitiesDto SaveActivity([FromBody] ActivitiesDto model)
        {

            return _activitiesService.CreateActivity(model);
        }

        [HttpPost("UpdateActivity")]
        public ActivitiesDto Update([FromBody] ActivitiesDto model)
        {

            return _activitiesService.UpdateActivity(model);
        }

        [HttpPost("DeleteActivity")]
        public void Delete(int activityId)
        {

            _activitiesService.DeleteActivity(activityId);
        }
    }
}
