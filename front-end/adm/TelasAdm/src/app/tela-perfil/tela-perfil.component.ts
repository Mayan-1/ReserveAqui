import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth-service/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tela-perfil',
  templateUrl: './tela-perfil.component.html',
  styleUrls: ['./tela-perfil.component.css'],
})
export class TelaPerfilComponent implements OnInit {
  administrador: any = null; // Substitua `any` pelo modelo correto, se existir

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    const administradorId = this.authService.getIdAdministrador();
    if (administradorId) {
      this.authService.getAdministrador(administradorId).subscribe({
        next: (data) => {
          this.administrador = data;
        },
        error: (err) => {
          console.error('Erro ao buscar informações do administrador:', err);
        },
      });
    }
  }

  irParaEditar(id: number): void {
    this.router.navigate(['/editar-adm', id]);
  }
}
