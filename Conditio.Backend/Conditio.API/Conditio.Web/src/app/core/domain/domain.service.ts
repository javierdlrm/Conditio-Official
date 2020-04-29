import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Domain } from '@core/domain/domain.model';
import { DomainUrls } from '@core/domain/domain.urls';

@Injectable({
  providedIn: 'root',
})
export class DomainService {

  // tslint:disable-next-line:max-line-length
  private reUrl = /^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z0-9\u00a1-\uffff][a-z0-9\u00a1-\uffff_-]{0,62})?[a-z0-9\u00a1-\uffff]\.)+(?:[a-z\u00a1-\uffff]{2,}\.?))(?::\d{2,5})?(?:[/?#]\S*)?$/i;
  private reDomain = /[a-zA-Z0-9][a-zA-Z0-9-]{1,61}[a-zA-Z0-9](?:\.[a-zA-Z]{2,})+/;

  constructor(private http: HttpClient, private urls: DomainUrls) { }

  get(name: string): Observable<Domain> {
    return this.http.get<Domain>(this.urls.get(name));
  }

  filter(name: string, startWith: boolean): Observable<Domain[]> {
    return this.http.get<Domain[]>(this.urls.filter(name, startWith));
  }

  // Utils

  isUrl(query: string): boolean {
    return this.reUrl.test(query);
  }

  isDomain(query: string): boolean {
    return !query.includes('/') && this.reDomain.test(query);
  }

  removeSchema(query: string): string {
    const idx = query.search(this.reDomain);
    return idx < 0 ? query : query.substr(idx);
  }

  extractDomain(query: string): string {
    return query.match(this.reDomain)[0];
  }
}
