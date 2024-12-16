import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TurnoService {
  private url = 'https://localhost:7067/api/Turno';

  constructor(private http: HttpClient) {}

  getTurnos(): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}`);
  }
}
