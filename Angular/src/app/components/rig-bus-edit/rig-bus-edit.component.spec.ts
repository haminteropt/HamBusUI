/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RigBusEditComponent } from './rig-bus-edit.component';

describe('RigBusEditComponent', () => {
  let component: RigBusEditComponent;
  let fixture: ComponentFixture<RigBusEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RigBusEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RigBusEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
