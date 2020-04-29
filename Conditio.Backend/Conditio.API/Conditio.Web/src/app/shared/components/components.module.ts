import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgBootstrapModule } from '@shared/modules/ng-bootstrap.module';
import { RatingComponent } from './rating/rating.component';
import { AngularSvgIconModule } from 'angular-svg-icon';

@NgModule({
  imports: [CommonModule, FormsModule, NgBootstrapModule, AngularSvgIconModule],
  exports: [RatingComponent, AngularSvgIconModule],
  declarations: [RatingComponent]
})
export class ComponentsModule { }
