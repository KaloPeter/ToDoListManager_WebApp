import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AccountService } from '../_Services/account.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    constructor(private accountService: AccountService) { }
    //Logged user makes a request that returns something fo server, then we add logged user token to header
    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        this.accountService.currentUser$.pipe(take(1)).subscribe({
            next: user => {//user can be null, we check it
                if (user) {//if user not null,we clone the request
                    request = request.clone({//clone of this request
                        setHeaders: {
                            Authorization: `Bearer ${user.token}`//Any http request gonna make thiscall-> clone the request, and send the header to the destination
                        }
                    })
                }
            }
        })




        return next.handle(request);
    }
}
