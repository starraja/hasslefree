import { LeadDto } from '../models/leadDto';
import {utilties} from './utilties';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable({
    providedIn: 'root',
  })
export class LeadService {
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
    getLeads(): Observable<LeadDto[]> {
        let url_ = this.baseUrl + "/api/Lead/GetLeads";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetLeads(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetLeads(<any>response_);
                } catch (e) {
                    return <Observable<LeadDto[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<LeadDto[]>><any>_observableThrow(response_);
        }));
    }

    protected processGetLeads(response: HttpResponseBase): Observable<LeadDto[]> {
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
                    result200.push(LeadDto.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<LeadDto[]>(<any>null);
    }

    /**
     * @param leadId (optional) 
     * @return Success
     */
    getLeadById(leadId: number | null | undefined): Observable<LeadDto> {
        let url_ = this.baseUrl + "/api/Lead/GetLeadById?";
        if (leadId !== undefined)
            url_ += "leadId=" + encodeURIComponent("" + leadId) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetLeadById(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetLeadById(<any>response_);
                } catch (e) {
                    return <Observable<LeadDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<LeadDto>><any>_observableThrow(response_);
        }));
    }

    protected processGetLeadById(response: HttpResponseBase): Observable<LeadDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? LeadDto.fromJS(resultData200) : new LeadDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<LeadDto>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    postLead(model: LeadDto | null | undefined): Observable<LeadDto> {
        let url_ = this.baseUrl + "/api/Lead/PostLead";
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
            return this.processPostLead(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processPostLead(<any>response_);
                } catch (e) {
                    return <Observable<LeadDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<LeadDto>><any>_observableThrow(response_);
        }));
    }

    protected processPostLead(response: HttpResponseBase): Observable<LeadDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? LeadDto.fromJS(resultData200) : new LeadDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<LeadDto>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    updateLead(model: LeadDto | null | undefined): Observable<LeadDto> {
        let url_ = this.baseUrl + "/api/Lead/UpdateLead";
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
            return this.processUpdateLead(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdateLead(<any>response_);
                } catch (e) {
                    return <Observable<LeadDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<LeadDto>><any>_observableThrow(response_);
        }));
    }

    protected processUpdateLead(response: HttpResponseBase): Observable<LeadDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? LeadDto.fromJS(resultData200) : new LeadDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<LeadDto>(<any>null);
    }

    /**
     * @param leadId (optional) 
     * @return Success
     */
    deleteLead(leadId: number | null | undefined): Observable<void> {
        let url_ = this.baseUrl + "/api/Lead/DeleteLead?";
        if (leadId !== undefined)
            url_ += "leadId=" + encodeURIComponent("" + leadId) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteLead(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteLead(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else
                return <Observable<void>><any>_observableThrow(response_);
        }));
    }

    protected processDeleteLead(response: HttpResponseBase): Observable<void> {
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