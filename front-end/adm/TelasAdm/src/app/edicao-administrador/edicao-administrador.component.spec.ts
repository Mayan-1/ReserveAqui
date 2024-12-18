import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdicaoAdministradorComponent } from './edicao-administrador.component';

describe('EdicaoAdministradorComponent', () => {
  let component: EdicaoAdministradorComponent;
  let fixture: ComponentFixture<EdicaoAdministradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EdicaoAdministradorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EdicaoAdministradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
