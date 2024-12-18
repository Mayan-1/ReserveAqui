import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MaterialService {
  private url = 'https://localhost:7067/api/Material';

  constructor(private http: HttpClient) {}

  getMateriais(): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}`);
  }
}
