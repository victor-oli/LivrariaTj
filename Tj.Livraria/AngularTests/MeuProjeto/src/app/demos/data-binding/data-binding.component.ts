import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-data-binding',
  templateUrl: './data-binding.component.html',
  styles: [
  ]
})
export class DataBindingComponent {
  public clickCount: number = 0;
  public name: string = "";

  addClick() {
    this.clickCount++;
  }
  
  cleanClick() {
    this.clickCount = 0;
  }
}