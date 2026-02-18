import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculadoraInvestimentoComponent } from './calculadora-investimento.component';

describe('CalculadoraInvestimentoComponent', () => {
  let component: CalculadoraInvestimentoComponent;
  let fixture: ComponentFixture<CalculadoraInvestimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalculadoraInvestimentoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CalculadoraInvestimentoComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
