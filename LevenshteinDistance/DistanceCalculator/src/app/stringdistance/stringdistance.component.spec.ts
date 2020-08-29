import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StringdistanceComponent } from './stringdistance.component';

describe('StringdistanceComponent', () => {
  let component: StringdistanceComponent;
  let fixture: ComponentFixture<StringdistanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StringdistanceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StringdistanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
