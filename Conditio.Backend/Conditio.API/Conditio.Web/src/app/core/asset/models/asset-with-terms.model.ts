import { SourceWithTerms } from './source-with-terms.model';

export class AssetWithTerms {
    id: string;
    name: string;
    category: string;
    source: SourceWithTerms;
}
