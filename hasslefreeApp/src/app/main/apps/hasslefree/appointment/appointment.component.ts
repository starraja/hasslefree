import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.scss']
})
export class AppointmentComponent implements OnInit {

    appointmentForm: FormGroup;
    title: FormControl;
    fromdate: FormControl;
    todate: FormControl;
    errors: any;
    myControl = new FormControl();
    options: string[] = ['One', 'Two', 'Three'];
    filteredOptions: Observable<string[]>;

    constructor() { }

    ngOnInit() {
        this.addAppointmentControls();
        this.addAppointmentForm();
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

	  addAppointmentControls() { 
	    this.title = new FormControl('', Validators.required);
	    this.fromdate = new FormControl('', Validators.required);
	    this.todate = new FormControl('', Validators.required);
	  }

	  addAppointmentForm() { 
	      this.appointmentForm = new FormGroup({
	         title: this.title,
	         fromdate: this.fromdate,
	         todate: this.todate,
	      });  
	  }

}
