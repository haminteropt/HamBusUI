

import { OnDestroy } from '@angular/core';
import { DispatchService } from './../../service/dispatch/dispatch.service';
import { Component, OnInit } from '@angular/core';
import { BasePage } from 'src/app/base-pages/basepage';

@Component({
  selector: 'app-rig-bus-edit',
  templateUrl: './rig-bus-edit.component.html',
  styleUrls: ['./rig-bus-edit.component.scss']
})
export class RigBusEditComponent extends BasePage implements OnInit, OnDestroy {

  constructor(private dispatch: DispatchService) {
    super();
  }

  ngOnInit() {

  }
  public subscribe(): void {
    // this.dispatch.busChanges$.pipe(takeUntil(this.destroy$)).
    this.dispatch.busChanges$.
      subscribe((val) => {
        console.log(val);
      });
  }

}
