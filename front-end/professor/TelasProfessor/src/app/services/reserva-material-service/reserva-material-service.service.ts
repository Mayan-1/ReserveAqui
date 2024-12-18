import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ReservaSalaModel } from '../../models/reserva-sala-model';
import { ReservaSalaDados } from '../../models/reserva-sala-dados';
import { ReservaMaterialDados } from '../../models/reserva-material-dados';
import { ReservaMaterialModel } from '../../models/reserva-material-model';

@Injectable({
  providedIn: 'root',
})
export class ReservaMaterialService {
  private url = 'https://localhost:7067/api/ReservaMaterial';
  private dadosReservaSubject =
    new BehaviorSubject<ReservaMaterialDados | null>(null);

  dadosReserva$ = this.dadosReservaSubject.asObservable();

  constructor(private http: HttpClient) {}

  getReservas(idProfessor: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}/professor/${idProfessor}`);
  }

  getReservaPorId(idReserva: number): Observable<any> {
    return this.http.get<any>(`${this.url}/${idReserva}`);
  }

  getReservasComFiltro(material: string, turno: string): Observable<any[]> {
    const headers = new HttpHeaders()
      .set('material', material)
      .set('turno', turno);
    return this.http.get<any[]>(`${this.url}/filtro`, { headers });
  }

  excluirReserva(idReserva: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${idReserva}`);
  }

  criarReserva(
    reserva: ReservaMaterialModel,
    idProfessor: number
  ): Observable<void> {
    const headers = new HttpHeaders().set(
      'idProfessor',
      idProfessor.toString()
    );
    return this.http.post<void>(`${this.url}`, reserva, { headers });
  }

  atualizarReserva(
    reserva: ReservaMaterialModel,
    idProfessor: number,
    idReserva: number
  ): Observable<void> {
    const headers = new HttpHeaders().set(
      'idProfessor',
      idProfessor.toString()
    );
    return this.http.put<void>(`${this.url}/${idReserva}`, reserva, {
      headers,
    });
  }

  setDadosReserva(dados: ReservaMaterialDados): void {
    this.dadosReservaSubject.next(dados);
    console.log(this.dadosReservaSubject.getValue());
  }

  limparDadosReserva(): void {
    this.dadosReservaSubject.next(null);
  }

  getDadosReserva(): Observable<ReservaMaterialDados | null> {
    return this.dadosReservaSubject.asObservable();
  }
}
