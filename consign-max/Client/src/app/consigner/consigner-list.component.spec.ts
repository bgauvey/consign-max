import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsignerListComponent } from './consigner-list.component';

describe('DashboardComponent', () => {
  let component: ConsignerListComponent;
  let fixture: ComponentFixture<ConsignerListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsignerListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsignerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
