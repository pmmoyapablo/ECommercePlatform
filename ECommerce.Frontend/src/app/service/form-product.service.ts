import { Injectable } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";

@Injectable({
  providedIn: "root",
})
export class FormProductService {
  constructor(private formBuilder: FormBuilder) {}

  newFormProduct(d?:any) {
    return this.formBuilder.group({
      id: [d?.id, Validators.nullValidator],
    });
  }
}  