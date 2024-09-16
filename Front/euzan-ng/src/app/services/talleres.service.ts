import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TallerClienteInterface, TallerInterface, TallerPagoInterface } from '../interfaces/talleres';
import { ConexionService } from './conexion.service';

@Injectable({
  providedIn: 'root'
})
export class TalleresService extends ConexionService<TallerInterface>{
  getResourceURL(): string {
    return '/Workshops';
  }
  getHomePage(): string {
    return 'taller';
  }
  getNombre(): string {
    return 'taller';
  }

  constructor(
    protected override httpClient: HttpClient,
    protected override route: Router
  ) {
    super(httpClient, route);
  }
}


@Injectable({
  providedIn: 'root'
})
export class TallerClientesService extends ConexionService<TallerClienteInterface>{
  getResourceURL(): string {
    return '/Workshop_Client';
  }
  getHomePage(): string {
    return 'taller';
  }
  getNombre(): string {
    return 'taller';
  }

  constructor(
    protected override httpClient: HttpClient,
    protected override route: Router
  ) {
    super(httpClient, route);
  }
}



@Injectable({
  providedIn: 'root'
})
export class TalleresPagoService extends ConexionService<TallerPagoInterface>{
  getResourceURL(): string {
    return '/WorkshopRecords';
  }
  getHomePage(): string {
    return 'tallerPago';
  }
  getNombre(): string {
    return 'tallerPago';
  }

  constructor(
    protected override httpClient: HttpClient,
    protected override route: Router
  ) {
    super(httpClient, route);
  }
}