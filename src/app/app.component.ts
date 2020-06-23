import { DispatchService } from './service/dispatch/dispatch.service';
import { SignalrService } from './service/signalr/signalr.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'HamBusUI';
  public constructor(private sigR: SignalrService, private dispatch: DispatchService) {
    this.connectSignalR();
  }
  private connectSignalR(): void {

  }
}
