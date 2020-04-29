import { TermsConcept } from '@core/entity/models/terms-concept.model';

export interface Terms {
    returns: TermsConcept[];
    refunds: TermsConcept[];
    guarantees: TermsConcept[];
    paymentMethods: TermsConcept[];
    responsibilities: TermsConcept[];
}
