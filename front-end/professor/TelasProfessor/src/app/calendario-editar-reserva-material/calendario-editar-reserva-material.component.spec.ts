import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalendarioEditarReservaMaterialComponent } from './calendario-editar-reserva-material.component';

describe('CalendarioEditarReservaMaterialComponent', () => {
  let component: CalendarioEditarReservaMaterialComponent;
  let fixture: ComponentFixture<CalendarioEditarReservaMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalendarioEditarReservaMaterialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CalendarioEditarReservaMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
