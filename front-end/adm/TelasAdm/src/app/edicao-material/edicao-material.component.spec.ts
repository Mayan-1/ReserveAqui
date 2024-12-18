import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdicaoMaterialComponent } from './edicao-material.component';

describe('EdicaoMaterialComponent', () => {
  let component: EdicaoMaterialComponent;
  let fixture: ComponentFixture<EdicaoMaterialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EdicaoMaterialComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EdicaoMaterialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
