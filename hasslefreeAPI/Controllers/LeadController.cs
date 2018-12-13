using hasslefreeAPI.Entities;
using hasslefreeAPI.Models;
using hasslefreeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hasslefreeAPI.Controllers
{
    [Route("api/[controller]")]
    public class LeadController: Controller
    {
        private readonly ILeadService _leadService;
        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet("GetLeads")]
        public IEnumerable<LeadDto> GetAllLead()
        {
            return _leadService.GetAllUsers();
        }

        [HttpGet("GetLeadById")]
        public LeadDto GetLead(int leadId)
        {
            return _leadService.GetLeadById(leadId);
        }

        [HttpPost("PostLead")]
        public LeadDto SaveLead([FromBody] LeadDto model)
        {

            return _leadService.CreateLead(model);
        }

        [HttpPost("UpdateLead")]
        public LeadDto Update([FromBody] LeadDto model)
        {

            return _leadService.UpdateLead(model);
        }

        [HttpPost("DeleteLead")]
        public void Delete(int leadId)
        {

           _leadService.DeleteLead(leadId);
        }
    }
}
