import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { StateDebouncer } from '@clr/angular/data/datagrid/providers/state-debouncer.provider';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { IConsigner, IPagedResults, IConsignerResponse, IState } from '../shared/interfaces';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = '/api/';
  baseConsignersUrl = this.baseUrl + 'consignors';
  baseStatesUrl = this.baseUrl + 'states';

  constructor(private http: HttpClient) {}

  getConsigners(): Observable<IConsigner[]> {
    return this.http.get<IConsigner[]>(this.baseConsignersUrl).pipe(
      map(consigners => {
        this.calculateConsignersAmountDue(consigners);
        return consigners;
      }),
      catchError(this.handleError)
    );
  }

  getConsignersPage(
    page: number,
    pageSize: number
  ): Observable<IPagedResults<IConsigner[]>> {
    return this.http
      .get<IConsigner[]>(`${this.baseConsignersUrl}/page/${page}/${pageSize}`, {
        observe: 'response'
      })
      .pipe(
        map(res => {
          // Need to observe response in order to get to this header (see {observe: 'response'} above)
          const totalRecords = +res.headers.get('x-inlinecount');
          const consigners = res.body as IConsigner[];
          this.calculateConsignersAmountDue(consigners);
          return {
            results: consigners,
            totalRecords: totalRecords
          };
        }),
        catchError(this.handleError)
      );
  }

  getConsigner(id: string): Observable<IConsigner> {
    return this.http
      .get<IConsigner>(this.baseConsignersUrl + '/' + id)
      .pipe(catchError(this.handleError));
  }

  insertConsigner(consigner: IConsigner): Observable<IConsigner> {
    return this.http
      .post<IConsignerResponse>(this.baseConsignersUrl, consigner)
      .pipe(
        map(data => {
          console.log('insertConsigner status: ' + data.status);
          return data.consigner;
        }),
        catchError(this.handleError)
      );
  }

  updateConsigner(consigner: IConsigner): Observable<IConsigner> {
    return this.http
      .put<IConsignerResponse>(
        this.baseConsignersUrl + '/' + consigner.id,
        consigner
      )
      .pipe(
        map(data => {
          console.log('updateConsigner status: ' + data.status);
          return data.consigner;
        }),
        catchError(this.handleError)
      );
  }

  deleteConsigner(id: string): Observable<boolean> {
    return this.http
      .delete<boolean>(this.baseConsignersUrl + '/' + id)
      .pipe(catchError(this.handleError));
  }

  calculateConsignersAmountDue(consigners: IConsigner[]) {
    for (const consigner of consigners) {
      if (consigner && consigner.items) {
        let total = 0;
        consigner.numConsignments = consigner.items.length;

        for (const item of consigner.items) {
          total += item.salePrice || 0;
        }
        consigner.amountDue = total;
      }
    }
  }

  getStates(): Observable<IState[]> {
    return this.http
      .get<IState[]>(this.baseStatesUrl)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return Observable.throw(errMessage);
    }
    return Observable.throw(error || 'ASP.NET Core server error');
  }
}
