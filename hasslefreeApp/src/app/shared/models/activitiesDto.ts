export class ActivitiesDto implements IActivitiesDto {
    activityId?: number | undefined;
    activityTypeId?: number | undefined;
    activitySubTypeId?: number | undefined;
    activityTitle?: string | undefined;
    activityStartTime?: Date | undefined;
    activityEndTime?: Date | undefined;
    activityLocation?: string | undefined;
    statusId?: number | undefined;
    activityOwner?: number | undefined;
    source?: number | undefined;
    referenceId?: number | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;

    constructor(data?: IActivitiesDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.activityId = data["activityId"];
            this.activityTypeId = data["activityTypeId"];
            this.activitySubTypeId = data["activitySubTypeId"];
            this.activityTitle = data["activityTitle"];
            this.activityStartTime = data["activityStartTime"] ? new Date(data["activityStartTime"].toString()) : <any>undefined;
            this.activityEndTime = data["activityEndTime"] ? new Date(data["activityEndTime"].toString()) : <any>undefined;
            this.activityLocation = data["activityLocation"];
            this.statusId = data["statusId"];
            this.activityOwner = data["activityOwner"];
            this.source = data["source"];
            this.referenceId = data["referenceId"];
            this.flagActive = data["flagActive"];
            this.createdBy = data["createdBy"];
            this.createdDateTime = data["createdDateTime"] ? new Date(data["createdDateTime"].toString()) : <any>undefined;
            this.modifiedBy = data["modifiedBy"];
            this.modifiedDateTime = data["modifiedDateTime"] ? new Date(data["modifiedDateTime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): ActivitiesDto {
        data = typeof data === 'object' ? data : {};
        let result = new ActivitiesDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["activityId"] = this.activityId;
        data["activityTypeId"] = this.activityTypeId;
        data["activitySubTypeId"] = this.activitySubTypeId;
        data["activityTitle"] = this.activityTitle;
        data["activityStartTime"] = this.activityStartTime ? this.activityStartTime.toISOString() : <any>undefined;
        data["activityEndTime"] = this.activityEndTime ? this.activityEndTime.toISOString() : <any>undefined;
        data["activityLocation"] = this.activityLocation;
        data["statusId"] = this.statusId;
        data["activityOwner"] = this.activityOwner;
        data["source"] = this.source;
        data["referenceId"] = this.referenceId;
        data["flagActive"] = this.flagActive;
        data["createdBy"] = this.createdBy;
        data["createdDateTime"] = this.createdDateTime ? this.createdDateTime.toISOString() : <any>undefined;
        data["modifiedBy"] = this.modifiedBy;
        data["modifiedDateTime"] = this.modifiedDateTime ? this.modifiedDateTime.toISOString() : <any>undefined;
        return data; 
    }
}

export interface IActivitiesDto {
    activityId?: number | undefined;
    activityTypeId?: number | undefined;
    activitySubTypeId?: number | undefined;
    activityTitle?: string | undefined;
    activityStartTime?: Date | undefined;
    activityEndTime?: Date | undefined;
    activityLocation?: string | undefined;
    statusId?: number | undefined;
    activityOwner?: number | undefined;
    source?: number | undefined;
    referenceId?: number | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;
}