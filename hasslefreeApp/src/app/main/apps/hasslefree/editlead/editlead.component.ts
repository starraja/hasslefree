import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-editlead',
  templateUrl: './editlead.component.html',
  styleUrls: ['./editlead.component.scss']
})
export class EditleadComponent implements OnInit {

    myControl = new FormControl();
    options: string[] = ['One', 'Two', 'Three'];
    filteredOptions: Observable<string[]>;
    selected = 'scheduled';
    source = 'lead';
    owner = 'raj';

    constructor() { }

    ngOnInit() {
        this.filteredOptions = this.myControl.valueChanges
	      .pipe(
	        startWith(''),
	        map(value => this._filter(value))
	      );
    }

    private _filter(value: string): string[] {
      const filterValue = value.toLowerCase();

      return this.options.filter(option => option.toLowerCase().includes(filterValue));
    }
}