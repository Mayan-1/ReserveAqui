import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { ListaReservasComponent } from './lista-reservas/lista-reservas.component';
import { ListaReservaMaterialComponent } from './lista-reserva-material/lista-reserva-material.component';
import { TipoReservaComponent } from './tipo-reserva/tipo-reserva.component';
import { CamposReservaSalaComponent } from './campos-reserva-sala/campos-reserva-sala.component';
import { CalendarioComponent } from './calendario/calendario.component';
import { TelaLoginComponent } from './tela-login/tela-login.component';

const routes: Routes = [
  {
    path: '',
    component: TelaLoginComponent,
  },
  {
    path: 'home',
    component: NavbarComponent,
    children: [{ path: '', component: ListaReservasComponent }],
  },
  {
    path: 'materiais',
    component: NavbarComponent,
    children: [{ path: '', component: ListaReservaMaterialComponent }],
  },
  {
    path: 'tipos',
    component: NavbarComponent,
    children: [{ path: '', component: TipoReservaComponent }],
  },
  {
    path: 'campos-sala',
    component: NavbarComponent,
    children: [{ path: '', component: CamposReservaSalaComponent }],
  },
  {
    path: 'calendario',
    component: NavbarComponent,
    children: [{ path: '', component: CalendarioComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
