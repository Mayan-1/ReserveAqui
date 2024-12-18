import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { Administrador } from '../../models/admnistrador';
import { AdministradorEdicaoDto } from '../../models/administradorEdicao';

export interface LoginResponse {
  token: string;
  refreshToken: string;
  expiration: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://localhost:7067/api/Auth';
  private apiUrlAdm = 'https://localhost:7067/api/Administrador';

  constructor(private http: HttpClient) {}

  /**
   * Realiza o login do usuário e armazena os tokens.
   * @param email Email do usuário
   * @param password Senha do usuário
   * @returns Observable<LoginResponse>
   */
  login(email: string, password: string): Observable<LoginResponse> {
    return this.http
      .post<LoginResponse>(`${this.apiUrl}/login`, { email, password })
      .pipe(
        tap((response) => {
          // Armazena os tokens no localStorage
          localStorage.setItem('jwtToken', response.token);
          localStorage.setItem('refreshToken', response.refreshToken);
          localStorage.setItem('tokenExpiration', response.expiration);
        })
      );
  }

  cadastro(admininstrador: Administrador): Observable<any> {
    return this.http.post<any>(`${this.apiUrlAdm}`, admininstrador);
  }

  getAdministrador(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrlAdm}/${id}`);
  }

  atualizarAdministrador(
    id: number,
    admininistrador: AdministradorEdicaoDto
  ): Observable<any> {
    return this.http.put<any>(`${this.apiUrlAdm}/${id}`, admininistrador);
  }

  /**
   * Realiza o logout do usuário e limpa os tokens armazenados.
   */
  logout(): void {
    localStorage.removeItem('jwtToken');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('tokenExpiration');
  }

  /**
   * Obtém o token JWT armazenado.
   * @returns string | null
   */
  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  /**
   * Verifica se o token JWT está expirado.
   * @returns boolean
   */
  isTokenExpired(): boolean {
    const expiration = localStorage.getItem('tokenExpiration');
    if (!expiration) {
      return true;
    }

    const expirationDate = new Date(expiration);
    return expirationDate <= new Date();
  }

  /**
   * Tenta renovar o token JWT usando o refreshToken.
   * @returns Observable<LoginResponse>
   */
  refreshToken(): Observable<LoginResponse> {
    const refreshToken = localStorage.getItem('refreshToken');
    if (!refreshToken) {
      throw new Error('Refresh token não encontrado');
    }

    return this.http
      .post<LoginResponse>(`${this.apiUrl}/refresh-token`, { refreshToken })
      .pipe(
        tap((response) => {
          // Atualiza os tokens no localStorage
          localStorage.setItem('jwtToken', response.token);
          localStorage.setItem('refreshToken', response.refreshToken);
          localStorage.setItem('tokenExpiration', response.expiration);
        })
      );
  }

  /**
   * Verifica se o usuário está autenticado.
   * @returns boolean
   */
  isAuthenticated(): boolean {
    const token = this.getToken();
    return token !== null && !this.isTokenExpired();
  }

  getIdAdministrador(): number | null {
    const token = localStorage.getItem('jwtToken'); // Ou sessionStorage, conforme sua implementação
    if (token) {
      const decodedToken = JSON.parse(atob(token.split('.')[1])); // Decodifica o token
      return decodedToken.AdministradorId; // Supondo que o idProfessor esteja no token
    }
    return null;
  }
}
