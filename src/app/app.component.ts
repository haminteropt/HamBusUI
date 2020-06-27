import { DispatchService } from './service/dispatch/dispatch.service';
import { SignalrService } from './service/signalr/signalr.service';
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'HamBusUI';
  public constructor(private router: Router, private sigR: SignalrService, private dispatch: DispatchService) {
    this.connectSignalR();
  }
  private connectSignalR(): void {

  }
  public rigClick(): void {
    console.log("rig click");
    this.router.navigate(['/rigEdit'])
  }
  
  public homeClick(): void {
    console.log("home click");
    this.router.navigate(['/home']);
  }
}
