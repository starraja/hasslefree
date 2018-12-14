import { Component, OnInit, ViewEncapsulation, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

import { fuseAnimations } from '@fuse/animations';
import { HassleService } from '../hasslefree.service';
import { takeUntil } from 'rxjs/internal/operators';

@Component({
    selector: 'lead',
    templateUrl: './lead.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: fuseAnimations
})
export class LeadComponent implements OnInit {
    errorMessage: string;
    leads: any[];
    cols: any[];
    filter: boolean;
    fieldfilter: any[];
    searchFields: any[];
    isLinear = false;
    firstFormGroup: FormGroup;
    secondFormGroup: FormGroup;
    @ViewChild("Firstname") nameField: ElementRef;
    @ViewChild("Leadstage") leadStage: ElementRef;
    @ViewChild('myForm') form: NgForm;
    filteredOptions: Observable<string[]>;
    myControl = new FormControl();
    constructor(private hasslefree: HassleService, private _formBuilder: FormBuilder, private eRef: ElementRef) {
    }
    addComp: boolean;
    ngOnInit() {

        this.firstFormGroup = new FormGroup({
            firstName: new FormControl(),
            lastName: new FormControl(),
            ownerCtrl: new FormControl(),
        });
        console.log(this.firstFormGroup.controls);
        this.searchFields = [
            { value: 'Last name' },
            { value: 'First name' },
            { value: 'Owner' },
            { value: 'Lead stage' },
            { value: 'Job title' },
            { value: 'Tag' },
            { value: 'Department' },
            { value: 'Email' },
            { value: 'Work' },
            { value: 'Mobile' },
            { value: 'Has authority' },
            { value: 'Do not distrub' },
            { value: 'Territory' },
            { value: 'Time zone' },
            { value: 'Address' },
            { value: 'City' },
            { value: 'State' },
            { value: 'Zipcode' },
            { value: 'Country' },
            { value: 'Facebook' },
            { value: 'Twitter' },
            { value: 'Linkedin' },
            { value: 'Company name' },
            { value: 'Company city' },
            { value: 'Company state' },
            { value: 'Company zipcode' },
            { value: 'Company country' },
            { value: 'Number of employees' },
            { value: 'Company annual revenue' },
            { value: 'Company website' },
            { value: 'Industry type' },
            { value: 'Business type' },
            { value: 'Deal name' },
            { value: 'Deal value' },
            { value: 'Deal expected close date' },
            { value: 'Product' },
            { value: 'Source' },
            { value: 'campaign' },
            { value: 'Medium' },
            { value: 'Keyword' },

            // { value: 'Last name'},
            // { value: 'Lead stage', id: 'leadStage' },
            //  { value: 'Location', id: 3 },
            //  { value: 'Social profiles', id: 4 },
            //  { value: 'Company information', id: 5 },
            //  { value: 'Deal information', id: 6 },
            //  { value: 'Source information', id: 7 },
            //  { value: 'System information', id: 8 },
            //  { value: 'Additional information', id: 9 }


            // {value:'New Leads',id:2},
            // {value:'Unassigned Leads',id:3},
            // {value:'All Leads',id:4},
            // {value:'Recently Modified',id:5},
            // {value:'Recently Imported',id:6},
            // {value:'My Territory Leads',id:7},
            // {value:'Never Contacted',id:8},
            // {value:'Never Contacted via chat',id:9},
            // {value:'Created by others',id:10},
            // {value:'Hot Leads',id:11},
            // {value:'Warm Leads',id:12},
            // {value:'Cold Leads',id:13}
        ];
        this.fieldfilter = [
            { id: '1', value: 'Territory' },
            { id: '2', value: 'Lead stage' },
            { id: '3', value: 'Last contacted time' },
            { id: '4', value: 'Last activity date' },
            { id: '5', value: 'Last assigned at' },
            { id: '6', value: 'Job title' },
            { id: '7', value: 'Mobile' },
            { id: '8', value: 'Department' },
            { id: '9', value: 'Source' },
            { id: '10', value: 'Unqualified reason' },
            { id: '11', value: 'Created by' },
            { id: '12', value: 'Updated by' },
            { id: '13', value: 'Medium' },
            { id: '14', value: 'Campaign' },
            { id: '15', value: 'Has authority' },
            { id: '16', value: 'Do not disturb' },
            { id: '17', value: 'Last seen' },
            { id: '18', value: 'Email status' },
            { id: '19', value: 'Name' },
            { id: '20', value: 'Company name' },
            { id: '21', value: 'Industry type' },
            { id: '22', value: 'Business type' },
            { id: '23', value: 'Number of employees' },
            { id: '24', value: 'Deal name' },
            { id: '25', value: 'Deal value' },
            { id: '26', value: 'Deal expected close date' },
            { id: '27', value: 'Product' },
            { id: '28', value: 'City' },
            { id: '29', value: 'State' },
            { id: '30', value: 'Country' },
            { id: '31', value: 'Company annual revenue' },
            { id: '32', value: 'Company phone' },
            { id: '33', value: 'Company city' },
            { id: '34', value: 'Company state' },
            { id: '35', value: 'Company country' },
            { id: '36', value: 'Company address' },
            { id: '37', value: 'Company zipcode' },
            { id: '38', value: 'Company website' },
            { id: '39', value: 'Time zone' },
            { id: '40', value: 'Keyword' },
            { id: '41', value: 'Zipcode' },
            { id: '42', value: 'Address' },
            { id: '43', value: 'First name' },
            { id: '44', value: 'Last name' },
            { id: '45', value: 'Completed sales campaign' },
            { id: '46', value: 'Active sales campaigns' },
            { id: '47', value: 'Web forms' },
            { id: '49', value: 'Tags' },
            { id: '50', value: 'Import label' },
            { id: '51', value: 'Events' }
        ];
        this.cols = [
            { field: 'id', header: '' },
            { field: 'nameDetails', header: 'NAME' },
            { field: 'score', header: 'LEAD SCORE' },
            { field: 'stage', header: 'LEAD STAGE' },
            { field: 'lastContact', header: 'LAST CONTACT' },
            { field: 'owner', header: 'OWNER' },
            { field: 'email', header: 'EMAIL' },
            { field: 'work', header: 'WORK' }

        ];
        this.getLeads();
        this.filteredOptions = this.myControl.valueChanges
            .pipe(
                startWith(''),
                map(value => this._filter(value))
            );
    }
    private _filter(value: string): any[] {
        const filterValue = value.toLowerCase();

        return this.searchFields.filter(option => option.value.toLowerCase().includes(filterValue));
    }
    selected(event) {
        let id = event.option.value;
        if (id) {
            this.eRef.nativeElement.ownerDocument.getElementById(id).focus();
        }
        console.log(id);
        // console.log(event);
        // this.searchFields.forEach(key => {
        //     if (key.value == event.option.value) {
        //         console.log("executed")
        //     }
        // });
        // if(event.option.value == (this.nameField.nativeElement.id || this.leadStage.nativeElement.id)){
        //     this.nameField.nativeElement.focus()
        // }
    }
    getLeads() {
        this.leads = [
            {
                id: '1',
                nameDetails: {
                    name: 'John Deen Toe',
                    position: 'Sales Manager'
                },
                score: 25,
                stage: 'Demo',
                lastContact: '2 Days Ago',
                images: 'assets/images/ecommerce/a-walk-amongst-friends.jpg',
                owner: 'AAAA',
                email: "yyy",
                work: '(109) 990-33333',
            },
            {
                id: '2',
                nameDetails: {
                    name: 'John Deen Toe',
                    position: 'Sales Manager'
                },
                score: 25,
                stage: 'Demo',
                lastContact: '2 Days Ago',
                images: 'assets/images/ecommerce/a-walk-amongst-friends.jpg',
                owner: 'AAAA',
                email: "yyy",
                work: '(109) 990-33333',
            },
            {
                id: '3',
                nameDetails: {
                    name: 'John Deen Toe',
                    position: 'Sales Manager'
                },
                score: 25,
                stage: 'Demo',
                lastContact: '2 Days Ago',
                images: 'assets/images/ecommerce/a-walk-amongst-friends.jpg',
                owner: 'AAAA',
                email: "yyy",
                work: '(109) 990-33333',
            }
        ];
    }
    get f() {
        return this.firstFormGroup.controls;
    }

}


