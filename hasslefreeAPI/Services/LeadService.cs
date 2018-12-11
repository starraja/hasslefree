using AutoMapper;
using hasslefreeAPI.Entities;
using hasslefreeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hasslefreeAPI.Services
{
    public class LeadService : ILeadService
    {
        private readonly HassleFreeContext _context;
        private readonly IMapper _mapper;

        public LeadService( HassleFreeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<LeadDto> GetAllUsers()
        {
            return _mapper.Map<LeadDto[]>(_context.Leads.ToArray().Where(x => x.FlagActive == true));
        }

        public LeadDto GetLeadById(int leadId)
        {
            return _mapper.Map<LeadDto>(_context.Leads.
               SingleOrDefault(x => x.LeadId == leadId && x.FlagActive == true));
        }

        public LeadDto CreateLead(LeadDto objLeadDto)
        {
            Leads objLeads = _mapper.Map<Leads>(objLeadDto);

            objLeads.CreatedDateTime = DateTime.Now;
            objLeads.CreatedBy = 1;

            _context.Leads.Add(objLeads);
            _context.SaveChanges();

            return _mapper.Map<LeadDto>(_context.Leads.
               SingleOrDefault(x => x.LeadId == objLeadDto.LeadId));
        }

        public LeadDto UpdateLead(LeadDto objLeadDto)
        {
            Leads objLeads = _mapper.Map<Leads>(objLeadDto);
            Leads objLeadsData = _context.Leads.Find(objLeadDto.LeadId);
            objLeads.ModifiedDateTime = DateTime.Now;
            objLeads.ModifiedBy = 1;
            _context.Entry(objLeadsData).CurrentValues.SetValues(objLeads);
            _context.SaveChanges();
            return _mapper.Map<LeadDto>(_context.Leads.
               SingleOrDefault(x => x.LeadId == objLeadDto.LeadId));
        }

        public void DeleteLead(int leadId)
        {
            Leads objLeads = _context.Leads.Find(leadId);
            objLeads.FlagActive = false;
            _context.Entry(objLeads).CurrentValues.SetValues(objLeads);
            _context.SaveChanges();
        }

    }
}
