import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpResponse, HttpHandler, HttpEvent } from '@angular/common/http';
import { of, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { CacheService } from '@core/cache/cache.service';

@Injectable({
    providedIn: 'root',
  })
export class CacheRequestsInterceptor implements HttpInterceptor {

    constructor(private cacheService: CacheService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!this.cacheService.isRequestCachable(req)) {
            return next.handle(req);
        }
        const cachedResponse = this.cacheService.get(req);
        if (cachedResponse !== null) {
            return of(cachedResponse);
        }
        return next.handle(req).pipe(
            tap(event => {
                if (event instanceof HttpResponse) {
                    this.cacheService.put(req, event);
                }
            })
        );
    }
}
