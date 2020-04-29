import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Entity } from '@core/entity/models/entity.model';
import { EntityUrls } from '@core/entity/entity.urls';
import { EntityWithTerms } from './models/entity-with-terms.model';

@Injectable({
  providedIn: 'root',
})
export class EntityService {

  constructor(private http: HttpClient, private urls: EntityUrls) { }

  get(id: string): Observable<Entity> {
    return this.http.get<Entity>(this.urls.get(id));
  }

  getWithTerms(id: string): Observable<EntityWithTerms> {
    return this.http.get<EntityWithTerms>(this.urls.getWithTerms(id));
  }

  getByDomain(domain: string): Observable<Entity> {
    return this.http.get<Entity>(this.urls.getByDomain(domain));
  }

  getWithTermsByDomain(domain: string): Observable<EntityWithTerms> {
    return this.http.get<EntityWithTerms>(this.urls.getWithTermsByDomain(domain));
  }
}
