import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerOrdenesEmprendedorComponent } from './ver-ordenes-emprendedor.component';

describe('VerOrdenesEmprendedorComponent', () => {
  let component: VerOrdenesEmprendedorComponent;
  let fixture: ComponentFixture<VerOrdenesEmprendedorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VerOrdenesEmprendedorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VerOrdenesEmprendedorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
