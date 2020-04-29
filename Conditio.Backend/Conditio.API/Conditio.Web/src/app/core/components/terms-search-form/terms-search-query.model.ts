import { Domain } from '@core/domain/domain.model';

export class TermsSearchQuery {

    entityId: string;
    name: string;
    isDomain: boolean;

    private constructor() { }

    static fromUrl(url: string) {
        const query = new this();
        query.name = url;
        query.isDomain = false;
        return query;
    }

    static fromDomain(domain: Domain) {
        const query = new this();
        query.name = domain.name;
        query.entityId = domain.entityId;
        query.isDomain = true;
        return query;
    }
}
