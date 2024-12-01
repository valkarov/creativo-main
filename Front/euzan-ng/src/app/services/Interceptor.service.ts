import {
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class MyHttpInterceptor implements HttpInterceptor {
    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        // Do something with the request here
        request = request.clone({
            setHeaders: {
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            },
        });

        return next.handle(request);
    }
}
