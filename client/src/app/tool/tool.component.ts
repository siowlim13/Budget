import { Component, inject, OnInit, ViewChild, viewChild } from '@angular/core';
import { LedgerService } from '../_services/ledger.service';
import { ledger } from '../_models/ledger';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-tool',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './tool.component.html',
  styleUrl: './tool.component.css'
})
export class ToolComponent implements OnInit{
  @ViewChild('paymentForm') paymentForm?: NgForm;
  private ledgerService = inject(LedgerService)
  private accountService = inject(AccountService)
  private toastr = inject(ToastrService)

  ledger?: ledger[];
  dataSource=this.ledger;
  payments: any = {};

  username = JSON.parse(localStorage.getItem('user') || '""');

  ngOnInit(): void {
    this.loadLedger();
  }

  loadLedger() {
    const user = this.accountService.currentUser();
    if (!user) return;
    this.ledgerService.getLedger(user.username).subscribe({
      next: ledger => {
        console.log(ledger);
        this.ledger = ledger;
      }
    })
    console.log(user);
  }

  updateLedger() {
    this.ledgerService.updateLedger(this.paymentForm?.value).subscribe({
      next: _ => {
        this.toastr.success('Payment Added');
        this.paymentForm?.reset(this.payments)
      }
    })
  }
}
