import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient) { }
  public isLoading = new BehaviorSubject(false);

 
  getDiscountList(){
    return this.http.get("https://localhost:44379/sales/getdiscountlist");
  }

  saveSalesEvent(salesEventDTO: any){
    return this.http.post("https://localhost:44379/sales/savesalesevent", salesEventDTO);
  }
}
