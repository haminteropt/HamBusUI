import { HamBusError } from './../model/master-status';

import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { InfoPacket } from '../model/info-packet';


@Injectable({
  providedIn: 'root'
})
export class DispatchService {
  public busChanges$: BehaviorSubject<InfoPacket> = new BehaviorSubject(null);
  public radioStateChange$: BehaviorSubject<any> = new BehaviorSubject(null);
  public saveConfigureStatus$: BehaviorSubject<any> = new BehaviorSubject(null);



private _value : string;
public get value() : string {
  return this._value;
}
public set value(v : string) {
  this._value = v;
}


  constructor() { }
  public loginPacket(infoPacket: InfoPacket): void {
    console.log(infoPacket);
    this.busChanges$.next(infoPacket);
  }
  public saveConfigStatus(status: HamBusError) {
    this.saveConfigureStatus$.next(status);
  }
}


