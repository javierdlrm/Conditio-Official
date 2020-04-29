import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@shared/shared.module';
import { EntityService } from '@core/entity/entity.service';
import { EntityUrls } from '@core/entity/entity.urls';

@NgModule({
  imports: [SharedModule, RouterModule],
  exports: [],
  declarations: [],
  providers: [EntityService, EntityUrls]
})
export class EntityModule { }
