import { ModuleWithProviders } from '@angular/core';

export interface IConsigner {
  id: number;
  lastName: string;
  middleInitial: string;
  firstName: string;
  addressLine1: string;
  addressLine2: string;
  city: string;
  state: IState;
  zip: string;
  mobilePhone: string;
  phone: string;
  emailAddress: string;
  commission: number;
  updateDate: Date;
  createDate: Date;
  items: IItem[];
  amountDue: number;
  numConsignments: number;
  stateId: number;
}

export interface IState {
  id: number;
  abbreviation: string;
  name: string;
}

export interface IItem {
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
  salePrice: number;
  updateDate: Date;
  createDate: Date;
}

export interface IRouting {
  routes: ModuleWithProviders;
  components: any[];
}

export interface IPagedResults<T> {
  totalRecords: number;
  results: T;
}

export interface IConsignerResponse {
  status: boolean;
  consigner: IConsigner;
}
