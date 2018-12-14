import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { userDto} from '../models/user-dto';
import {createUserDto} from '../models/createuser-dto';
import { usermailconfirmDto } from '../models/usermailconfirm-dto';
@Injectable({
    providedIn: 'root'
})
export class LoginService {

    constructor(private http: HttpClient) { }

    
    login(username: string, password: string) {
        return this.http.post<userDto>(`https://localhost:44373/api/user/Login`, { loginName: username, password: password })
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }

                return user;
            }));
    }
    createUser(user:createUserDto) {
        return this.http.post<userDto>(`https://localhost:44373/api/user/createuser`, user)
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }

                return user;
            }));
    }

    usermailconfirm(user:usermailconfirmDto) {
        return this.http.post(`https://localhost:44373/api/user/VerifyEmail`, user)
            .pipe(map(user => {
                          }));
    }
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}
