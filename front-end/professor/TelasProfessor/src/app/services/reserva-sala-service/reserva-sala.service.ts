import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ReservaSalaModel } from '../../models/reserva-sala-model';
import { ReservaSalaDados } from '../../models/reserva-sala-dados';

@Injectable({
  providedIn: 'root',
})
export class ReservaSalaService {
  private url = 'https://localhost:7067/api/ReservaSala';
  private dadosReservaSubject = new BehaviorSubject<ReservaSalaDados | null>(
    null
  );

  dadosReserva$ = this.dadosReservaSubject.asObservable();

  constructor(private http: HttpClient) {}

  getReservas(idProfessor: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}/professor/${idProfessor}`);
  }

  getReservaPorId(idReserva: number): Observable<any> {
    return this.http.get<any>(`${this.url}/${idReserva}`);
  }

  getReservasComFiltro(sala: string, turno: string): Observable<any[]> {
    const headers = new HttpHeaders().set('sala', sala).set('turno', turno);
    return this.http.get<any[]>(`${this.url}/filtro`, { headers });
  }

  excluirReserva(idReserva: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${idReserva}`);
  }

  criarReserva(
    reserva: ReservaSalaModel,
    idProfessor: number
  ): Observable<void> {
    const headers = new HttpHeaders().set(
      'idProfessor',
      idProfessor.toString()
    );
    return this.http.post<void>(`${this.url}`, reserva, { headers });
  }

  atualizarReserva(
    reserva: ReservaSalaModel,
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

  setDadosReserva(dados: ReservaSalaDados): void {
    this.dadosReservaSubject.next(dados);
    console.log(this.dadosReservaSubject.getValue());
  }

  limparDadosReserva(): void {
    this.dadosReservaSubject.next(null);
  }

  getDadosReserva(): Observable<ReservaSalaDados | null> {
    return this.dadosReservaSubject.asObservable();
  }
}
