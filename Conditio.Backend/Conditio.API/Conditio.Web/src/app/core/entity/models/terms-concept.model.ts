export class TermsConcept implements TermsConcept {
    constructor(description: string) {
        this.description = description;
    }
}

export interface TermsConcept {
    description: string;
    period: string;
}
