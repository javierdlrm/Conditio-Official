import { NgModule } from '@angular/core';
import { CoreModule } from '@core/core.module';
import { SharedModule } from '@shared/shared.module';
import { TermsOverviewComponent } from '@features/terms/overview/terms-overview.component';
import { TermsGridComponent } from '@terms/grid/terms-grid.component';
import { TermsGridCellComponent } from '@terms/grid/terms-grid-cell.component';
import { TermsDetailComponent } from './detail/terms-detail.component';

@NgModule({
  imports: [SharedModule, CoreModule],
  exports: [TermsOverviewComponent, TermsGridComponent, TermsGridCellComponent, TermsDetailComponent],
  declarations: [TermsOverviewComponent, TermsGridComponent, TermsGridCellComponent, TermsDetailComponent],
  entryComponents: [TermsDetailComponent]
})
export class TermsModule { }
