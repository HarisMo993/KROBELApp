import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Person } from 'src/app/shared/person.model';
import { PersonService } from 'src/app/shared/person.service';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
})
export class PersonFormComponent implements OnInit {

  constructor(
    public service: PersonService,
    private toastr: ToastrService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {}

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0) {
      this.insertRecord(form);
    } else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm) {
    this.service.postPerson().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Person');
      },
      err => {
        console.log(err);
        this.toastr.error('Error occurred while submitting', 'Person');
      },
      () => {
        this.service.getPersons();
      }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putPerson().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Updated successfully', 'Person');
      },
      err => {
        console.log(err);
        this.toastr.error('Error occurred while updating', 'Person');
      },
      () => {
        this.service.getPersons();
      }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Person();
  }

  getDefaultBirthDate(): string {
    const defaultDate = new Date();
    return this.formatBirthDate(defaultDate);
  }

  formatBirthDate(date: Date): string {
    return this.datePipe.transform(date, 'yyyy-MM-dd') ?? '';
  }

  updateBirthDate(dateString: string) {
    const dateParts = dateString.split('T')[0].split('-');
    const year = parseInt(dateParts[0], 10);
    const month = parseInt(dateParts[1], 10) - 1;
    const day = parseInt(dateParts[2], 10);
    this.service.formData.birthDate = new Date(year, month, day);
  }
}
