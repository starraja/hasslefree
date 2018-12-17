export class CreateUserDto implements ICreateUserDto {
    firstName?: string | undefined;
    lastName?: string | undefined;
    loginName?: string | undefined;
    email?: string | undefined;
    password?: string | undefined;

    constructor(data?: ICreateUserDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.firstName = data["firstName"];
            this.lastName = data["lastName"];
            this.loginName = data["loginName"];
            this.email = data["email"];
            this.password = data["password"];
        }
    }

    static fromJS(data: any): CreateUserDto {
        data = typeof data === 'object' ? data : {};
        let result = new CreateUserDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["loginName"] = this.loginName;
        data["email"] = this.email;
        data["password"] = this.password;
        return data; 
    }
}

export interface ICreateUserDto {
    firstName?: string | undefined;
    lastName?: string | undefined;
    loginName?: string | undefined;
    email?: string | undefined;
    password?: string | undefined;
}

