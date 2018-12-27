import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { MatDialogRef } from '@angular/material';
import {ActivitiesDto} from '../../../../shared/shared';

@Component({
  selector: 'app-addleadactivity',
  templateUrl: './addactivity.component.html',
  styleUrls: ['./addactivity.component.scss']
})

export class AddActivityComponent implements OnInit {

    appointmentForm: FormGroup;
    title: FormControl;
    fromdate: FormControl;
    todate: FormControl;
    activityLocation: FormControl;
    activityStatus: FormControl;
    activitySource: FormControl;
    activityOwner: FormControl;
    notes: FormControl;
    errors: any;
    myControl = new FormControl();
    options: string[] = ['One', 'Two', 'Three'];
    filteredOptions: Observable<string[]>;
    activity:ActivitiesDto=new ActivitiesDto();
    constructor(public dialogRef: MatDialogRef<AddActivityComponent>) { }


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
       this.activityLocation= new FormControl('');
       this.activityStatus= new FormControl('');
      this.activitySource = new FormControl('');
       this.activityOwner= new FormControl('');
       this.notes= new FormControl('');
    }

    addAppointmentForm() { 
        this.appointmentForm = new FormGroup({
             title: this.title,
             fromdate: this.fromdate,
             todate: this.todate,
             activityLocation: this.activityLocation,
             activityStatus: this.activityStatus,
             activitySource: this.activitySource,
             activityOwner: this.activityOwner,
             notes: this.notes,
        });  
    }
    close(){
      
      this.activity.activityTitle=this.appointmentForm.controls["title"].value;
     this.activity.activityStartTime=this.appointmentForm.controls["fromdate"].value;
     this.activity.activityEndTime=this.appointmentForm.controls["todate"].value;
     this.activity.activityLocation=this.appointmentForm.controls["activityLocation"].value;
     this.activity.statusId=this.appointmentForm.controls["activityStatus"].value;
     this.activity.source=this.appointmentForm.controls["activitySource"].value;
     this.activity.activityOwner=this.appointmentForm.controls["activityOwner"].value;
      this.dialogRef.close(this.activity);
  }
}