import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from '../../../core/model/cliente.model';

@Component({
  selector: 'app-listar-cliente',
  templateUrl: './listar-cliente.component.html',
  styleUrls: ['./listar-cliente.component.css']
})
export class ListarClienteComponent implements OnInit {
  public clientes: Cliente[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Cliente[]>(baseUrl + 'api/cliente').subscribe(result => {
      this.clientes = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
