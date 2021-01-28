export interface Cliente {
  id?: string;
  nombres?: string;
  apellidos?: string;
  correo?: string;
  fechaNacimiento?: Date;
  direccion?: string;
  activo?: boolean;
  fechaRegistro?: Date;
}
