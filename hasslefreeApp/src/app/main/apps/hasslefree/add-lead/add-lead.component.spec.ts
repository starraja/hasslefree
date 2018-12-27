import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLeadComponentComponent } from './add-lead-component.component';

describe('AddLeadComponentComponent', () => {
  let component: AddLeadComponentComponent;
  let fixture: ComponentFixture<AddLeadComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLeadComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLeadComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
