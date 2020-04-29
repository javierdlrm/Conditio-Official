import { Entity } from '@core/entity/models/entity.model';
import { Terms } from '@core/entity/models/terms.model';

export interface EntityWithTerms extends Entity {
    terms: Terms;
}
