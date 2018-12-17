export class IdentityError implements IIdentityError {
    code?: string | undefined;
    description?: string | undefined;

    constructor(data?: IIdentityError) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.code = data["code"];
            this.description = data["description"];
        }
    }

    static fromJS(data: any): IdentityError {
        data = typeof data === 'object' ? data : {};
        let result = new IdentityError();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["code"] = this.code;
        data["description"] = this.description;
        return data; 
    }
}

export interface IIdentityError {
    code?: string | undefined;
    description?: string | undefined;
}