import { Source } from '@core/asset/models/source.model';

export class AssetWithSources {
  id: string;
  name: string;
  category: string;
  sources: Source[];
}
