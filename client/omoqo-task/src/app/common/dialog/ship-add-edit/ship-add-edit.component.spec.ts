import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipAddEditComponent } from './ship-add-edit.component';

describe('ShipAddEditComponent', () => {
  let component: ShipAddEditComponent;
  let fixture: ComponentFixture<ShipAddEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShipAddEditComponent]
    });
    fixture = TestBed.createComponent(ShipAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
