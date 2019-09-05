import { TestBed } from '@angular/core/testing';

import { ConsignorServiceService } from './consignor-service.service';

describe('ConsignorServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ConsignorServiceService = TestBed.get(ConsignorServiceService);
    expect(service).toBeTruthy();
  });
});
