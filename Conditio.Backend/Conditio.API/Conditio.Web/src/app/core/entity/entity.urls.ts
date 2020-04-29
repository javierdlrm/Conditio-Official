import { Injectable, Inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EntityUrls {

  private baseUrl = 'api/entities';

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = `${baseUrl}${this.baseUrl}`;
  }

  get(id: string): string {
    return `${this.baseUrl}/${id}`;
  }

  getWithTerms(id: string): string {
    return `${this.baseUrl}/${id}?terms=true`;
  }

  getByDomain(domain: string): string {
    return `${this.baseUrl}?domain=${domain}`;
  }

  getWithTermsByDomain(domain: string): string {
    return `${this.baseUrl}?domain=${domain}&terms=true`;
  }
}
