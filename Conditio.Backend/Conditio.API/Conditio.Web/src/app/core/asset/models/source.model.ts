import { Entity } from '@core/entity/models/entity.model';

export interface Source {
    url: string;
    scopes: string[];
    entity: Entity;
}
