
export class LeadDto implements ILeadDto {
    leadId?: number | undefined;
    description?: string | undefined;
    salutation?: number | undefined;
    leadFirstName?: string | undefined;
    leadLastName?: string | undefined;
    leadDate?: Date | undefined;
    email?: string | undefined;
    salesStage?: number | undefined;
    leadOwnerExecutiveId?: number | undefined;
    workPhone?: string | undefined;
    mobilePhone?: string | undefined;
    addressLine1?: string | undefined;
    addressLine2?: string | undefined;
    addressLine3?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
    country?: number | undefined;
    companyName?: string | undefined;
    companyAddressLine1?: string | undefined;
    companyAddressLine2?: string | undefined;
    companyAddressLine3?: string | undefined;
    companyCity?: string | undefined;
    companyState?: string | undefined;
    companyPostalCode?: string | undefined;
    companyCountry?: number | undefined;
    companyWebsite?: string | undefined;
    companyTurnover?: string | undefined;
    industryId?: number | undefined;
    industrySubTypeId?: number | undefined;
    leadSource?: number | undefined;
    detailDescription?: string | undefined;
    contactId?: number | undefined;
    opportunityId?: number | undefined;
    accountId?: number | undefined;
    converted?: boolean | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;

    constructor(data?: ILeadDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.leadId = data["leadId"];
            this.description = data["description"];
            this.salutation = data["salutation"];
            this.leadFirstName = data["leadFirstName"];
            this.leadLastName = data["leadLastName"];
            this.leadDate = data["leadDate"] ? new Date(data["leadDate"].toString()) : <any>undefined;
            this.email = data["email"];
            this.salesStage = data["salesStage"];
            this.leadOwnerExecutiveId = data["leadOwnerExecutiveId"];
            this.workPhone = data["workPhone"];
            this.mobilePhone = data["mobilePhone"];
            this.addressLine1 = data["addressLine1"];
            this.addressLine2 = data["addressLine2"];
            this.addressLine3 = data["addressLine3"];
            this.city = data["city"];
            this.state = data["state"];
            this.postalCode = data["postalCode"];
            this.country = data["country"];
            this.companyName = data["companyName"];
            this.companyAddressLine1 = data["companyAddressLine1"];
            this.companyAddressLine2 = data["companyAddressLine2"];
            this.companyAddressLine3 = data["companyAddressLine3"];
            this.companyCity = data["companyCity"];
            this.companyState = data["companyState"];
            this.companyPostalCode = data["companyPostalCode"];
            this.companyCountry = data["companyCountry"];
            this.companyWebsite = data["companyWebsite"];
            this.companyTurnover = data["companyTurnover"];
            this.industryId = data["industryId"];
            this.industrySubTypeId = data["industrySubTypeId"];
            this.leadSource = data["leadSource"];
            this.detailDescription = data["detailDescription"];
            this.contactId = data["contactId"];
            this.opportunityId = data["opportunityId"];
            this.accountId = data["accountId"];
            this.converted = data["converted"];
            this.flagActive = data["flagActive"];
            this.createdBy = data["createdBy"];
            this.createdDateTime = data["createdDateTime"] ? new Date(data["createdDateTime"].toString()) : <any>undefined;
            this.modifiedBy = data["modifiedBy"];
            this.modifiedDateTime = data["modifiedDateTime"] ? new Date(data["modifiedDateTime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): LeadDto {
        data = typeof data === 'object' ? data : {};
        let result = new LeadDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["leadId"] = this.leadId;
        data["description"] = this.description;
        data["salutation"] = this.salutation;
        data["leadFirstName"] = this.leadFirstName;
        data["leadLastName"] = this.leadLastName;
        data["leadDate"] = this.leadDate ? this.leadDate.toISOString() : <any>undefined;
        data["email"] = this.email;
        data["salesStage"] = this.salesStage;
        data["leadOwnerExecutiveId"] = this.leadOwnerExecutiveId;
        data["workPhone"] = this.workPhone;
        data["mobilePhone"] = this.mobilePhone;
        data["addressLine1"] = this.addressLine1;
        data["addressLine2"] = this.addressLine2;
        data["addressLine3"] = this.addressLine3;
        data["city"] = this.city;
        data["state"] = this.state;
        data["postalCode"] = this.postalCode;
        data["country"] = this.country;
        data["companyName"] = this.companyName;
        data["companyAddressLine1"] = this.companyAddressLine1;
        data["companyAddressLine2"] = this.companyAddressLine2;
        data["companyAddressLine3"] = this.companyAddressLine3;
        data["companyCity"] = this.companyCity;
        data["companyState"] = this.companyState;
        data["companyPostalCode"] = this.companyPostalCode;
        data["companyCountry"] = this.companyCountry;
        data["companyWebsite"] = this.companyWebsite;
        data["companyTurnover"] = this.companyTurnover;
        data["industryId"] = this.industryId;
        data["industrySubTypeId"] = this.industrySubTypeId;
        data["leadSource"] = this.leadSource;
        data["detailDescription"] = this.detailDescription;
        data["contactId"] = this.contactId;
        data["opportunityId"] = this.opportunityId;
        data["accountId"] = this.accountId;
        data["converted"] = this.converted;
        data["flagActive"] = this.flagActive;
        data["createdBy"] = this.createdBy;
        data["createdDateTime"] = this.createdDateTime ? this.createdDateTime.toISOString() : <any>undefined;
        data["modifiedBy"] = this.modifiedBy;
        data["modifiedDateTime"] = this.modifiedDateTime ? this.modifiedDateTime.toISOString() : <any>undefined;
        return data; 
    }
}

export interface ILeadDto {
    leadId?: number | undefined;
    description?: string | undefined;
    salutation?: number | undefined;
    leadFirstName?: string | undefined;
    leadLastName?: string | undefined;
    leadDate?: Date | undefined;
    email?: string | undefined;
    salesStage?: number | undefined;
    leadOwnerExecutiveId?: number | undefined;
    workPhone?: string | undefined;
    mobilePhone?: string | undefined;
    addressLine1?: string | undefined;
    addressLine2?: string | undefined;
    addressLine3?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
    country?: number | undefined;
    companyName?: string | undefined;
    companyAddressLine1?: string | undefined;
    companyAddressLine2?: string | undefined;
    companyAddressLine3?: string | undefined;
    companyCity?: string | undefined;
    companyState?: string | undefined;
    companyPostalCode?: string | undefined;
    companyCountry?: number | undefined;
    companyWebsite?: string | undefined;
    companyTurnover?: string | undefined;
    industryId?: number | undefined;
    industrySubTypeId?: number | undefined;
    leadSource?: number | undefined;
    detailDescription?: string | undefined;
    contactId?: number | undefined;
    opportunityId?: number | undefined;
    accountId?: number | undefined;
    converted?: boolean | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;
}
