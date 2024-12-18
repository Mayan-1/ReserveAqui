import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';
import { ListaSalasComponent } from './lista-salas.component';

@NgModule({
  declarations: [ListaSalasComponent],
  imports: [
    BrowserModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    MatSortModule,
    MatIconModule,
    MatToolbarModule,
    NgxMaskDirective,
    NgxMaskPipe,
  ],
  providers: [],
  exports: [ListaSalasComponent],
})
export class ListaSalasModule {}
