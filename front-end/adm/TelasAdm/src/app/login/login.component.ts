import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth-service/auth-service.service';

@Component({
  selector: 'app-tela-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'], // Corrigido styleUrls
})
export class LoginComponent {
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
            this.router.navigate(['/home']);
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
