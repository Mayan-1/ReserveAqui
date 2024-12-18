import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-confirmar-email',
  templateUrl: './confirmar-email.component.html',
  styleUrl: './confirmar-email.component.css',
})
export class ConfirmarEmailComponent {
  constructor(private router: Router) {}
  irParaLogin(): void {
    this.router.navigate(['/login']);
  }
}
