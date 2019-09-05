import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsignerDetailsComponent } from './consigner-details.component';

describe('ConsignerDetailsComponent', () => {
  let component: ConsignerDetailsComponent;
  let fixture: ComponentFixture<ConsignerDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsignerDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsignerDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
