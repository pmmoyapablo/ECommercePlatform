import { Injectable } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";

@Injectable({
  providedIn: "root",
})
export class FormEmployeeService {
  constructor(private formBuilder: FormBuilder) {}

  newFormEmployee(d?:any) {
    return this.formBuilder.group({
      id: [d?.id, Validators.nullValidator],
    });
  }
}  