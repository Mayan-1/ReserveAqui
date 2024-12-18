import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { ListaReservasComponent } from './lista-reservas/lista-reservas.component';
import { ListaReservaMaterialComponent } from './lista-reserva-material/lista-reserva-material.component';
import { TipoReservaComponent } from './tipo-reserva/tipo-reserva.component';
import { CamposReservaSalaComponent } from './campos-reserva-sala/campos-reserva-sala.component';
import { CalendarioComponent } from './calendario/calendario.component';
import { TelaLoginComponent } from './tela-login/tela-login.component';
import { EditarSalaComponent } from './editar-sala/editar-sala.component';
import { CalendarioEditarReservaSalaComponent } from './calendario-editar-reserva-sala/calendario-editar-reserva-sala.component';
import { ConfirmarEmailComponent } from './confirmar-email/confirmar-email.component';
import { CalendarioMaterialComponent } from './calendario-material/calendario-material.component';
import { CamposReservaMaterialComponent } from './campos-reserva-material/campos-reserva-material.component';
import { EditarMaterialComponent } from './editar-material/editar-material.component';
import { CalendarioEditarReservaMaterialComponent } from './calendario-editar-reserva-material/calendario-editar-reserva-material.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: TelaLoginComponent },
  { path: 'email-confirmado', component: ConfirmarEmailComponent },
  { path: 'salas', component: ListaReservasComponent },
  { path: 'materiais', component: ListaReservaMaterialComponent },
  { path: 'tipos', component: TipoReservaComponent },
  { path: 'campos-sala', component: CamposReservaSalaComponent },
  { path: 'calendario', component: CalendarioComponent },
  { path: 'editar-reserva-sala/:id', component: EditarSalaComponent },
  {
    path: 'calendario-editar-reserva-sala/:id',
    component: CalendarioEditarReservaSalaComponent,
  },
  {
    path: 'calendario-material',
    component: CalendarioMaterialComponent,
  },
  {
    path: 'campos-material',
    component: CamposReservaMaterialComponent,
  },
  {
    path: 'editar-reserva-material/:id',
    component: EditarMaterialComponent,
  },
  {
    path: 'calendario-editar-reserva-material/:id',
    component: CalendarioEditarReservaMaterialComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
