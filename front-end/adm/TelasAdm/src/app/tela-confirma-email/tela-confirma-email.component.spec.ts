import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaConfirmaEmailComponent } from './tela-confirma-email.component';

describe('TelaConfirmaEmailComponent', () => {
  let component: TelaConfirmaEmailComponent;
  let fixture: ComponentFixture<TelaConfirmaEmailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TelaConfirmaEmailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TelaConfirmaEmailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
