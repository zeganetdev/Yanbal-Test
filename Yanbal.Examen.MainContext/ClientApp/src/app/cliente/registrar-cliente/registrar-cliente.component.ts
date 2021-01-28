import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { ClienteService } from '../../../core/services/cliente.services';

@Component({
  selector: 'app-registrar-cliente',
  templateUrl: './registrar-cliente.component.html',
  styleUrls: ['./registrar-cliente.component.css']
})
export class RegistrarClienteComponent implements OnInit, OnDestroy {
  private unsubcribe$ = new Subject();
  form: FormGroup;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private clienteService: ClienteService,

) { }

  ngOnInit() {
    this.buildForm();
  }

  ngOnDestroy(): void {
    this.destroySubscribe();
  }

  private destroySubscribe(): void {
    this.unsubcribe$.next();
    this.unsubcribe$.complete();
  }
  private buildForm(): void {
    this.form = this.formBuilder.group({
      nombres: ['', Validators.required],
      apellidos: ['', Validators.required],
      correo: ['', [Validators.required, Validators.email, Validators.pattern]],
      fechaNacimiento: [''],
      direccion: ['']
    });
  }

  public save(): void {
    console.log(this.form.value);
    alert('aa');
  }

}
