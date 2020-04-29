import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AssetUrls } from '@core/asset/asset.urls';
import { AssetWithSources } from '@core/asset/models/asset-with-sources.model';
import { AssetWithTerms } from '@core/asset/models/asset-with-terms.model';

@Injectable({
  providedIn: 'root',
})
export class AssetService {

  constructor(private http: HttpClient, private urls: AssetUrls) { }

  get(id: string): Observable<AssetWithSources> {
    return this.http.get<AssetWithSources>(this.urls.get(id));
  }

  getWithTermsByUrl(url: string): Observable<AssetWithTerms> {
    return this.http.get<AssetWithTerms>(this.urls.getWithTermsByUrl(url));
  }

  getWithSourcesByUrl(url: string): Observable<AssetWithSources> {
      return this.http.get<AssetWithSources>(this.urls.getWithSourcesByUrl(url));
  }

  getBySource(id: string, sourceId: string): Observable<AssetWithTerms> {
      return this.http.get<AssetWithTerms>(this.urls.getBySource(id, sourceId));
  }
}
