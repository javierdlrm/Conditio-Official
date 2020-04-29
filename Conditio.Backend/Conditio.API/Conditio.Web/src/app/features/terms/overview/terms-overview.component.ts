import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd, Event } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { StateService } from '@core/state/state.service';
import { TermsSearchQuery } from '@core/components/terms-search-form/terms-search-query.model';
import { DomainService } from '@core/domain/domain.service';
import { AssetService } from '@core/asset/asset.service';
import { EntityService } from '@core/entity/entity.service';
import { Terms } from '@core/entity/models/terms.model';
import { Source } from '@core/asset/models/source.model';
import { TaskService } from '@core/state/task.service';
import { Destroyable } from '@core/utils/destroyable';
import { TermsConcept } from '@core/entity/models/terms-concept.model';
import { TermsCategory } from '@core/entity/models/terms-category.model';

@Component({
  selector: 'terms-overview',
  templateUrl: './terms-overview.component.html',
  styleUrls: ['./terms-overview.component.scss'],
})
export class TermsOverviewComponent extends Destroyable implements OnInit {

  query: TermsSearchQuery;
  subject: { name: string, category: string, source?: Source };

  layout: 'summary' | 'detail' = 'summary';
  terms: TermsCategory[];
  termsCategory: TermsCategory;

  constructor(private stateService: StateService, private domainService: DomainService, private entityService: EntityService, private assetService: AssetService,
    private taskService: TaskService, private route: ActivatedRoute, private router: Router) {
    super();
    this.stateService.termsQuery$.pipe(takeUntil(this.destroy$)).subscribe((query: TermsSearchQuery) => { this.queryChanged(query); });
    this.router.events.pipe(takeUntil(this.destroy$)).subscribe((event: Event) => { if (event instanceof NavigationEnd) { this.navigationEnd(); } });
  }

  async ngOnInit(): Promise<void> {
    await this.taskService.monitor(async () => { await this.init(); });
  }

  async init(): Promise<void> {
    await this.checkDirectAccess(); // Check access through url
    await this.getTerms(); // Load terms
  }

  navigationEnd(): void {
    this.query = this.subject = undefined; // Clear query and subject
    this.ngOnInit();
  }

  async queryChanged(query: TermsSearchQuery): Promise<void> {
    this.query = query;
    await this.taskService.monitor(async () => { await this.getTerms(); });
  }

  async checkDirectAccess(): Promise<void> {
    if (this.query) { return; }

    let queryParam = this.route.snapshot.queryParamMap.get('url');
    if (!queryParam) { queryParam = this.route.snapshot.queryParamMap.get('domain'); }
    if (this.domainService.isUrl(queryParam)) {
      this.query = TermsSearchQuery.fromUrl(queryParam);
    } else if (this.domainService.isDomain(queryParam)) {
      const domain = await this.domainService.get(queryParam).toPromise();
      this.query = TermsSearchQuery.fromDomain(domain);
    } else {
      // TODO: Redirect to NOT FOUND page.
      console.error('QUERY PARAM - DOMAIN - NOT FOUND');
    }
  }

  async getTerms(): Promise<void> {
    if (!this.query) { return; }

    if (this.query.isDomain) {
      const entityWithTerms = await this.entityService.getWithTermsByDomain(this.query.name).toPromise();
      this.subject = { name: entityWithTerms.name, category: entityWithTerms.category };
      this.terms = this.getTermsCategories(entityWithTerms.terms);
    } else {
      const url = this.domainService.removeSchema(this.query.name);
      const assetWithTerms = await this.assetService.getWithTermsByUrl(url).toPromise();
      this.subject = { name: assetWithTerms.name, category: assetWithTerms.category, source: assetWithTerms.source };
      this.terms = this.getTermsCategories(assetWithTerms.source.entity.terms);
    }
  }

  getTermsCategories(terms: Terms): TermsCategory[] {
    const categories: TermsCategory[] = [];
    for (const name of Object.keys(terms)) {
      const concepts: TermsConcept[] = terms[name];
      categories.push({ name, concepts: concepts as TermsConcept[] });
    }
    return categories;
  }

  //#region Detail

  categorySelected(category: TermsCategory): void {

    if (this.termsCategory !== undefined) {
      this.terms.push(this.termsCategory);
    }

    const idx = this.terms.indexOf(category);
    this.terms.splice(idx, 1);
    this.terms = [...this.terms];
    this.termsCategory = category;
    this.layout = 'detail';
  }

  closeDetail(): void {
    this.terms.push(this.termsCategory);
    this.terms = [...this.terms];
    this.termsCategory = undefined;
    this.layout = 'summary';
  }

  //#endregion
}
