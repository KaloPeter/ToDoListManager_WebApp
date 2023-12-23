import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_Services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {


  registerModel: any = {};

  constructor(private accountService: AccountService, private router: Router) { }


  register() {
    this.accountService.register(this.registerModel).subscribe(
      {
        next: () => this.router.navigateByUrl("/"),
        error: er => console.log("Error during Register: " + er)
      }
    )
  }


}
