import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForgotPWDComponent } from './forgot-pwd.component';

describe('ForgotPWDComponent', () => {
  let component: ForgotPWDComponent;
  let fixture: ComponentFixture<ForgotPWDComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ForgotPWDComponent]
    });
    fixture = TestBed.createComponent(ForgotPWDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
