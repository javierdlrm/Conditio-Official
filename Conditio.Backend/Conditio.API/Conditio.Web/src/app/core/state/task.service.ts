import { Injectable } from '@angular/core';
import { Subject, BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class TaskService {

    loading$: Subject<boolean> = new BehaviorSubject<boolean>(false);
    private taskCount = 0;

    startTask(): void {
        this.taskCount += 1;
        if (!(this.loading$ as BehaviorSubject<boolean>).value) {
            setTimeout(() => {
                if (this.taskCount > 0 && !(this.loading$ as BehaviorSubject<boolean>).value) {
                    this.loading$.next(true);
                }
            }, (350));
        }
    }

    finishTask(): void {
        if (this.taskCount <= 0) {
            throw new Error('Task count cannot be lower than zero.');
        }
        this.taskCount -= 1;
        if (this.taskCount === 0 && (this.loading$ as BehaviorSubject<boolean>).value) {
            this.loading$.next(false);
        }
    }

    async monitor<T>(func: () => T): Promise<T> {
        this.startTask();
        const result = await func();
        this.finishTask();
        return result;
    }
}
