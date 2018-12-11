using hasslefreeAPI.Entities;
using hasslefreeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hasslefreeAPI.Services
{
    public interface ILeadService
    {
        IEnumerable<LeadDto> GetAllUsers();
        LeadDto GetLeadById(int leadId);
        LeadDto CreateLead(LeadDto objLeadDto);
        LeadDto UpdateLead(LeadDto objLeadDto);
        void DeleteLead(int leadId);
    }
}
