import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Injectable, inject } from '@angular/core';
import { ProfessorCriacaoDto } from '../models/professorCriacaoDto';
import { Observable } from 'rxjs';
import { ProfessorEdicaoDto } from '../models/professorEdicaoDto';
import { Professor } from '../models/professor';

@Injectable({
  providedIn: 'root',
})
export class ProfessorService {
  constructor() {}

  http = inject(HttpClient);

  private url = 'https://localhost:7067/api/Professor';

  obterProfessores() {
    return this.http.get<Professor[]>(`${this.url}`);
  }

  obterProfessorPorId(id: number) {
    return this.http.get<Professor>(`${this.url}/${id}`);
  }

  criarProfessor(professor: ProfessorCriacaoDto): Observable<void> {
    return this.http.post<void>(`${this.url}`, professor);
  }

  editarProfessor(id: number, professor: ProfessorEdicaoDto): Observable<void> {
    return this.http.put<void>(`${this.url}/${id}`, professor);
  }

  deletarProfessor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}
