
import { ActivitiesDto } from '../models/activitiesDto';
import {utilties} from './utilties';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable({
    providedIn: 'root',
  })
export class ActivityService {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    /**
     * @return Success
     */
    getActivities(): Observable<ActivitiesDto[]> {
        let url_ = this.baseUrl + "/api/Activity/GetActivities";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetActivities(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetActivities(<any>response_);
                } catch (e) {
                    return <Observable<ActivitiesDto[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<ActivitiesDto[]>><any>_observableThrow(response_);
        }));
    }

    protected processGetActivities(response: HttpResponseBase): Observable<ActivitiesDto[]> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (resultData200 && resultData200.constructor === Array) {
                result200 = [];
                for (let item of resultData200)
                    result200.push(ActivitiesDto.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<ActivitiesDto[]>(<any>null);
    }

    /**
     * @param activityId (optional) 
     * @return Success
     */
    getActivityById(activityId: number | null | undefined): Observable<ActivitiesDto> {
        let url_ = this.baseUrl + "/api/Activity/GetActivityById?";
        if (activityId !== undefined)
            url_ += "activityId=" + encodeURIComponent("" + activityId) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetActivityById(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetActivityById(<any>response_);
                } catch (e) {
                    return <Observable<ActivitiesDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<ActivitiesDto>><any>_observableThrow(response_);
        }));
    }

    protected processGetActivityById(response: HttpResponseBase): Observable<ActivitiesDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? ActivitiesDto.fromJS(resultData200) : new ActivitiesDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<ActivitiesDto>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    postActivity(model: ActivitiesDto | null | undefined): Observable<ActivitiesDto> {
        let url_ = this.baseUrl + "/api/Activity/PostActivity";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(model);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processPostActivity(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processPostActivity(<any>response_);
                } catch (e) {
                    return <Observable<ActivitiesDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<ActivitiesDto>><any>_observableThrow(response_);
        }));
    }

    protected processPostActivity(response: HttpResponseBase): Observable<ActivitiesDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? ActivitiesDto.fromJS(resultData200) : new ActivitiesDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<ActivitiesDto>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    updateActivity(model: ActivitiesDto | null | undefined): Observable<ActivitiesDto> {
        let url_ = this.baseUrl + "/api/Activity/UpdateActivity";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(model);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdateActivity(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdateActivity(<any>response_);
                } catch (e) {
                    return <Observable<ActivitiesDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<ActivitiesDto>><any>_observableThrow(response_);
        }));
    }

    protected processUpdateActivity(response: HttpResponseBase): Observable<ActivitiesDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? ActivitiesDto.fromJS(resultData200) : new ActivitiesDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<ActivitiesDto>(<any>null);
    }

    /**
     * @param activityId (optional) 
     * @return Success
     */
    deleteActivity(activityId: number | null | undefined): Observable<void> {
        let url_ = this.baseUrl + "/api/Activity/DeleteActivity?";
        if (activityId !== undefined)
            url_ += "activityId=" + encodeURIComponent("" + activityId) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteActivity(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteActivity(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else
                return <Observable<void>><any>_observableThrow(response_);
        }));
    }

    protected processDeleteActivity(response: HttpResponseBase): Observable<void> {
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
}
