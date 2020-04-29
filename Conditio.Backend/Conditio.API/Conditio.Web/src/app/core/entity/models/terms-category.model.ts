import { TermsConcept } from '@core/entity/models/terms-concept.model';

export interface TermsCategory {
    name: string;
    concepts: TermsConcept[];
}
