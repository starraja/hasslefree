
import { CreateUserDto } from '../models/createUserDto';
import { UserDto } from '../models/userDto';
import { UserMailConfirmDto } from '../models/userMailConfirmDto';
import {utilties} from './utilties';

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('');



@Injectable({
    providedIn: 'root',
  })
export class UserService {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    /**
     * @param user (optional) 
     * @return Success
     */
    login(user: CreateUserDto | null | undefined): Observable<UserDto> {
        let url_ = this.baseUrl + "/api/User/Login";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(user);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json",
                'No-Auth':'True'
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processLogin(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processLogin(<any>response_);
                } catch (e) {
                    return <Observable<UserDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<UserDto>><any>_observableThrow(response_);
        }));
    }

    protected processLogin(response: HttpResponseBase): Observable<UserDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? UserDto.fromJS(resultData200) : new UserDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<UserDto>(<any>null);
    }

    /**
     * @param user (optional) 
     * @return Success
     */
    createUser(user: CreateUserDto | null | undefined): Observable<UserDto> {
        let url_ = this.baseUrl + "/api/User/CreateUser";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(user);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json",
                'No-Auth':'True'
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreateUser(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreateUser(<any>response_);
                } catch (e) {
                    return <Observable<UserDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<UserDto>><any>_observableThrow(response_);
        }));
    }

    protected processCreateUser(response: HttpResponseBase): Observable<UserDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? UserDto.fromJS(resultData200) : new UserDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<UserDto>(<any>null);
    }

    /**
     * @param usermail (optional) 
     * @return Success
     */
    verifyEmail(usermail: UserMailConfirmDto | null | undefined): Observable<void> {
        let url_ = this.baseUrl + "/api/User/VerifyEmail";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(usermail);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                'No-Auth':'True' 
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processVerifyEmail(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processVerifyEmail(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else
                return <Observable<void>><any>_observableThrow(response_);
        }));
    }

    protected processVerifyEmail(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return _observableOf<void>(<any>null);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<void>(<any>null);
    }
    logout() {
        localStorage.removeItem('currentUser');
    }
}
