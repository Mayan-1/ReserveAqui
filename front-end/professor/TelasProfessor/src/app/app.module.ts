import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TelaLoginComponent } from './tela-login/tela-login.component';
import { ListaReservasComponent } from './lista-reservas/lista-reservas.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { TipoReservaComponent } from './tipo-reserva/tipo-reserva.component';
import { ListaReservaMaterialComponent } from './lista-reserva-material/lista-reserva-material.component';
import { FormsModule } from '@angular/forms';
import { CamposReservaSalaComponent } from './campos-reserva-sala/campos-reserva-sala.component';
import { CalendarioComponent } from './calendario/calendario.component';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './interceptors/jwt-interceptor'; // Ajuste o caminho conforme a estrutura do projeto

@NgModule({
  declarations: [
    AppComponent,
    TelaLoginComponent,
    ListaReservasComponent,
    NavbarComponent,
    FooterComponent,
    TipoReservaComponent,
    ListaReservaMaterialComponent,
    CamposReservaSalaComponent,
    CalendarioComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MatCardModule,
    MatDatepickerModule,
    HttpClientModule,
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
