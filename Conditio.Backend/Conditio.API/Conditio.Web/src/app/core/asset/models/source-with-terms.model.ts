import { EntityWithTerms } from '@core/entity/models/entity-with-terms.model';

export class SourceWithTerms {
    url: string;
    scopes: string[];
    entity: EntityWithTerms;
}
