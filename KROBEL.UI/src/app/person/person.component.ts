import { Component, OnInit } from '@angular/core';
import { PersonService } from '../shared/person.service';
import { Person } from '../shared/person.model';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html'
})
export class PersonComponent implements OnInit {

  constructor(
    public service: PersonService,
    private toastr: ToastrService,
    private datePipe: DatePipe
  ) { }

  ngOnInit(): void {
    this.service.getPersons();
  }

  populateForm(selectedRecord: Person) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deletePerson(id).subscribe(
        res => {
          this.toastr.info("Deleted successfully", 'Person');
        },
        err => {
          console.log(err);
          this.toastr.error('Error occurred while deleting', 'Person');
        },
        () => {
          this.service.getPersons();
        }
      );
    }
  }

  formatBirthDate(date: Date): string {
    return this.datePipe.transform(date, 'yyyy-MM-dd') ?? '';
  }
}
