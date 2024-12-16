import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalendarioEditarReservaSalaComponent } from './calendario-editar-reserva-sala.component';

describe('CalendarioEditarReservaSalaComponent', () => {
  let component: CalendarioEditarReservaSalaComponent;
  let fixture: ComponentFixture<CalendarioEditarReservaSalaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalendarioEditarReservaSalaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CalendarioEditarReservaSalaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
