import { Component, OnInit } from '@angular/core';
import { ResponceList } from './models/response_list.model'
import { ResponceObject } from './models/response_object.model'
import { EmployeeService } from './service/employee.service'
import { FormEmployeeService } from './service/form-employee.service'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Employee } from './models/employee.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Prueba Amaris';
  employees: Employee[] = [];
  employee: Employee | undefined;
  searchForm!: FormGroup;
  
  constructor(private employeeService: EmployeeService,
    private formEmployeeService: FormEmployeeService) {
    this.searchForm = this.formEmployeeService.newFormEmployee(this.searchForm);
  }

  ngOnInit() {
    this.loadEmployees();
  }

  onSubmit(){
     const employeeForm = this.searchForm.value;
     console.log('Formulario:', employeeForm);
     this.findEmployee(employeeForm.id);

     if(this.employee != null)
     {
      let employeeSelected = this.employees.filter(emp => emp.id == this.employee?.id);
      this.employees = employeeSelected;
     }
  }

  private loadEmployees(): void {
    this.employeeService.getAllEmployees().subscribe({
      next: (data: ResponceList) => {
        this.employees = data.Data;
      },
      error: (error) => {
        console.error('Error al obtener la lista de empleados:', error);
      },
    });
  }

  private findEmployee(id: string): void {
    this.employeeService.getOneEmployee(id).subscribe({
      next: (data: ResponceObject) => {
        this.employee = data.Data;
      },
      error: (error) => {
        console.error('Error al obtener el empleado:', error);
      },    
    });
  }
}
