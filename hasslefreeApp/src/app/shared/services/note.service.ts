

import { NotesDto } from '../models/notesDto';
import {utilties} from './utilties';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable({
    providedIn: 'root',
  })
export class NoteService {
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
    getNotes(): Observable<NotesDto[]> {
        let url_ = this.baseUrl + "/api/Note/GetNotes";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetNotes(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetNotes(<any>response_);
                } catch (e) {
                    return <Observable<NotesDto[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<NotesDto[]>><any>_observableThrow(response_);
        }));
    }

    protected processGetNotes(response: HttpResponseBase): Observable<NotesDto[]> {
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
                    result200.push(NotesDto.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<NotesDto[]>(<any>null);
    }

    /**
     * @param noteId (optional) 
     * @return Success
     */
    getNoteById(noteId: number | null | undefined): Observable<NotesDto> {
        let url_ = this.baseUrl + "/api/Note/GetNoteById?";
        if (noteId !== undefined)
            url_ += "noteId=" + encodeURIComponent("" + noteId) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetNoteById(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetNoteById(<any>response_);
                } catch (e) {
                    return <Observable<NotesDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<NotesDto>><any>_observableThrow(response_);
        }));
    }

    protected processGetNoteById(response: HttpResponseBase): Observable<NotesDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? NotesDto.fromJS(resultData200) : new NotesDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<NotesDto>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    postNote(model: NotesDto | null | undefined): Observable<NotesDto> {
        let url_ = this.baseUrl + "/api/Note/PostNote";
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
            return this.processPostNote(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processPostNote(<any>response_);
                } catch (e) {
                    return <Observable<NotesDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<NotesDto>><any>_observableThrow(response_);
        }));
    }

    protected processPostNote(response: HttpResponseBase): Observable<NotesDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? NotesDto.fromJS(resultData200) : new NotesDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<NotesDto>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    updateNote(model: NotesDto | null | undefined): Observable<NotesDto> {
        let url_ = this.baseUrl + "/api/Note/UpdateNote";
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
            return this.processUpdateNote(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdateNote(<any>response_);
                } catch (e) {
                    return <Observable<NotesDto>><any>_observableThrow(e);
                }
            } else
                return <Observable<NotesDto>><any>_observableThrow(response_);
        }));
    }

    protected processUpdateNote(response: HttpResponseBase): Observable<NotesDto> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 ? NotesDto.fromJS(resultData200) : new NotesDto();
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return utilties.blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return utilties.throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<NotesDto>(<any>null);
    }

    /**
     * @param noteId (optional) 
     * @return Success
     */
    deleteNote(noteId: number | null | undefined): Observable<void> {
        let url_ = this.baseUrl + "/api/Note/DeleteNote?";
        if (noteId !== undefined)
            url_ += "noteId=" + encodeURIComponent("" + noteId) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteNote(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteNote(<any>response_);
                } catch (e) {
                    return <Observable<void>><any>_observableThrow(e);
                }
            } else
                return <Observable<void>><any>_observableThrow(response_);
        }));
    }

    protected processDeleteNote(response: HttpResponseBase): Observable<void> {
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