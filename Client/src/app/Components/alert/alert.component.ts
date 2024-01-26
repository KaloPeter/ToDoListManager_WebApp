import { Component } from '@angular/core';
import { AlertType } from 'src/app/_Models/AlertType';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent {

  // @Input() alertType: string = "";
  // @Input() message: string = "";
  // @Input() timeout: number = 5000;

  alerts: AlertType[] = [];



  displayAlert(alertType: string, message: string, timeout: number) {
    let alert: AlertType = {
      type: alertType,
      msg: message,
      timeout: timeout
    }
    if (this.alerts.length < 3) {//This is where we restrict that the alert can appear maximum 3 times, then it starts overwite the precois ones
      this.alerts.push(alert)
    } else {
      this.alerts.unshift(alert);
      this.alerts.pop();
    }
  }





  onClosedAlert(dismissedAlert: AlertType): void {
    this.alerts = this.alerts.filter((alert) => alert !== dismissedAlert);
  }

}
