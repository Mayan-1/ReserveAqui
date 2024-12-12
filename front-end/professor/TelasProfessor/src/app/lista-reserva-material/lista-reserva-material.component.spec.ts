import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaReservaMaterialComponent } from './lista-reserva-material.component';

describe('ListaReservaMaterialComponent', () => {
  let component: ListaReservaMaterialComponent;
  let fixture: ComponentFixture<ListaReservaMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListaReservaMaterialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListaReservaMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
