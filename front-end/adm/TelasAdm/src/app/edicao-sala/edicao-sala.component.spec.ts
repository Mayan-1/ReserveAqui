import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdicaoSalaComponent } from './edicao-sala.component';

describe('EdicaoSalaComponent', () => {
  let component: EdicaoSalaComponent;
  let fixture: ComponentFixture<EdicaoSalaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EdicaoSalaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EdicaoSalaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
