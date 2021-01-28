import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListarClienteComponent } from './listar-cliente/listar-cliente.component';
import { RegistrarClienteComponent } from './registrar-cliente/registrar-cliente.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'listar',
    component: ListarClienteComponent,
  },
  {
    path: 'registrar',
    component: RegistrarClienteComponent,
  },
];

@NgModule({
  declarations: [ListarClienteComponent, RegistrarClienteComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
})
export class ClienteModule {}
