import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Person } from './person.model';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'http://localhost:7002/api/Person'
  formData: Person = new Person();
  list: Person[];

  postPerson() {
    return this.http.post(this.baseURL+'/InsertPerson', this.formData);
  }

  putPerson() {
    return this.http.put(this.baseURL+'/UpdatePerson', this.formData);
  }

  deletePerson(id: number) {
    return this.http.delete(`${this.baseURL}/DeletePerson/${id}`);
  }

  getPersons() {
    this.http.get(this.baseURL+'/GetAllPersons')
        .toPromise()
        .then(res => this.list = res as Person[]);
  }
}
