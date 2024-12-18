import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { MaterialEdicaoDto } from '../../models/materialEdicaoDto';
import { MaterialCriacaoDto } from '../../models/materialCriacaoDto';
import { TurmaCriacaoDto } from '../../models/turmaCriacaoDto';
import { TurmaEdicaoDto } from '../../models/turmaEdicaoDto';

@Injectable({
  providedIn: 'root',
})
export class TurmaService {
  constructor() {}

  http = inject(HttpClient);

  private url = 'https://localhost:7067/api/Turma';

  obterTodos() {
    return this.http.get<any[]>(`${this.url}`);
  }

  obterPorId(id: number) {
    return this.http.get<any>(`${this.url}/${id}`);
  }

  criar(turma: TurmaCriacaoDto): Observable<void> {
    return this.http.post<void>(`${this.url}`, turma);
  }

  editar(id: number, turma: TurmaEdicaoDto): Observable<void> {
    return this.http.put<void>(`${this.url}/${id}`, turma);
  }

  deletar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}
