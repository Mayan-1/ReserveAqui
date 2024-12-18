import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Angular-Teste';

  isLoginPage: boolean = true;
  isConfirmEmailPage: boolean = true;
  isAdmRegisterPage: boolean = true;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Verifica a URL atual
        this.isLoginPage = this.router.url === '/login';
        this.isConfirmEmailPage = this.router.url === '/email-confirmado';
        this.isAdmRegisterPage = this.router.url === '/cadastro-adm';
        console.log('isLoginPage:', this.isLoginPage); // Debug para o console
      }
    });
  }
}
