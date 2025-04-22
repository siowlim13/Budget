import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ledger } from '../_models/ledger';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class LedgerService {
  private http = inject(HttpClient)
  private accountService = inject(AccountService)
  baseUrl = environment.apiUrl;

  getLedger(username: string){
    return this.http.get<ledger[]>(this.baseUrl + 'Ledger/' + username, this.getHttpOptions());
  }

  updateLedger(transaction: ledger){
    return this.http.put<ledger>(this.baseUrl + 'AddPayment', this.getHttpOptions())
  }

  getHttpOptions() {
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.accountService.currentUser()?.token}`
      })
    }
  }
}
