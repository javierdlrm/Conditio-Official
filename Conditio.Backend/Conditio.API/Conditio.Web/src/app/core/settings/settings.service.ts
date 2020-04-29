import { Injectable, Inject } from '@angular/core';
import { SPASettings } from './spa-settings.model';
import { APISettings } from './api-settings.model';
import { Bootable } from '@core/bootstrapper/bootable';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root',
})
export class SettingsService implements Bootable {

    private endpoint = 'api/settings';

    spa: SPASettings;
    api: APISettings;

    constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
        this.endpoint = `${baseUrl}${this.endpoint}`;
    }

    async init(): Promise<void> {
        this.api = await this.http.get<APISettings>(this.endpoint).toPromise();
    }
}
