import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CamposReservaMaterialComponent } from './campos-reserva-material.component';

describe('CamposReservaMaterialComponent', () => {
  let component: CamposReservaMaterialComponent;
  let fixture: ComponentFixture<CamposReservaMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CamposReservaMaterialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CamposReservaMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
