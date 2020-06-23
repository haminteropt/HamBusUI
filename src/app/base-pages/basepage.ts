import { MediaMatcher } from '@angular/cdk/layout';
import { OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';

export abstract class BasePage implements OnDestroy {

  destroy$ = new Subject<void>();



  constructor() {}


  ngOnDestroy(): void {
    try {
      this.destroy$.next();
      this.destroy$.complete();
    } catch {}
  }


}
