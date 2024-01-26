import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_Services/account.service';
import { map } from 'rxjs';

export const guestGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  return accountService.currentUser$.pipe(
    map(user => {
      if (!user) return false

      // console.log(user);


      if (user.roleName == "Guest") {
        return true;
      } else {
        //toastr error message: cannot access area 
        console.log("Cant acces to this content, ony Guests!!");

        return false
      }
    })
  )


};
