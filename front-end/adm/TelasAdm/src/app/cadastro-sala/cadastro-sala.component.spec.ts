import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroSalaComponent } from './cadastro-sala.component';

describe('CadastroSalaComponent', () => {
  let component: CadastroSalaComponent;
  let fixture: ComponentFixture<CadastroSalaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CadastroSalaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastroSalaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
