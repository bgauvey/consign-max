import { Component, OnInit } from '@angular/core';
import { DataService } from '../core/data.service';
import { IConsigner, IPagedResults } from '../shared/interfaces';
import { DataFilterService } from '../core/data-filter.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  title: string;
  consigners: IConsigner[] = [];
  filteredConsigners: IConsigner[] = [];

  totalRecords = 0;
  pageSize = 10;

  constructor(private dataService: DataService,
    private dataFilter: DataFilterService,
    private router: Router, ) {}

  ngOnInit() {
    this.title = 'Customers';
    this.getConsignersPage(1);
  }

  filterChanged(filterText: string) {
    if (filterText && this.consigners) {
      const props = [
        'firstName',
        'lastName',
        'address',
        'city',
        'state.name',
        'amountDue'
      ];
      this.filteredConsigners = this.dataFilter.filter(
        this.consigners,
        props,
        filterText
      );
    } else {
      this.filteredConsigners = this.consigners;
    }
  }

  pageChanged(page: number) {
    this.getConsignersPage(page);
  }

  getConsignersPage(page: number) {
    this.dataService
      .getConsignersPage((page - 1) * this.pageSize, this.pageSize)
      .subscribe(
        (response: IPagedResults<IConsigner[]>) => {
          this.consigners = this.filteredConsigners = response.results;
          this.totalRecords = response.totalRecords;
        },
        (err: any) => console.log(err),
        () => console.log('getConsignersPage() retrieved consigners')
      );
  }

  onEdit(consigner: IConsigner) {
    this.router.navigate(['consigner-details', consigner.id]);
  }

  onDelete(user: any) {}
}
