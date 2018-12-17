import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/do';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  handleError(err)
  {
    if (err.error instanceof Error) {
        // A client-side or network error occurred. Handle it accordingly.
        console.error('An error occurred:', err.error.message);
      } else {
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong,
        console.error('Backend returned code ${err.status}, body was: ${err.error}');
      }
  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
   
    if(request.headers.get('No-Auth') == "True"){
        return next.handle(request.clone()).do((event: HttpEvent<any>) => {}, (err: any) => {
            this.handleError(err);
          });
    }

    if(localStorage.getItem('userToken') != null) {
        return next.handle(
            request.clone(
                { headers: request.headers.set("Authorization", "Bearer " + localStorage.getItem('userToken'))}
            )
        ).do((event: HttpEvent<any>) => {}, (err: any) => {
            this.handleError(err);
          });
    }
    else{
        this.router.navigateByUrl('/login');
    }

  }
}


