import { Component } from '@angular/core';
import { AuthService } from '../services/auth-service/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tela-login',
  templateUrl: './tela-login.component.html',
  styleUrls: ['./tela-login.component.css'], // Corrigido styleUrls
})
export class TelaLoginComponent {
  email: string = '';
  senha: string = '';
  isLoading: boolean = false; // Indicador de carregamento

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  onSubmit() {
    if (this.email.trim() && this.senha.trim()) {
      if (!this.validateEmail(this.email)) {
        this.toastr.error('Por favor insira um email válido!', 'Erro');
        return;
      }

      this.isLoading = true; // Ativa o carregamento

      this.authService.login(this.email, this.senha).subscribe({
        next: () => {
          this.isLoading = false; // Desativa o carregamento
          this.toastr.success('Redirecionando para home!', 'Sucesso', {
            timeOut: 2000,
            progressBar: true,
            progressAnimation: 'increasing',
          });
          setTimeout(() => {
            this.router.navigate(['/sala']);
          }, 2000);
        },
        error: (err) => {
          this.isLoading = false; // Desativa o carregamento
          const errorMessage = this.getErrorMessage(err);
          console.error(err);
        },
      });
    } else {
      this.toastr.error('Por favor preencha todos os campos', 'Erro');
    }
  }

  private validateEmail(email: string): boolean {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailPattern.test(email);
  }

  private getErrorMessage(error: any): any {
    if (error.status === 401) {
      return this.toastr.error('Credenciais inválidas.', 'Erro');
    } else if (error.status === 500) {
      return this.toastr.error('Credenciais inválidas.', 'Erro');
    } else {
      return this.toastr.error('Credenciais inválidas.', 'Erro');
    }
  }
}
