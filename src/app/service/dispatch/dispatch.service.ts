import { HamBusError } from './../../model/master-status';
import { InfoPacket } from './../../model/info-packet';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';


@Injectable({
  providedIn: 'root'
})
export class DispatchService {
  public busChanges$: BehaviorSubject<InfoPacket> = new BehaviorSubject(null);
  public radioStateChange$: BehaviorSubject<any> = new BehaviorSubject(null);
  public saveConfigureStatus$: BehaviorSubject<any> = new BehaviorSubject(null);
  constructor() { }
  public loginPacket(infoPacket: InfoPacket): void {
    this.busChanges$.next(infoPacket);
  }
  public saveConfigStatus(status: HamBusError) {
    this.saveConfigureStatus$.next(status);
  }
}


