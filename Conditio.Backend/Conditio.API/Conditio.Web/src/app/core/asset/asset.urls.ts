import { Injectable, Inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AssetUrls {

  private baseUrl = 'api/assets';

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = `${baseUrl}${this.baseUrl}`;
  }

  get(id: string): string {
    return `${this.baseUrl}/${id}`;
  }

  getWithTermsByUrl(url: string): string {
    return `${this.baseUrl}?url=${url}&terms=true`;
  }

  getWithSourcesByUrl(url: string): string {
    return `${this.baseUrl}?url=${url}&terms=false`;
  }

  getBySource(id: string, sourceId: string) {
      return `${this.baseUrl}/${id}/source/${sourceId}`;
  }
}
