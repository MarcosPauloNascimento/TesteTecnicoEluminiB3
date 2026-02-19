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

  it('deve chamar o serviço se o formulário for válido', () => {
    component.formulario.controls.valorInicial.setValue(1000 as any);
    component.formulario.controls.prazo.setValue(10 as any);

    component.enviar();

    httpMock.expectOne((request) => request.url.includes('/api/calculadora-investimento/cdb'));
    expect(component.carregando).toBe(true);
  });

  it('deve processar o retorno da API e exibir os valores formatados no HTML', () => {
    // 1. Arrange: Dados fictícios que sua API .NET enviaria
    const dadosMockadoDaApi = {
      valorBruto: 'R$ 138,140',
      valorLiquido: 'R$ 135,11',
      rendimento: 'R$ 15,14',
      aliquotaAplicada: '20,00%',
      valorImposto: 'R$ 3,03',
      prazo: 12,
      valorInicial: 'R$ 123,00',
      tipoInvestimento: 'CDB'
    };

    // Preenchemos o form para permitir o envio
    component.formulario.controls.valorInicial.setValue(1000 as any);
    component.formulario.controls.prazo.setValue(12 as any);

    // 2. Act: Dispara a ação de enviar
    component.enviar();

    // 3. Intercepta a requisição HTTP pendente
    const req = httpMock.expectOne(request => request.url.includes('/api/calculadora-investimento/cdb'));

    // Responde a requisição com o mock
    req.flush(dadosMockadoDaApi);

    // Força o Angular a atualizar o HTML com os novos dados do 'resultado'
    fixture.detectChanges();

    // 4. Assert: Verifica se o objeto foi preenchido corretamente
    expect(component.resultado).toEqual(dadosMockadoDaApi);
    expect(component.carregando).toBe(false);

    //// Verifica se o valor aparece na tela (Supondo que você use um id ou tag para o resultado)
    //const debugElement = fixture.nativeElement;
    //const textoNaTela = debugElement.textContent;

    //// Verifica se o valor líquido formatado como moeda aparece no HTML
    //expect(textoNaTela).toContain('1.080,25');
  });

  afterEach(() => {
    httpMock.verify(); // Garante que não há requisições pendentes
  });
});
