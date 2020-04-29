import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AngularSvgIconModule } from 'angular-svg-icon';

import { ComponentsModule } from '@shared/components/components.module';
import { DirectivesModule } from '@shared/directives/directives.module';
import { PipesModule } from '@shared/pipes/pipes.module';
import { FontAwesomeModule } from '@shared/modules/font-awesome.module';
import { NgBootstrapModule } from './modules/ng-bootstrap.module';

@NgModule({
  imports: [
    CommonModule, RouterModule, FormsModule, ReactiveFormsModule, ComponentsModule, DirectivesModule, PipesModule,
    FontAwesomeModule, NgBootstrapModule, AngularSvgIconModule
  ],
  exports: [
    CommonModule, RouterModule, FormsModule, ReactiveFormsModule, ComponentsModule, DirectivesModule, PipesModule,
    FontAwesomeModule, NgBootstrapModule, AngularSvgIconModule
  ]
})
export class SharedModule { }
