import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { Cliente } from '../model/cliente.model';

@Injectable({ providedIn: 'root' })
export class ClienteService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL')
    private baseUrl: string) { }

  public getListCliente(): Observable<Cliente[]> {
    return this.http
      .get(`${this.baseUrl}api/cliente`)
      .pipe(
        map((response: Cliente[]) => {
          return response;
        })
      );
  }
}
