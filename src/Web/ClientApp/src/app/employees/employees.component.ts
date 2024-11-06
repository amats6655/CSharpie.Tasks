import {Component, TemplateRef, OnInit} from '@angular/core';
import {
  DepartmentsClient, EmployeesClient, PositionsClient,
  DepartmentDto, EmployeeDto, EmployeeBriefDto, PositionDto,
  CreateDepartmentCommand, UpdateDepartmentCommand,
  CreateEmployeeCommand, UpdateEmployeeCommand,
  CreatePositionCommand, UpdatePositionCommand
} from "../web-api-client";
import {BsModalRef, BsModalService} from "ngx-bootstrap/modal";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit{
  debug = false;
  employees: EmployeeBriefDto[];
  departments: DepartmentDto[];
  positions: PositionDto[];
  filteredPositions: PositionDto[];

  selectedDepartment: DepartmentDto;
  selectedEmployee: EmployeeDto;
  selectedPosition: PositionDto;
  deletedEmployee: EmployeeBriefDto;

  newDepartmentEditor: any = {};
  optionsDepartmentEditor: any = {};
  detailDepartmentEditor: any = {};
  newEmployeeEditor: any = {};
  optionsEmployeeEditor: any = {};
  detailEmployeeEditor: any = {};
  newPositionEditor: any = {};
  optionsPositionEditor: any = {};
  detailPositionEditor: any = {};

  newDepartmentModalRef: BsModalRef;
  optionsDepartmentModalRef: BsModalRef;
  deleteDepartmentModalRef: BsModalRef;
  detailDepartmentModalRef: BsModalRef;
  newEmployeeModalRef: BsModalRef;
  optionsEmployeeModalRef: BsModalRef;
  deleteEmployeeModalRef: BsModalRef;
  detailEmployeeModalRef: BsModalRef;
  newPositionModalRef: BsModalRef;
  optionsPositionModalRef: BsModalRef;
  deletePositionModalRef: BsModalRef;
  detailPositionModalRef: BsModalRef;

  constructor(
    private departmentsClient: DepartmentsClient,
    private employeesClient: EmployeesClient,
    private positionsClient: PositionsClient,
    private modalService: BsModalService,
  ){}

  ngOnInit(): void {
    this.departmentsClient.getDepartments().subscribe(
      result => {
        this.departments = result.departments;
        if(this.departments.length) {
          // this.selectedDepartment = this.departments[0];
        }
      },
      error => console.error(error)
    )
    this.employeesClient.getEmployeesWithPagination(1, 10).subscribe(
      result => {
        this.employees = result.items;

        if(this.employees.length) {
          // this.selectedEmployee = this.employees[0];
        }
      },
      error => console.error(error)
    )
    this.positionsClient.getPositions().subscribe(
      result => {
        this.positions = result.positions;
        if(this.positions.length){
          // this.selectedPosition = this.positions[0];
        }
      },
      error => console.error(error)
    )
  }



  remainingPositions(department: DepartmentDto): number {
    return department.positions.length;
  }
  remainingEmployees(position: PositionDto): number {
    return position.employees.length;
  }
  remainingEmployeesFromDep(department: DepartmentDto): number {
    let count = 0;
    department.positions.forEach((position) => {
      position.employees.forEach(() => {
        count++;
      })
    })
    return count;
  }


  showNewDepartmentModal(template: TemplateRef<any>): void {
    this.newDepartmentModalRef = this.modalService.show(template);
    setTimeout(() => document.getElementById('title').focus(), 250);
  }
  showNewEmployeeModal(template: TemplateRef<any>): void {
    this.newEmployeeModalRef = this.modalService.show(template);
    this.newEmployeeEditor.departmentId = this.selectedDepartment.id;

    this.onDepartmentChange(this.newEmployeeEditor.departmentId);

    this.newEmployeeEditor.positionId = this.selectedPosition.id;
    setTimeout(() => document.getElementById('lastName').focus(), 250);
  }
  showNewPositionModal(template: TemplateRef<any>, department: DepartmentDto): void {
    this.selectedDepartment = department;
    this.newPositionEditor.departmentId = this.selectedDepartment.id;
    this.newPositionModalRef = this.modalService.show(template, this.selectedDepartment);
    setTimeout(() => document.getElementById('title').focus(), 250);
  }


  newDepartmentCancelled(): void {
    this.newDepartmentModalRef.hide();
    this.newDepartmentEditor = {};
  }
  newEmployeeCancelled(): void {
    this.newEmployeeModalRef.hide();
    this.newEmployeeEditor = {};
  }
  newPositionCancelled(): void {
    this.newPositionModalRef.hide();
    this.newPositionEditor = {};
  }

  detailDepartmentCancelled(): void {
    this.detailDepartmentModalRef.hide();
    this.detailDepartmentEditor = {};
  }
  detailEmployeeCancelled(): void {
    this.detailEmployeeModalRef.hide();
    this.detailEmployeeEditor = {};
  }
  detailPositionCancelled(): void {
    this.detailPositionModalRef.hide();
    this.detailPositionEditor = {};
  }


  addDepartment(): void {
    const department = {
      id: 0,
      title: this.newDepartmentEditor.title,
      positions: []
    } as DepartmentDto

    this.departmentsClient.createDepartment(department as CreateDepartmentCommand).subscribe(
      result => {
        department.id = result;
        this.departments.push(department);
        this.selectedDepartment = department;
        this.newDepartmentModalRef.hide();
        this.newDepartmentEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response).errors;

        if(errors && errors.Title) {
          this.newDepartmentEditor.error = errors.Title[0];
        }

        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    )
  }

  addEmployee() {
    const employee = {
      id: 0,
      positionId: this.newEmployeeEditor.positionId,
      firstName: this.newEmployeeEditor.firstName,
      lastName: this.newEmployeeEditor.lastName,
      surName: this.newEmployeeEditor.surName,
      dateOfBirth: this.newEmployeeEditor.dateOfBirth,
    } as EmployeeDto;

    this.employeesClient.createEmployee(employee as CreateEmployeeCommand).subscribe(
      result => {
        employee.id = result;

        this.employeesClient.getEmployeesWithPagination(1, 10).subscribe(
          result => {
            this.employees = result.items;

            if(this.employees.length) {
              // this.selectedEmployee = this.employees[0];
            }
          },
          error => console.error(error)
        )

        this.selectedPosition.employees.push(employee as EmployeeDto);
        this.newEmployeeModalRef.hide();
        this.newEmployeeEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response).errors;
        if(errors && errors.Title) {
          this.newEmployeeEditor.error = errors.Title[0];
        }

        setTimeout(() => document.getElementById('name').focus(), 250);
      },

    );
  }

  addPosition(): void {
    const position = {
      id: 0,
      departmentId: this.newPositionEditor.departmentId,
      title: this.newPositionEditor.title,
      salary: this.newPositionEditor.salary,
      employees: []
    } as PositionDto

    this.positionsClient.createPosition(position as CreatePositionCommand).subscribe(
      result => {
        position.id = result;
        this.selectedDepartment.positions.push(position);
        this.selectedPosition = position;
        this.newPositionModalRef.hide();
        this.newPositionEditor = {};
      },
      error => {
        const errors = JSON.parse(error.response).errors;

        if(errors && errors.Title) {
          this.newDepartmentEditor.error = errors.Title[0];
        }

        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    )
  }


  confirmDeleteDepartment(template: TemplateRef<any>, department: DepartmentDto): void {
    this.selectedDepartment = department;
    this.deleteDepartmentModalRef = this.modalService.show(template);
  }
  deleteDepartmentConfirmed(): void {
    this.departmentsClient.deleteDepartment(this.selectedDepartment.id).subscribe(
      () => {
        this.deleteDepartmentModalRef.hide();
        this.departments = this.departments.filter(e => e.id !== this.selectedDepartment.id);
        this.selectedEmployee = this.departments.length ? this.departments[0] : null;
      },
      error => console.error(error)
    );
  }

  confirmDeleteEmployee(template: TemplateRef<any>, employee: EmployeeDto): void {
    this.deletedEmployee = employee;
    this.deleteEmployeeModalRef = this.modalService.show(template);
  }
  deleteEmployeeConfirmed(): void {
    this.employeesClient.deleteEmployee(this.deletedEmployee.id).subscribe(
      () => {
        this.deleteEmployeeModalRef.hide();
        this.employees = this.employees.filter(e => e.id !== this.deletedEmployee.id);
        this.deletedEmployee = this.employees.length ? this.employees[0] : null;
      },
      error => console.error(error)
    );
  }

  confirmDeletePosition(template: TemplateRef<any>, position: PositionDto): void {
    this.selectedPosition = position;
    this.deletePositionModalRef = this.modalService.show(template);
  }
  deletePositionConfirmed(): void {
    this.positionsClient.deletePosition(this.selectedPosition.id).subscribe(
    () => {
      this.deletePositionModalRef.hide();
      this.positions = this.positions.filter(e => e.id !== this.selectedPosition.id);
      this.selectedPosition = this.positions.length ? this.positions[0] : null;
    },
      error => console.error(error)
    );
  }


  showDepartmentDetailModal(template: TemplateRef<any>, department: DepartmentDto): void {
    this.selectedDepartment = department;
    this.detailDepartmentEditor = {
      ...this.selectedDepartment,
    };

    this.detailDepartmentModalRef = this.modalService.show(template);
  }
  showEmployeeDetailModal(template: TemplateRef<any>, employee: EmployeeDto): void {
    this.selectedEmployee = employee;
    this.detailEmployeeEditor = {
      ...this.selectedEmployee,
    };

    this.onDepartmentChange(this.detailEmployeeEditor.departmentId);

    this.detailEmployeeModalRef = this.modalService.show(template);
  }
  showPositionDetailModal(template: TemplateRef<any>, position: PositionDto): void {
    this.selectedPosition = position;
    this.detailPositionEditor = {
      ...this.selectedPosition,
    }

    this.detailPositionModalRef = this.modalService.show(template);
  }


  updateDepartmentDetails(): void {
    const department = this.detailDepartmentEditor as UpdateDepartmentCommand;
    this.departmentsClient.updateDepartment(this.selectedDepartment.id, department).subscribe(
      () => {
        this.selectedDepartment.title = this.detailDepartmentEditor.title;
        this.detailDepartmentModalRef.hide();
        this.detailDepartmentEditor = {};
      },

      error => console.error(error)
    );
  }
  updateEmployeeDetails(): void {
    const employee = this.detailEmployeeEditor as UpdateEmployeeCommand;
    this.employeesClient.updateEmployee(this.selectedEmployee.id, employee).subscribe(
      () => {
        if (this.selectedEmployee.positionId !== this.detailEmployeeEditor.positionId){
          this.selectedPosition.employees = this.selectedPosition.employees.filter(
            e => e.id !== this.selectedEmployee.id
          );
          const positionIndex = this.positions.findIndex(
            d => d.id === this.detailEmployeeEditor.positionId
          );
          this.selectedEmployee.positionId = this.detailEmployeeEditor.positionId;
          this.positions[positionIndex].employees.push(this.selectedEmployee);
        }

        this.selectedEmployee.dateOfBirth = this.detailEmployeeEditor.dateOfBirth; // this.detailEmployeeEditor.dateOfBirth;
        this.selectedEmployee.firstName = this.detailEmployeeEditor.firstName;
        this.selectedEmployee.lastName = this.detailEmployeeEditor.lastName;
        this.selectedEmployee.surName = this.detailEmployeeEditor.surName;

        this.employeesClient.getEmployeesWithPagination(1, 10).subscribe(
          result => {
            this.employees = result.items;

            if(this.employees.length) {
              this.selectedEmployee = this.employees[0];
            }
          },
          error => console.error(error)
        ),
        this.detailEmployeeModalRef.hide();
        this.detailEmployeeEditor = {};
      },
      error => console.error(error)
    );
  }
  updatePositionDetails(): void {
    const position = this.detailPositionEditor as UpdatePositionCommand;
    this.positionsClient.updatePosition(this.selectedPosition.id, position).subscribe(
      () => {
        this.selectedPosition.title = this.detailPositionEditor.title;
        this.selectedPosition.salary = this.detailPositionEditor.salary;
        this.detailPositionModalRef.hide();
        this.detailPositionEditor = {};
      },

      error => console.error(error)
    );
  }

  onDepartmentChange(departmentId: number): void {
    this.filteredPositions = this.positions.filter(
      position => position.departmentId === departmentId
    );
    this.newEmployeeEditor.positionId = null;
  }
}

