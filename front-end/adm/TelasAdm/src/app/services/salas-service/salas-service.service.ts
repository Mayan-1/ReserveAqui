import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { SalaCriacaoDto } from '../../models/salaCriacaoDto';
import { SalaEdicaoDto } from '../../models/salaEdicaoDto';

@Injectable({
  providedIn: 'root',
})
export class SalaService {
  constructor() {}

  http = inject(HttpClient);

  private url = 'https://localhost:7067/api/Sala';

  obterTodos() {
    return this.http.get<any[]>(`${this.url}`);
  }

  obterPorId(id: number) {
    return this.http.get<any>(`${this.url}/${id}`);
  }

  criar(sala: SalaCriacaoDto): Observable<void> {
    return this.http.post<void>(`${this.url}`, sala);
  }

  editar(id: number, sala: SalaEdicaoDto): Observable<void> {
    return this.http.put<void>(`${this.url}/${id}`, sala);
  }

  deletar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}
