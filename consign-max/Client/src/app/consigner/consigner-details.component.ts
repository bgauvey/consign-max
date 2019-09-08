import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { IItem, IState, IConsigner } from '../shared/interfaces';
import { DataService } from '../core/data.service';
import { ValidationService } from '../shared/validation.service';

@Component({
  selector: 'app-consigner-details',
  templateUrl: './consigner-details.component.html',
  styleUrls: ['./consigner-details.component.css']
})
export class ConsignerDetailsComponent implements OnInit {
  consignerForm: FormGroup;
  consigner: IConsigner = {
    firstName: '',
    lastName: '',
    addressLine1: '',
    addressLine2: '',
    emailAddress: '',
    city: '',
    zip: '',
    mobilePhone: '',
    phone: '',
    middleInitial: '',
    commission: 0.6,
    state: null,
    id: -1,
    updateDate: null,
    createDate: null,
    amountDue: 0,
    numConsignments: 0,
    stateId: -1,
    items: []
  };


  states: IState[];
  errorMessage: string;
  deleteMessageEnabled: boolean;
  operationText = 'Insert';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private dataService: DataService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit() {
    const id = +this.route.snapshot.params['id'];
    if (id !== 0) {
      this.operationText = 'Update';
      this.getConsigner(id);
    }

    this.getStates();
    this.buildForm();
    this.consignerForm.markAsPristine();
  }

  buildForm() {
    this.consignerForm = this.formBuilder.group({
      firstName:      [this.consigner.firstName, Validators.required],
      lastName:       [this.consigner.lastName, Validators.required],
      middleInitial:  [this.consigner.middleInitial],
      emailAddress:   [this.consigner.emailAddress, [Validators.required, ValidationService.emailValidator]],
      addressLine1:   [this.consigner.addressLine1, Validators.required],
      addressLine2:   [this.consigner.addressLine2],
      city:           [this.consigner.city, Validators.required],
      stateId:        [this.consigner.stateId, Validators.required]
    });
  }

  getConsigner(id: number) {
    this.dataService.getConsigner(id).subscribe(
      (consigner: IConsigner) => {
        this.consigner = consigner;
        this.consigner.stateId = consigner.state.id;
        console.log(consigner);
        this.buildForm();
      },
      (err: any) => console.log(err)
    );
  }

  getStates() {
    this.dataService
      .getStates()
      .subscribe((states: IState[]) => (this.states = states));
  }

  submit() {
    if (this.consigner.id) {
      this.dataService.updateConsigner(this.consigner).subscribe(
        (consigner: IConsigner) => {
          if (consigner) {
            this.router.navigate(['/consigners']);
          } else {
            this.errorMessage = 'Unable to save consigner';
          }
        },
        (err: any) => console.log(err)
      );
    } else {
      this.dataService.insertConsigner(this.consigner).subscribe(
        (consigner: IConsigner) => {
          if (consigner) {
            this.router.navigate(['/consigners']);
          } else {
            this.errorMessage = 'Unable to add consigner';
          }
        },
        (err: any) => console.log(err)
      );
    }
  }

  cancel(event: Event) {
    event.preventDefault();
    this.router.navigate(['/consigners']);
  }

  delete(event: Event) {
    event.preventDefault();
    this.dataService.deleteConsigner(this.consigner.id).subscribe(
      (status: boolean) => {
        if (status) {
          this.router.navigate(['/consigners']);
        } else {
          this.errorMessage = 'Unable to delete consigner';
        }
      },
      err => console.log(err)
    );
  }
}
