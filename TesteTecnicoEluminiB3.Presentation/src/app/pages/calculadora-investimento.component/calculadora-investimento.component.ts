import { ChangeDetectorRef, Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { SimulacaoRendimentoResponse } from '../../models/simulacao-rendimento-response.model';
import { CalculadoraService } from '../../services/calculadora.service';
import { SimulacaoRendimentoRequest } from '../../models/simulacao-rendimento-request.model';

@Component({
  selector: 'app-calculadora-investimento',
  standalone: false,
  templateUrl: './calculadora-investimento.component.html',
  styleUrl: './calculadora-investimento.component.css',
})
export class CalculadoraInvestimentoComponent {
  private fb = inject(FormBuilder);
  carregando = false;
  mensagemErro = '';
  resultado: SimulacaoRendimentoResponse | null = null;
  
  constructor(private calculadoraService: CalculadoraService, private cd: ChangeDetectorRef ) { }

  formulario = this.fb.group({
    valorInicial: [null, [Validators.required, Validators.min(0.01)]],
    prazo: [null, [Validators.required, Validators.min(2)]]
  })

  enviar(): void {
    this.mensagemErro = '';
    this.resultado = null;

    

    if (this.formulario.invalid) {
      this.formulario.markAsTouched();
      return;
    }

    this.carregando = true;

    const request: SimulacaoRendimentoRequest = {
      valorInicial: Number(this.formulario.getRawValue().valorInicial),
      prazo: Number(this.formulario.getRawValue().prazo)
    };

    this.calculadoraService.calcular(request).subscribe({
      next: (res) => {
        this.resultado = res;
        this.carregando = false;
        this.formulario.reset();
        this.cd.detectChanges();
      },
      error: () => {
        this.mensagemErro = 'Não foi possível realiar simulação. Tente novamente.';
        this.carregando = false;
      }
    });
  }

  get f() {
    return this.formulario.controls;
  }

}
