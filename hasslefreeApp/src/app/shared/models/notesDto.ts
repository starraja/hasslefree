export class NotesDto implements INotesDto {
    notesId?: number | undefined;
    activityId?: number | undefined;
    notes1?: string | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;

    constructor(data?: INotesDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.notesId = data["notesId"];
            this.activityId = data["activityId"];
            this.notes1 = data["notes1"];
            this.flagActive = data["flagActive"];
            this.createdBy = data["createdBy"];
            this.createdDateTime = data["createdDateTime"] ? new Date(data["createdDateTime"].toString()) : <any>undefined;
            this.modifiedBy = data["modifiedBy"];
            this.modifiedDateTime = data["modifiedDateTime"] ? new Date(data["modifiedDateTime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): NotesDto {
        data = typeof data === 'object' ? data : {};
        let result = new NotesDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["notesId"] = this.notesId;
        data["activityId"] = this.activityId;
        data["notes1"] = this.notes1;
        data["flagActive"] = this.flagActive;
        data["createdBy"] = this.createdBy;
        data["createdDateTime"] = this.createdDateTime ? this.createdDateTime.toISOString() : <any>undefined;
        data["modifiedBy"] = this.modifiedBy;
        data["modifiedDateTime"] = this.modifiedDateTime ? this.modifiedDateTime.toISOString() : <any>undefined;
        return data; 
    }
}

export interface INotesDto {
    notesId?: number | undefined;
    activityId?: number | undefined;
    notes1?: string | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;
}