
export class ContactsDto implements IContactsDto {
    contactId?: number | undefined;
    accountId?: number | undefined;
    contactFirstName?: string | undefined;
    contactLastName?: string | undefined;
    genderId?: number | undefined;
    designation?: string | undefined;
    department?: string | undefined;
    addressLine1?: string | undefined;
    addressLine2?: string | undefined;
    addressLine3?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
    country?: number | undefined;
    email?: string | undefined;
    workPhone?: string | undefined;
    mobilePhone?: string | undefined;
    facebook?: string | undefined;
    twitter?: string | undefined;
    googlePlus?: string | undefined;
    dateOfBirth?: Date | undefined;
    contactTypeId?: number | undefined;
    campaignId?: number | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;

    constructor(data?: IContactsDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.contactId = data["contactId"];
            this.accountId = data["accountId"];
            this.contactFirstName = data["contactFirstName"];
            this.contactLastName = data["contactLastName"];
            this.genderId = data["genderId"];
            this.designation = data["designation"];
            this.department = data["department"];
            this.addressLine1 = data["addressLine1"];
            this.addressLine2 = data["addressLine2"];
            this.addressLine3 = data["addressLine3"];
            this.city = data["city"];
            this.state = data["state"];
            this.postalCode = data["postalCode"];
            this.country = data["country"];
            this.email = data["email"];
            this.workPhone = data["workPhone"];
            this.mobilePhone = data["mobilePhone"];
            this.facebook = data["facebook"];
            this.twitter = data["twitter"];
            this.googlePlus = data["googlePlus"];
            this.dateOfBirth = data["dateOfBirth"] ? new Date(data["dateOfBirth"].toString()) : <any>undefined;
            this.contactTypeId = data["contactTypeId"];
            this.campaignId = data["campaignId"];
            this.flagActive = data["flagActive"];
            this.createdBy = data["createdBy"];
            this.createdDateTime = data["createdDateTime"] ? new Date(data["createdDateTime"].toString()) : <any>undefined;
            this.modifiedBy = data["modifiedBy"];
            this.modifiedDateTime = data["modifiedDateTime"] ? new Date(data["modifiedDateTime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): ContactsDto {
        data = typeof data === 'object' ? data : {};
        let result = new ContactsDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["contactId"] = this.contactId;
        data["accountId"] = this.accountId;
        data["contactFirstName"] = this.contactFirstName;
        data["contactLastName"] = this.contactLastName;
        data["genderId"] = this.genderId;
        data["designation"] = this.designation;
        data["department"] = this.department;
        data["addressLine1"] = this.addressLine1;
        data["addressLine2"] = this.addressLine2;
        data["addressLine3"] = this.addressLine3;
        data["city"] = this.city;
        data["state"] = this.state;
        data["postalCode"] = this.postalCode;
        data["country"] = this.country;
        data["email"] = this.email;
        data["workPhone"] = this.workPhone;
        data["mobilePhone"] = this.mobilePhone;
        data["facebook"] = this.facebook;
        data["twitter"] = this.twitter;
        data["googlePlus"] = this.googlePlus;
        data["dateOfBirth"] = this.dateOfBirth ? this.dateOfBirth.toISOString() : <any>undefined;
        data["contactTypeId"] = this.contactTypeId;
        data["campaignId"] = this.campaignId;
        data["flagActive"] = this.flagActive;
        data["createdBy"] = this.createdBy;
        data["createdDateTime"] = this.createdDateTime ? this.createdDateTime.toISOString() : <any>undefined;
        data["modifiedBy"] = this.modifiedBy;
        data["modifiedDateTime"] = this.modifiedDateTime ? this.modifiedDateTime.toISOString() : <any>undefined;
        return data; 
    }
}

export interface IContactsDto {
    contactId?: number | undefined;
    accountId?: number | undefined;
    contactFirstName?: string | undefined;
    contactLastName?: string | undefined;
    genderId?: number | undefined;
    designation?: string | undefined;
    department?: string | undefined;
    addressLine1?: string | undefined;
    addressLine2?: string | undefined;
    addressLine3?: string | undefined;
    city?: string | undefined;
    state?: string | undefined;
    postalCode?: string | undefined;
    country?: number | undefined;
    email?: string | undefined;
    workPhone?: string | undefined;
    mobilePhone?: string | undefined;
    facebook?: string | undefined;
    twitter?: string | undefined;
    googlePlus?: string | undefined;
    dateOfBirth?: Date | undefined;
    contactTypeId?: number | undefined;
    campaignId?: number | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;
}
