import { Injectable, Inject } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthUrls {

  baseUrl = 'api/auth';

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = `${baseUrl}${this.baseUrl}`;
  }

  register(): string {
    return `${this.baseUrl}/register`;
  }

  signIn(username: string, password: string): string {
    return `${this.baseUrl}/sign-in?username=${username}&password=${password}`;
  }
}
