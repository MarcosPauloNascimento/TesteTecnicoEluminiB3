import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { ChangeDetectorRef } from '@angular/core';
import { CalculadoraInvestimentoComponent } from './calculadora-investimento.component';
import { CalculadoraService } from '../../services/calculadora.service';
import { of, throwError } from 'rxjs';

describe('CalculadoraInvestimentoComponent', () => {
  let component: CalculadoraInvestimentoComponent;
  let fixture: ComponentFixture<CalculadoraInvestimentoComponent>;
  let httpMock: HttpTestingController;
  let service: CalculadoraService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalculadoraInvestimentoComponent],
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule // Mock do HttpClient para o Service
      ],
      providers: [
        CalculadoraService,
        ChangeDetectorRef
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(CalculadoraInvestimentoComponent);
    component = fixture.componentInstance;
    service = TestBed.inject(CalculadoraService);
    httpMock = TestBed.inject(HttpTestingController);
    fixture.detectChanges();
  });

  it('deve iniciar o formulário como inválido', () => {
    expect(component.formulario.invalid).toBe(true);
  });

  it('deve preencher o resultado e resetar o form após sucesso da API', () => {
    const mockResponse = { valorBruto: 1100, valorLiquido: 1080 };

    // Preenche o formulário
    component.formulario.controls.valorInicial.setValue(1000 as any);
    component.formulario.controls.prazo.setValue(12 as any);

    component.enviar();

    // Intercepta a chamada HTTP
    const req = httpMock.expectOne((request) => request.url.includes('/api/calculadora-investimento/cdb'));
    expect(req.request.method).toBe('POST');

    // Simula a resposta do servidor
    req.flush(mockResponse);

    expect(component.resultado).toEqual(mockResponse);
    expect(component.carregando).toBe(false);
    // Verifica se o formulário foi resetado
    expect(component.formulario.controls.valorInicial.value).toBeNull();
  });

  it('deve exibir mensagem de erro quando a API falhar', () => {
    component.formulario.controls.valorInicial.setValue(500 as any);
    component.formulario.controls.prazo.setValue(6 as any);

    component.enviar();

    const req = httpMock.expectOne((request) => request.url.includes('/api/calculadora-investimento/cdb'));

    // Simula um erro de rede/servidor
    req.error(new ErrorEvent('Network error'));

    expect(component.mensagemErro).toContain('Não foi possível realiar simulação');
    expect(component.carregando).toBe(false);
    expect(component.resultado).toBeNull();
  });

  it('não deve chamar o serviço se o formulário for inválido', () => {
    component.formulario.controls.valorInicial.setValue(0 as any); // Inválido (min 0.01)

    component.enviar();

    // Verifica que nenhuma requisição foi feita
    httpMock.expectNone((request) => request.url.includes('/api/calculadora-investimento/cdb'));
    expect(component.carregando).toBe(false);
  });

  afterEach(() => {
    httpMock.verify(); // Garante que não há requisições pendentes
  });
});
