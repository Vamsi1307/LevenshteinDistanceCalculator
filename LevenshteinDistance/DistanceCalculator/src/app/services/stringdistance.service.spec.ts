import { TestBed } from '@angular/core/testing';

import { StringdistanceService } from './stringdistance.service';

describe('StringdistanceService', () => {
  let service: StringdistanceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StringdistanceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
