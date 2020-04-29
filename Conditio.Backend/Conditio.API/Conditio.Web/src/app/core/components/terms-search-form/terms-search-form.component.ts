import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, tap, switchMap, filter } from 'rxjs/operators';
import { DomainService } from '@core/domain/domain.service';
import { StateService } from '@core/state/state.service';
import { TermsSearchQuery } from '@core/components/terms-search-form/terms-search-query.model';
import { TaskService } from '@core/state/task.service';

@Component({
  selector: 'core-terms-search-form',
  templateUrl: './terms-search-form.component.html',
  styleUrls: ['./terms-search-form.component.scss'],
})
export class TermsSearchFormComponent {

  @Input() label: boolean;
  @Input() navigate = true;
  @Input() comparison = false;

  @Output() submit = new EventEmitter<TermsSearchQuery>();
  @Output() compare = new EventEmitter<TermsSearchQuery>();

  searching: boolean;
  searchFailed: boolean;
  selectedQuery: TermsSearchQuery;

  constructor(private stateService: StateService, private domainService: DomainService, private taskService: TaskService, private router: Router) { }

  formatter = (query: TermsSearchQuery) => query.name;

  search = (text$: Observable<string>) =>
    text$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      filter(text => text.length > 2),
      tap(() => this.searching = true),
      switchMap(text => this.getSuggestions(text)),
      tap(() => this.searching = false)
    )

  getSuggestions(text: string): Observable<TermsSearchQuery[]> {
    if (this.domainService.isUrl(text)) {
      return of([TermsSearchQuery.fromUrl(text)]);
    } else {
      this.taskService.startTask();
      return this.domainService.filter(text, true).pipe(
        tap(() => this.searchFailed = false),
        switchMap(domains => {
          const queries = domains.map(domain => TermsSearchQuery.fromDomain(domain));
          this.taskService.finishTask();
          return of(queries);
        }),
        catchError(() => {
          // TODO: Catch with an alert
          this.searchFailed = true;
          this.taskService.finishTask();
          console.error('ERROR! Here');
          return of([]);
        }));
    }
  }

  onSubmit(): void {
    this.submit.next(this.selectedQuery);
    if (this.navigate) {
      this.stateService.termsQuery$.next(this.selectedQuery);
      const queryParams = this.selectedQuery.isDomain ? { domain: this.selectedQuery.name } : { url: this.selectedQuery.name };
      this.router.navigate(['/terms'], { queryParams });
    }
    this.clear();
  }

  compareTo(): void {
    this.compare.next(this.selectedQuery);
    this.clear();
  }

  clear(): void {
    this.selectedQuery = undefined;
  }
}
