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
import { MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtInterceptor } from './interceptors/jwt-interceptor';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component'; // Ajuste o caminho conforme a estrutura do projeto
import { MatDialogModule } from '@angular/material/dialog';
import { MainComponent } from './main/main.component';
import { provideToastr, ToastrModule } from 'ngx-toastr';
import {
  BrowserAnimationsModule,
  provideAnimations,
} from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { EditarSalaComponent } from './editar-sala/editar-sala.component';
import { CalendarioEditarReservaSalaComponent } from './calendario-editar-reserva-sala/calendario-editar-reserva-sala.component';
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
    DeleteDialogComponent,
    MainComponent,
    EditarSalaComponent,
    CalendarioEditarReservaSalaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MatCardModule,
    MatDatepickerModule,
    HttpClientModule,
    MatDialogModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    MatIconModule,
    MatNativeDateModule,
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    provideAnimations(),
    provideToastr(),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
