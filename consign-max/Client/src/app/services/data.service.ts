import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { StateDebouncer } from '@clr/angular/data/datagrid/providers/state-debouncer.provider';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ConsignorServiceService {
  baseUrl = '/api/';
  baseConsignersUrl = this.baseUrl + 'consignors';
  baseStatesUrl = this.baseUrl + 'states';

  constructor(private http: HttpClient) {}

  getConsigners(): Observable<IConsignor[]>  {
    return this.http.get<IConsignor[]>(this.baseConsignersUrl)
    .pipe(
           map(consigners => {
               this.calculateCustomersOrderTotal(consigners);
               return consigners;
           }),
           catchError(this.handleError)
        );
  }

  get(id: number): Observable<IConsignor> {
    return this.http.get<IConsignor>(this.baseConsignersUrl + id);
  }

  update(consignor: IConsignor) {

  }

  calculateConsignersOrderTotal(consigners: IConsignor[]) {
    for (let consigner of consigners) {
        if (consigner && consigner.items) {
            let total = 0;
            for (let item of consigner.items) {
                total += (item.askingPrice * item.quantity);
            }
            consigner.orderTotal = total;
        }
    }
  }

  getStates(): Observable<IState[]> {
    return this.http.get<IState[]>(this.baseStatesUrl)
        .pipe(
            catchError(this.handleError)
        );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      let errMessage = error.error.message;
      return Observable.throw(errMessage);
    }
    return Observable.throw(error || 'ASP.NET Core server error');
  }
}

export interface IConsignor {
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
  updateDate: Date;
  createDate: Date;
}
