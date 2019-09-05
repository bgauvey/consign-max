import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StateDebouncer } from '@clr/angular/data/datagrid/providers/state-debouncer.provider';

@Injectable({
  providedIn: 'root'
})
export class ConsignorServiceService {

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<Consignor>('/api/consignors');
  }

  get(id: number) {
    return this.http.get<Consignor>('/api/consignors/' + id);
  }

  update(consignor: Consignor) {

  }
}

export interface Consignor {
  id: number;
  lastName: string;
  middleInitial: string;
  firstName: string;
  addressLine1: string;
  addressLine2: string;
  city: string;
  state: State;
  zip: string;
  mobilePhone: string;
  phone: string;
  emailAddress: string;
  commission: number;
  updateDate: Date;
  createDate: Date;
  Items: Item[];
}

export interface State {
  id: number;
  abbreviation: string;
  name: string;
}

export interface Item {
  id: number;
  consignorId: number;
  description: string;
  askingPrice: number;
  minimumPrice: number;
  endingPrice: number;
  commission: number;
  listingFee: number;
  saleDayLimit: number;
  saleDate: Date;
  updateDate: Date;
  createDate: Date;
}
