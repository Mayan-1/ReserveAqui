import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tela-confirma-email',
  templateUrl: './tela-confirma-email.component.html',
  styleUrl: './tela-confirma-email.component.css',
})
export class TelaConfirmaEmailComponent {
  constructor(private router: Router) {}
  goToLogin(): void {
    this.router.navigate(['']);
  }
}
