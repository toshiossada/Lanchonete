import { TestBed } from '@angular/core/testing';

import { AppHttpService } from './app-http.service';

describe('AppHttpService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AppHttpService = TestBed.get(AppHttpService);
    expect(service).toBeTruthy();
  });
});
