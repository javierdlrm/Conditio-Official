import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { AuthUrls } from '@core/auth/auth.urls';
import { Credentials } from '@core/auth/models/credentials';
import { User } from '@core/user/models/user.model';
import { UserNew } from '@core/auth/models/user-new.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private http: HttpClient, private urls: AuthUrls) { }

  register(usernew: UserNew): Observable<User> {
    return this.http.post<User>(this.urls.register(), usernew);
  }

  signIn(credentials: Credentials): Observable<string> {
    return this.http.get<string>(this.urls.signIn(credentials.username, credentials.password));
  }
}
