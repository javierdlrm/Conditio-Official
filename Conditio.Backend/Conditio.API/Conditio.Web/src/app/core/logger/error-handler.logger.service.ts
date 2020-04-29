import { Injectable, ErrorHandler, Injector, Type } from '@angular/core';
import { LoggerService } from '@core/logger/logger.service';

@Injectable({
    providedIn: 'root',
})
export class ErrorHandlerLoggerService extends ErrorHandler {

    constructor(private injector: Injector) {
        super();
    }

    handleError(error: any): void {
        const loggerService = this.injector.get<LoggerService>(LoggerService as Type<LoggerService>);
        loggerService.trackException(error);
        super.handleError(error);
    }
}
