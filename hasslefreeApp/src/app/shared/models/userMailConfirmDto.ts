export class UserMailConfirmDto implements IUserMailConfirmDto {
    userName?: string | undefined;
    email?: string | undefined;
    token?: string | undefined;

    constructor(data?: IUserMailConfirmDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.userName = data["userName"];
            this.email = data["email"];
            this.token = data["token"];
        }
    }

    static fromJS(data: any): UserMailConfirmDto {
        data = typeof data === 'object' ? data : {};
        let result = new UserMailConfirmDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["userName"] = this.userName;
        data["email"] = this.email;
        data["token"] = this.token;
        return data; 
    }
}

export interface IUserMailConfirmDto {
    userName?: string | undefined;
    email?: string | undefined;
    token?: string | undefined;
}
