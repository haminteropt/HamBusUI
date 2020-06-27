import { SignalrService } from './../../service/signalr/signalr.service';
import { BusConfigurationDb } from './../../model/busConfigurationDb';
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
  private conf = new BusConfigurationDb();
  public rigForm: FormGroup;
  constructor(private dispatch: DispatchService, private fb: FormBuilder, private sigR: SignalrService) {
    super();
  }

  ngOnInit() {
    this.subscribe();
    this.buildFormGroup();
  }

  public saveClick(): void {

    if (!this.conf.id) {
      this.conf.name = this.rigForm.get('name').value;
      this.conf.version = '';
      this.conf.configuration = JSON.stringify(this.rigForm.value);
    } else {
      this.conf.name = this.rigForm.get('name').value;
      this.conf.configuration = JSON.stringify(this.rigForm.value);
    }
    this.sigR.saveConfig('', this.conf);
    console.log(this.rigForm.value);
  }

  public newClick(): void {
    this.rigForm.get('name').patchValue('');
    this.conf.id = null;
  }
  private subscribe(): void {
    // this.dispatch.busChanges$.pipe(takeUntil(this.destroy$)).
    this.dispatch.busChanges$.
      subscribe((val: InfoPacket) => {
        this.infoPacket = val;
      });
  }
  private buildFormGroup(): void {
    this.rigForm = this.fb.group({
      name: ['foo'],
      portName: [],
      baudRate: [19200],
      parity: ['none'],
      dataBits: [8],
      stopBits: [1]
    });
  }

}
