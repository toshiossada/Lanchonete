import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LanchesComponent } from './lanches.component';

describe('LanchesComponent', () => {
  let component: LanchesComponent;
  let fixture: ComponentFixture<LanchesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LanchesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LanchesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
