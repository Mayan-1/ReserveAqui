import { Component } from '@angular/core';
import { AuthService } from '../services/auth-service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tela-login',
  templateUrl: './tela-login.component.html',
  styleUrls: ['./tela-login.component.css'], // Corrigido styleUrls
})
export class TelaLoginComponent {
  email: string = '';
  senha: string = '';
  isLoading: boolean = false; // Indicador de carregamento

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    if (this.email.trim() && this.senha.trim()) {
      if (!this.validateEmail(this.email)) {
        alert('Por favor, insira um e-mail válido.');
        return;
      }

      this.isLoading = true; // Ativa o carregamento

      this.authService.login(this.email, this.senha).subscribe({
        next: () => {
          this.isLoading = false; // Desativa o carregamento
          alert('Login realizado com sucesso!');
          this.router.navigate(['/home']); // Redireciona após o login
        },
        error: (err) => {
          this.isLoading = false; // Desativa o carregamento
          const errorMessage = this.getErrorMessage(err);
          alert(errorMessage);
          console.error(err);
        },
      });
    } else {
      alert('Por favor, preencha todos os campos!');
    }
  }

  private validateEmail(email: string): boolean {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
  }

  private getErrorMessage(error: any): string {
    if (error.status === 401) {
      return 'Credenciais inválidas. Tente novamente.';
    } else if (error.status === 500) {
      return 'Credenciais inválidas. Tente novamente.';
    } else {
      return 'Credenciais inválidas. Tente novamente.';
    }
  }
}
