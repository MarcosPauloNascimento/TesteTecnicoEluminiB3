import { Injectable } from "@angular/core";
import { SimulacaoRendimentoRequest } from "../models/simulacao-rendimento-request.model";
import { SimulacaoRendimentoResponse } from "../models/simulacao-rendimento-response.model";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { enviroment } from "../../enviroments/enviroment";

@Injectable({ providedIn: 'root' })
export class CalculadoraService {
  private readonly baseUrl = `${enviroment.apiBaseUrl}/api/calculadora-investimento/cdb`;

  constructor(private httpClient: HttpClient) { }

  calcular(simulacao: SimulacaoRendimentoRequest): Observable<SimulacaoRendimentoResponse> {
    return this.httpClient.post<SimulacaoRendimentoResponse>(this.baseUrl, simulacao);
  }
}
