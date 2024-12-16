import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'TelasProfessor';

  isLoginPage: boolean = true;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Verifica a URL atual
        this.isLoginPage = this.router.url === '/login';
        console.log('isLoginPage:', this.isLoginPage); // Debug para o console
      }
    });
  }
}
