import { Injectable, Inject } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class DomainUrls {

    private baseUrl = 'api/domains';

    constructor(@Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = `${baseUrl}${this.baseUrl}`;
    }

    get(name: string): string {
        return `${this.baseUrl}/${name}`;
    }

    filter(name: string, startWith: boolean): string {
        return `${this.baseUrl}?name=${name}&startWith=${startWith}`;
    }
}
