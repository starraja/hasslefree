
import { IdentityError } from './identityError';

export class UserDto implements IUserDto {
    id?: number | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    userName?: string | undefined;
    token?: string | undefined;
    identityError?: IdentityError[] | undefined;
    signInErrors?: string[] | undefined;

    constructor(data?: IUserDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.firstName = data["firstName"];
            this.lastName = data["lastName"];
            this.userName = data["userName"];
            this.token = data["token"];
            if (data["identityError"] && data["identityError"].constructor === Array) {
                this.identityError = [];
                for (let item of data["identityError"])
                    this.identityError.push(IdentityError.fromJS(item));
            }
            if (data["signInErrors"] && data["signInErrors"].constructor === Array) {
                this.signInErrors = [];
                for (let item of data["signInErrors"])
                    this.signInErrors.push(item);
            }
        }
    }

    static fromJS(data: any): UserDto {
        data = typeof data === 'object' ? data : {};
        let result = new UserDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["userName"] = this.userName;
        data["token"] = this.token;
        if (this.identityError && this.identityError.constructor === Array) {
            data["identityError"] = [];
            for (let item of this.identityError)
                data["identityError"].push(item.toJSON());
        }
        if (this.signInErrors && this.signInErrors.constructor === Array) {
            data["signInErrors"] = [];
            for (let item of this.signInErrors)
                data["signInErrors"].push(item);
        }
        return data; 
    }
}

export interface IUserDto {
    id?: number | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    userName?: string | undefined;
    token?: string | undefined;
    identityError?: IdentityError[] | undefined;
    signInErrors?: string[] | undefined;
}
