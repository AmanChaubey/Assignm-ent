import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'project';
  public entryForm: FormGroup;
  public discountList = [];

  constructor(private formBuilder: FormBuilder,
    private appService: AppService) {

  }


  ngOnInit(): void {
    this.initForm();
    this.getDiscountList();
  }


  // Init form
  initForm() {
    return this.entryForm = this.formBuilder.group({
      id: [0, Validators.required],
      discountId: [0, Validators.required],
      discountAmount: [0, Validators.required],
      eventPrice: [0, Validators.required],
      startDate: [new Date(), Validators.required],
      endDate: [new Date(), Validators.required],
      isActive: [false, Validators.required],
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.entryForm.controls; }


  // Get discouunt list from DB
  getDiscountList() {
    this.appService.getDiscountList().subscribe((result: any) => {
      if (result !== null && result.length > 0) {
        this.discountList = result;
      }
    })
  }

  
  // Get discouunt list from DB
  saveSalesEvent() {
    this.appService.saveSalesEvent(this.entryForm.value).subscribe((result: any) => {
      if (result !== null && result.length > 0) {
        this.discountList = result;
      }
    })
  }


}
