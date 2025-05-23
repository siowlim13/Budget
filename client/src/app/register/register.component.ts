import { Component, inject, input, output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountServices = inject(AccountService);
  private toastr = inject(ToastrService);
  cancelRegister = output<boolean>();
  model: any = {}

  register(){
    this.accountServices.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: error => this.toastr.error(error.error)
    })
  }

  cancel(){
    this.cancelRegister.emit(false);
  }
}
