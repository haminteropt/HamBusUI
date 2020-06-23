import { InfoPacket } from './../../model/info-packet';


import { OnDestroy } from '@angular/core';
import { DispatchService } from './../../service/dispatch/dispatch.service';
import { Component, OnInit } from '@angular/core';
import { BasePage } from 'src/app/base-pages/basepage';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-rig-bus-edit',
  templateUrl: './rig-bus-edit.component.html',
  styleUrls: ['./rig-bus-edit.component.scss']
})
export class RigBusEditComponent extends BasePage implements OnInit, OnDestroy {

  public infoPacket = {};
  public rigForm: FormGroup;
  constructor(private dispatch: DispatchService, private fb: FormBuilder) {
    super();
  }

  ngOnInit() {
    this.subscribe();
    this.buildFormGroup();
  }

  public saveClick(): void {
    console.log(this.rigForm.value);
  }
  private subscribe(): void {
    // this.dispatch.busChanges$.pipe(takeUntil(this.destroy$)).
    this.dispatch.busChanges$.
      subscribe((val: InfoPacket) => {
        console.log(val);
        this.infoPacket = val;
      });
  }
  private buildFormGroup(): void {
    this.rigForm = this.fb.group({
      name: ["foobar"],
      portName: [],
      baudRate: [19200],
      parity: ["even"],
      dataBits: [7],
      stopBits: [1.5]
    });
  }

}
