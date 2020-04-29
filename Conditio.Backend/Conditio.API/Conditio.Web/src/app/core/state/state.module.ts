import { NgModule } from '@angular/core';

import { StateService } from '@core/state/state.service';
import { TaskService } from '@core/state/task.service';

@NgModule({
  providers: [StateService, TaskService]
})
export class StateModule { }
