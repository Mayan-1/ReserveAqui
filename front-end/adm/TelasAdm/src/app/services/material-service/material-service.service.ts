import { HttpClient, provideHttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { MaterialEdicaoDto } from '../../models/materialEdicaoDto';
import { MaterialCriacaoDto } from '../../models/materialCriacaoDto';

@Injectable({
  providedIn: 'root',
})
export class MaterialService {
  constructor() {}

  http = inject(HttpClient);

  private url = 'https://localhost:7067/api/Material';

  obterTodos() {
    return this.http.get<any[]>(`${this.url}`);
  }

  obterPorId(id: number) {
    return this.http.get<any>(`${this.url}/${id}`);
  }

  criar(material: MaterialCriacaoDto): Observable<void> {
    return this.http.post<void>(`${this.url}`, material);
  }

  editar(id: number, material: MaterialEdicaoDto): Observable<void> {
    return this.http.put<void>(`${this.url}/${id}`, material);
  }

  deletar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}
