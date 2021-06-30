import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((response) => {
        if (response.status === 400) {
          this.toastr.error(response.error.message, response.error.statusCode);
        }
        if (response.status === 404) {
          this.router.navigateByUrl('/not-found');
        }
        if (response.status === 500) {
          const navigationExtras: NavigationExtras = {
            state: { error: response.error },
          };
          this.router.navigateByUrl('/internal-server-error', navigationExtras);
        }
        return throwError(response);
      })
    );
  }
}
