import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';
import { InfoPacket } from 'src/app/model/info-packet';

@Injectable({
  providedIn: 'root'
})
export class DispatchService {
  public busChanges$: Subject<any[]>;
  public radioStateChange$: Subject<any>;
  constructor() { }
  public loginPacket(infoPacket: InfoPacket): void {
    console.log(infoPacket);

  }
}


