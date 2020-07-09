import { Component, Input, Output, EventEmitter } from "@angular/core";

@Component({
  selector: 'custom-alert',
  templateUrl: 'alert.component.html'
})

export class AlertComponent {
  @Input() public alerts: any[] = [];
  @Output() public onRemoveAlert = new EventEmitter<any>();

  onClosed(dismissedAlert: AlertComponent) {
    this.alerts = this.alerts.filter(alert => alert !== dismissedAlert);

    this.onRemoveAlert.emit(this.alerts);
  }
}
