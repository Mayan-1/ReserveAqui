import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SalaService {
  private url = 'https://localhost:7067/api/Sala';

  constructor(private http: HttpClient) {}

  getSalas(): Observable<any[]> {
    return this.http.get<any[]>(`${this.url}`);
  }
}
