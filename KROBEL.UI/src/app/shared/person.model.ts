export class Person {
  id: number = 0;
  firstName: string = '';
  lastName: string = '';
  birthDate: Date = new Date();
  phoneNumber: string = '';
  email: string = '';
  gender: string = '';
  createdDate: Date = new Date();
  modifiedDate: Date = new Date();
  isActive: boolean = true;

  constructor() {
  }
}
