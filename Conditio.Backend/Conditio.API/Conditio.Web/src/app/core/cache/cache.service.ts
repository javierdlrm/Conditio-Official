import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse } from '@angular/common/http';
import { Cache } from './cache';
import { CacheEntry } from '@core/cache/cache';
import { MAX_CACHE_AGE, CACHABLE_URLS } from '@core/cache/cache-settings';

@Injectable({
    providedIn: 'root',
})
export class CacheService implements Cache {

    private cacheMap = new Map<string, CacheEntry>();

    get(req: HttpRequest<any>): HttpResponse<any> | null {
        const entry = this.cacheMap.get(req.urlWithParams);
        if (!entry) {
            return null;
        }
        const isExpired = (Date.now() - entry.entryTime) > MAX_CACHE_AGE;
        return isExpired ? null : entry.response;
    }
    put(req: HttpRequest<any>, res: HttpResponse<any>): void {
        const entry: CacheEntry = { url: req.urlWithParams, response: res, entryTime: Date.now() };
        this.cacheMap.set(req.urlWithParams, entry);
        this.deleteExpiredCache();
    }
    private deleteExpiredCache() {
        this.cacheMap.forEach(entry => {
            if ((Date.now() - entry.entryTime) > MAX_CACHE_AGE) {
                this.cacheMap.delete(entry.url);
            }
        });
    }

    isRequestCachable(req: HttpRequest<any>) {
        return (req.method === 'GET') && (CACHABLE_URLS.some(u => req.url.indexOf(u) > -1));
    }
}
