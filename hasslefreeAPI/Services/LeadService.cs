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

        public LeadService(HassleFreeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<LeadDto> GetAllUsers()
        {
            var leadList = (from p in _context.Leads
                            select new LeadDto
                            {
                                LeadId = p.LeadId,
                                Description = p.Description,
                                Salutation = p.Salutation,
                                LeadFirstName = p.LeadFirstName,
                                LeadLastName = p.LeadLastName,
                                LeadDate = p.LeadDate,
                                Email = p.Email,
                                SalesStage = p.SalesStage,
                                LeadOwnerExecutiveId = p.LeadOwnerExecutiveId,
                                WorkPhone = p.WorkPhone,
                                MobilePhone = p.MobilePhone,
                                AddressLine1 = p.AddressLine1,
                                AddressLine2 = p.AddressLine2,
                                AddressLine3 = p.AddressLine3,
                                City = p.City,
                                State = p.State,
                                PostalCode = p.PostalCode,
                                Country = p.Country,
                                CompanyName = p.CompanyName,
                                CompanyAddressLine1 = p.CompanyAddressLine1,
                                CompanyAddressLine2 = p.CompanyAddressLine2,
                                CompanyAddressLine3 = p.CompanyAddressLine3,
                                CompanyCity = p.CompanyCity,
                                CompanyState = p.CompanyState,
                                CompanyPostalCode = p.CompanyPostalCode,
                                CompanyCountry = p.CompanyCountry,
                                CompanyWebsite = p.CompanyWebsite,
                                CompanyTurnover = p.CompanyTurnover,
                                IndustryId = p.IndustryId,
                                IndustrySubTypeId = p.IndustrySubTypeId,
                                LeadSource = p.LeadSource,
                                DetailDescription = p.DetailDescription,
                                ContactId = p.ContactId,
                                OpportunityId = p.OpportunityId,
                                AccountId = p.AccountId,
                                Converted = p.Converted,
                                ProductList = _mapper.Map<ProductListDto[]>((from q in _context.ProductList
                                                                             where q.ReferenceId == p.LeadId
                                                                             select q
                                        )).ToList(),
                                Activities = _mapper.Map<ActivitiesDto[]>((from q in _context.Activities
                                                                           where q.ReferenceId == p.LeadId
                                                                           select q
                                        )).ToList()
                            }).ToList();

            //return _mapper.Map<LeadDto[]>(_context.Leads.ToArray().Where(x => x.FlagActive == true));
            return leadList;
        }

        public LeadDto GetLeadById(int leadId)
        {
            var lead = (from p in _context.Leads
                        where p.LeadId == leadId
                        select new LeadDto
                        {
                            LeadId = p.LeadId,
                            Description = p.Description,
                            Salutation = p.Salutation,
                            LeadFirstName = p.LeadFirstName,
                            LeadLastName = p.LeadLastName,
                            LeadDate = p.LeadDate,
                            Email = p.Email,
                            SalesStage = p.SalesStage,
                            LeadOwnerExecutiveId = p.LeadOwnerExecutiveId,
                            WorkPhone = p.WorkPhone,
                            MobilePhone = p.MobilePhone,
                            AddressLine1 = p.AddressLine1,
                            AddressLine2 = p.AddressLine2,
                            AddressLine3 = p.AddressLine3,
                            City = p.City,
                            State = p.State,
                            PostalCode = p.PostalCode,
                            Country = p.Country,
                            CompanyName = p.CompanyName,
                            CompanyAddressLine1 = p.CompanyAddressLine1,
                            CompanyAddressLine2 = p.CompanyAddressLine2,
                            CompanyAddressLine3 = p.CompanyAddressLine3,
                            CompanyCity = p.CompanyCity,
                            CompanyState = p.CompanyState,
                            CompanyPostalCode = p.CompanyPostalCode,
                            CompanyCountry = p.CompanyCountry,
                            CompanyWebsite = p.CompanyWebsite,
                            CompanyTurnover = p.CompanyTurnover,
                            IndustryId = p.IndustryId,
                            IndustrySubTypeId = p.IndustrySubTypeId,
                            LeadSource = p.LeadSource,
                            DetailDescription = p.DetailDescription,
                            ContactId = p.ContactId,
                            OpportunityId = p.OpportunityId,
                            AccountId = p.AccountId,
                            Converted = p.Converted,
                            Contact=_mapper.Map<ContactsDto>( _context.Contacts.SingleOrDefault(s=>s.ContactId==p.ContactId)),
                            ProductList = _mapper.Map<ProductListDto[]>((from q in _context.ProductList
                                                                         where q.ReferenceId == p.LeadId
                                                                         select q
                                    )).ToList(),
                            Activities = _mapper.Map<ActivitiesDto[]>((from q in _context.Activities
                                                                       where q.ReferenceId == p.LeadId
                                                                       select q
                                    )).ToList()
                        }).SingleOrDefault();
            return lead;
            //return _mapper.Map<LeadDto>(_context.Leads.x
            //   SingleOrDefault(x => x.LeadId == leadId && x.FlagActive == true));
        }

        public LeadDto CreateLead(LeadDto objLeadDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Contacts objContact = _mapper.Map<Contacts>(objLeadDto.Contact);
                    objContact.AccountId = null;
                    objContact.CreatedDateTime = DateTime.Now;
                    objContact.ModifiedDateTime = DateTime.Now;
                    objContact.CreatedBy = 1;
                    _context.Contacts.Add(objContact);
                    _context.SaveChanges();

                    Leads objLeads = _mapper.Map<Leads>(objLeadDto);
                    objLeads.AccountId = null;
                    objLeads.CreatedDateTime = DateTime.Now;
                    objLeads.ModifiedDateTime = DateTime.Now;
                    objLeads.CreatedBy = 1;
                    objLeads.ContactId = objContact.ContactId;
                    _context.Leads.Add(objLeads);
                    _context.SaveChanges();
                    if (objLeadDto.ProductList.Count > 0)
                    {
                        foreach (var product in objLeadDto.ProductList)
                        {
                            ProductListDto objProductListDto = product;
                            ProductList objProductList = _mapper.Map<ProductList>(objProductListDto);
                            objProductList.ReferenceId = objLeads.LeadId;
                            objProductList.Source = 1;
                            objProductList.ProductId = product.ProductId;
                            objProductList.CreatedBy = 1;
                            objProductList.CreatedDateTime = DateTime.Now;
                            objProductList.ModifiedDateTime = DateTime.Now;
                            _context.ProductList.Add(objProductList);
                        }
                    }
                    if (objLeadDto.Activities.Count > 0)
                    {
                        foreach (var activity in objLeadDto.Activities)
                        {
                            ActivitiesDto objActivitiesDto = activity;
                            Activities objActivities = _mapper.Map<Activities>(objActivitiesDto);
                            objActivities.ReferenceId = objLeads.LeadId;
                            objActivities.Source = 1;
                            objActivities.CreatedBy = 1;
                            objActivities.CreatedDateTime = DateTime.Now;
                            objActivities.ModifiedDateTime = DateTime.Now;
                            _context.Activities.Add(objActivities);
                        }
                    }
                    _context.SaveChanges();
                    transaction.Commit();
                    return _mapper.Map<LeadDto>(_context.Leads.
                       SingleOrDefault(x => x.LeadId == objLeads.LeadId));
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

            }
        }

        public LeadDto UpdateLead(LeadDto objLeadDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Contacts objContact = _mapper.Map<Contacts>(objLeadDto.Contact);
                    Contacts objContactsData = _context.Contacts.Find(objLeadDto.Contact.ContactId);
                    objContact.ModifiedDateTime = DateTime.Now;
                    objContact.ModifiedBy = 1;
                    _context.Contacts.Add(objContact);
                    _context.SaveChanges();

                    Leads objLeads = _mapper.Map<Leads>(objLeadDto);
                    Leads objLeadsData = _context.Leads.Find(objLeadDto.LeadId);
                    objLeads.ModifiedDateTime = DateTime.Now;
                    objLeads.ModifiedBy = 1;
                    _context.Entry(objLeadsData).CurrentValues.SetValues(objLeads);

                    #region productlist update

                    foreach (var product in objLeadDto.ProductList)
                    {
                        if (product.ProductListId == 0)
                        {
                            ProductListDto objProductListDto = product;
                            ProductList objProductList = _mapper.Map<ProductList>(objProductListDto);
                            objProductList.ReferenceId = objLeadDto.LeadId;
                            objProductList.Source = 1;
                            objProductList.ProductId = product.ProductId;
                            objProductList.CreatedBy = 1;
                            objProductList.CreatedDateTime = DateTime.Now;
                            _context.ProductList.Add(objProductList);
                        }
                        else
                        {
                            ProductList objProductListdata = _context.ProductList.Find(product.ProductListId);
                            ProductListDto objProductListDto = product;
                            ProductList objProductList = _mapper.Map<ProductList>(objProductListDto);
                            objProductList.ModifiedBy = 1;
                            objProductList.ModifiedDateTime = DateTime.Now;
                            _context.Entry(objProductListdata).CurrentValues.SetValues(objProductList);
                        }
                    }
                    #endregion

                    #region activities update

                    foreach (var activities in objLeadDto.Activities)
                    {
                        if (activities.ActivityId == 0)
                        {
                            ActivitiesDto objActivitiesDto = activities;
                            Activities objActivities = _mapper.Map<Activities>(objActivitiesDto);
                            objActivities.ReferenceId = objLeadDto.LeadId;
                            objActivities.Source = 1;
                            objActivities.CreatedBy = 1;
                            objActivities.CreatedDateTime = DateTime.Now;
                            _context.Activities.Add(objActivities);
                        }
                        else
                        {
                            Activities objActivitiesdata = _context.Activities.Find(activities.ActivityId);
                            ActivitiesDto objActivitiesDto = activities;
                            Activities objActivities = _mapper.Map<Activities>(objActivitiesDto);
                            objActivities.ModifiedBy = 1;
                            objActivities.ModifiedDateTime = DateTime.Now;
                            _context.Entry(objActivitiesdata).CurrentValues.SetValues(objActivities);
                        }
                    }
                    #endregion

                    _context.SaveChanges();
                    transaction.Commit();
                    return _mapper.Map<LeadDto>(_context.Leads.
                       SingleOrDefault(x => x.LeadId == objLeadDto.LeadId));
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DeleteLead(int leadId)
        {
            Leads objLeads = _context.Leads.Find(leadId);
            objLeads.FlagActive = false;
            _context.Entry(objLeads).CurrentValues.SetValues(objLeads);

            var objProductList = _context.ProductList.Where(pl => pl.ReferenceId == leadId).ToList();
            objProductList.ForEach(pl => pl.FlagActive = false);

            var objActivities = _context.Activities.Where(x => x.ReferenceId == leadId).ToList();
            objActivities.ForEach(a => a.FlagActive = false);

            _context.SaveChanges();
        }

    }
}
