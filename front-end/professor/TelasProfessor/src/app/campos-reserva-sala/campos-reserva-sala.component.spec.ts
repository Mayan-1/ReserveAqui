import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CamposReservaSalaComponent } from './campos-reserva-sala.component';

describe('CamposReservaSalaComponent', () => {
  let component: CamposReservaSalaComponent;
  let fixture: ComponentFixture<CamposReservaSalaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CamposReservaSalaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CamposReservaSalaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
