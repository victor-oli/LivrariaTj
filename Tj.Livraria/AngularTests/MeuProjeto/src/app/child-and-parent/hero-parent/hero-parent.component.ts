import { Component, OnInit } from '@angular/core';
import { HEROS } from '../hero';

@Component({
  selector: 'app-hero-parent',
  templateUrl: './hero-parent.component.html',
  styles: [
  ]
})
export class HeroParentComponent {
  heros = HEROS;
  master = 'Master';
}