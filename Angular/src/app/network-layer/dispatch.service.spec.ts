/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DispatchService } from './dispatch.service';

describe('Service: Dispatch', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DispatchService]
    });
  });

  it('should ...', inject([DispatchService], (service: DispatchService) => {
    expect(service).toBeTruthy();
  }));
});
