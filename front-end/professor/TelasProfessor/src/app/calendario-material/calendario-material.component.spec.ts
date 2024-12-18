import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalendarioMaterialComponent } from './calendario-material.component';

describe('CalendarioMaterialComponent', () => {
  let component: CalendarioMaterialComponent;
  let fixture: ComponentFixture<CalendarioMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalendarioMaterialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CalendarioMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
