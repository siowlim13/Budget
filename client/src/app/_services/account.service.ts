import { inject, Injectable, signal } from '@angular/core';
import { Account } from '../_models/user';
import { map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient)
  baseUrl = environment.apiUrl;
  currentUser = signal<Account | null>(null);

  login(model: any){
    return this.http.post<Account>(this.baseUrl + 'Account/login', model).pipe(
      map(user => {
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
     )
  }
  register(model: any){
    return this.http.post<Account>(this.baseUrl + 'Account/register', model).pipe(
      map(user => {
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
        return user;
      })
     )
  }
  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
