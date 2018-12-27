import { Component, OnInit, ViewEncapsulation, ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { fuseAnimations } from '@fuse/animations';
import { LeadDto, LeadService, ActivitiesDto } from "../../../../shared/shared";
import { takeUntil } from 'rxjs/internal/operators';
import { SelectItem } from 'primeng/api';
import { MatDialog } from '@angular/material';
import { AddActivityComponent } from '../addactivity/addactivity.component';
import { ProductListDto } from 'app/shared/models/productListDto';
import { ContactsDto } from 'app/shared/models/contactsDto';

export interface ActivityElement {
  title: string;
  location: string;
  status: string;
  related: string;
  owner: string;
  activity: string;
}

const ACTIVITY_DATA: ActivityElement[] = [
  { title: 'lorem', location: 'lorem', status: 'lorem', related: 'lorem', owner: 'Selva', activity: '' },
  { title: 'lorem', location: 'lorem', status: 'lorem', related: 'lorem', owner: 'Selva', activity: '' },
  { title: 'lorem', location: 'lorem', status: 'lorem', related: 'lorem', owner: 'Selva', activity: '' },
  { title: 'lorem', location: 'lorem', status: 'lorem', related: 'lorem', owner: 'Raj', activity: '' },
];

@Component({
  selector: 'app-add-lead-component',
  templateUrl: './add-lead.component.html',
  styleUrls: ['./add-lead.component.scss'],
  encapsulation: ViewEncapsulation.None,
  animations: fuseAnimations
})

export class AddLeadComponent implements OnInit {
  basicInfoFormGroup: FormGroup;
  phoneNumbersFormGroup: FormGroup;
  locationFormGroup: FormGroup;
  companyInfoFormGroup: FormGroup;
  contactInfoFormGroup: FormGroup;
  productInfoFormGroup: FormGroup;
  sourceInfoFormGroup: FormGroup;
  isLinear = false;
  lead: LeadDto;
  leadId:number;
  @ViewChild("Firstname") nameField: ElementRef;
  @ViewChild("Leadstage") leadStage: ElementRef;
  @ViewChild('myForm') form: NgForm;
  filteredOptions: Observable<string[]>;
  myControl = new FormControl();
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  separatorKeysCodes: number[] = [ENTER, COMMA];
  fruitCtrl = new FormControl();
  filteredFruits: Observable<string[]>;
  fruits: string[] = ['option'];
  allFruits: string[] = ['Option1', 'Option1', 'Option1', 'Option1', 'Option1'];
  displayedColumns: string[] = ['product', 'quantity', 'rate', 'amount', 'activity'];
  displayedActivityColumns: string[] = ['title', 'location', 'status', 'related', 'owner', 'activity'];
  cols: any[] = [
    { field: 'quantity', header: 'quantity' },
    { field: 'rate', header: 'rate' },
    { field: 'uom', header: 'UOM' },
    { field: 'amount', header: 'amount' },

  ];
  colsactivities:any[]=[
    { field: 'activityTitle', header: 'Title' },
    { field: 'activityLocation', header: 'Activity Location' },
    { field: 'statusId', header: 'Activity Status' },
    { field: 'activityLocation', header: 'Activity Related to' },
    { field: 'activityOwner', header: 'Activity Owner' },
  ];
    activitydataSource = ACTIVITY_DATA;
  productList: ProductListDto[] = [];
  errorMessage: string;
  leads: any[];
  filter: boolean;
  fieldfilter: any[];
  searchFields: any[];

  constructor(private leadService: LeadService, private _formBuilder: FormBuilder,
    private eRef: ElementRef, private location: Location, public dialog: MatDialog,private route:ActivatedRoute) {
    this.filteredFruits = this.fruitCtrl.valueChanges.pipe(
      startWith(null),
      map((fruit: string | null) => fruit ? this._filter1(fruit) : this.allFruits.slice()));
    this.lead = new LeadDto();
    this.lead.productList = [];
    this.lead.activities = [];
  }
  addComp: boolean;
  leadQuality: SelectItem[];
  selecteditem: any;
  ngOnInit() {
    this.initializaAddLeadForm();

   this.leadId=+this.route.snapshot.paramMap.get('leadId');
   if(this.leadId){
    this.leadService.getLeadById(this.leadId).subscribe(res=>{
      this.lead=res;
      this.initializaAddLeadFormWithData();
    });
   
   }

  
   

    this.leadQuality = [
      { label: 'Cold(0-30)', value: { id: 1, name: 'Cold(0-30)' } },
      { label: 'Warm(31-70)', value: { id: 2, name: 'Warm(31-70)' } },
      { label: 'Hot(71-99)', value: { id: 3, name: 'Hot(71-99)' } },
    ];

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
  }
  initializaAddLeadFormWithData(){
    this.basicInfoFormGroup.setValue({
      salutation:this.lead.salutation,
      firstName: this.lead.leadFirstName,
      lastName: this.lead.leadLastName,
      OwnerCtrl: this.lead.leadOwnerExecutiveId,
      leadDate:new Date(this.lead.leadDate.toDateString()),
      email: this.lead.email,
      leadStage: this.lead.salesStage
    });
    this.phoneNumbersFormGroup.setValue({
      workPhone: this.lead.workPhone,
      mobilePhone:this.lead.mobilePhone
    });
    this.locationFormGroup.setValue({
      address1:this.lead.addressLine1,
      address2: this.lead.addressLine2,
      address3: this.lead.addressLine3,
      city: this.lead.city,
      state: this.lead.state,
      country:this.lead.country,
      postalCode: this.lead.postalCode,
    });
    this.companyInfoFormGroup.setValue({
      companyName:this.lead.companyName,
      companyAddress1:this.lead.addressLine1,
      companyAddress2:this.lead.addressLine2,
      companyAddress3: this.lead.addressLine3,
      companyCity: this.lead.companyCity,
      companyState:this.lead.companyState,
      companyCountry: this.lead.companyCountry,
      companyPostalCode:this.lead.companyPostalCode,
      companyWebsite:this.lead.companyWebsite,
      companyTurnover: this.lead.companyTurnover,
      companyIndustryType: this.lead.industryId,
      companyIndustrySubType: this.lead.industrySubTypeId,
    });
    this.contactInfoFormGroup.setValue({
      contactFirstName:this.lead.contact.contactFirstName,
      contactLastName:this.lead.contact.contactLastName,
      contactEmail: this.lead.contact.email,
      contactType: this.lead.contact.contactTypeId,
      contactWorkPhone:this.lead.contact.workPhone,
      contactMobilePhone: this.lead.contact.mobilePhone,
      contactGender:this.lead.contact.genderId,
      contactDepartment: this.lead.contact.department,
      contactDesignation: this.lead.contact.designation
    });
   
    this.sourceInfoFormGroup.setValue({
      leadSource: this.lead.leadSource,
      sourceDescription: this.lead.description,
    });
  }
  initializaAddLeadForm() {

    this.basicInfoFormGroup = this._formBuilder.group({
      salutation: [''],
      firstName: [''],
      lastName: [''],
      OwnerCtrl: [''],
      leadDate: [''],
      email: [''],
      leadStage: ['']
    });
    this.phoneNumbersFormGroup = this._formBuilder.group({
      workPhone: [''],
      mobilePhone: ['']
    });
    this.locationFormGroup = this._formBuilder.group({
      address1: [''],
      address2: [''],
      address3: [''],
      city: [''],
      state: [''],
      country: [''],
      postalCode: [''],
    });
    this.companyInfoFormGroup = this._formBuilder.group({
      companyName: [''],
      companyAddress1: [''],
      companyAddress2: [''],
      companyAddress3: [''],
      companyCity: [''],
      companyState: [''],
      companyCountry: [''],
      companyPostalCode: [''],
      companyWebsite: [''],
      companyTurnover: [''],
      companyPhone: [''],
      companyIndustryType: [''],
      companyIndustrySubType: ['']
    });
    this.contactInfoFormGroup = this._formBuilder.group({
      contactSalutation: [''],
      contactFirstName: [''],
      contactLastName: [''],
      contactEmail: [''],
      contactType: [''],
      contactWorkPhone: [''],
      contactMobilePhone: [''],
      contactGender: [''],
      contactDepartment: [''],
      contactAuthority: [''],
      contactDesignation: ['']
    });
    this.productInfoFormGroup = this._formBuilder.group({
      productName: [''],
      productQuantity: [''],
      productUOM: [''],
      productRate: [''],
      productAmount: [''],
    });
    this.sourceInfoFormGroup = this._formBuilder.group({
      leadSource: [''],
      sourceDescription: [''],
      sourceCompetitorInfo: [''],
      sourceCompetitorName: [''],
      sourceCompetitorAmount: [''],
      sourceRemarks: [''],

    });
  }
  private _filter1(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.allFruits.filter(fruit => fruit.toLowerCase().indexOf(filterValue) === 0);
  }
  addActivity() {
    const dialogRef = this.dialog.open(AddActivityComponent, {
      height: '600px',
      width: '900px'
    });
    dialogRef.afterClosed().subscribe((res:ActivitiesDto)=>{
      this.lead.activities.push(res);
      console.log(this.lead.activities);
    });
  }
  goBack() {
    this.location.back();
  }
  addProduct(type: string) {
      this.lead.productList.push(new ProductListDto({
        "productListId": 0,
        "productId": 0,
        "quantity": this.productInfoFormGroup.controls["productQuantity"].value,
        "uom": this.productInfoFormGroup.controls["productUOM"].value,
        "rate": this.productInfoFormGroup.controls["productRate"].value,
        "discount": 0,
        "taxAmount": 0,
        "amount": this.productInfoFormGroup.controls["productAmount"].value,
        "source": 0,
        "referenceId": 0,
        "flagActive": true,
      }));
      this.productInfoFormGroup.reset();
  }
  deleteProduct(edit:ProductListDto){
    let i=this.lead.productList.indexOf(edit);
    
    this.lead.productList.splice(i,1);
    // this.productInfoFormGroup.controls["productQuantity"].setValue(edit.quantity);
    // this.productInfoFormGroup.controls["productUOM"].setValue(edit.uom);
    // this.productInfoFormGroup.controls["productRate"].setValue(edit.rate);
    // this.productInfoFormGroup.controls["productAmount"].setValue(edit.amount);
  }
  deleteActivity(edit:ActivitiesDto){
    let i=this.lead.activities.indexOf(edit);
    this.lead.activities.splice(i,1);
  }
  submit() {

    this.lead = new LeadDto(
      {
        "leadId": 0,
        "description": "string",
        "salutation": this.basicInfoFormGroup.controls["salutation"].value,
        "leadFirstName": this.basicInfoFormGroup.controls["firstName"].value,
        "leadLastName": this.basicInfoFormGroup.controls["lastName"].value,
        "leadDate": new Date(),
        "email": this.basicInfoFormGroup.controls["email"].value,
        "salesStage": 0,
        "leadOwnerExecutiveId": 0,
        "workPhone": this.phoneNumbersFormGroup.controls["workPhone"].value,
        "mobilePhone": this.phoneNumbersFormGroup.controls["mobilePhone"].value,
        "addressLine1": this.locationFormGroup.controls["address1"].value,
        "addressLine2": this.locationFormGroup.controls["address2"].value,
        "addressLine3": this.locationFormGroup.controls["address3"].value,
        "city": this.locationFormGroup.controls["city"].value,
        "state": this.locationFormGroup.controls["state"].value,
        "postalCode": this.locationFormGroup.controls["postalCode"].value,
        "country": 0,
        "companyName": this.companyInfoFormGroup.controls["companyName"].value,
        "companyAddressLine1": this.companyInfoFormGroup.controls["companyAddress1"].value,
        "companyAddressLine2": this.companyInfoFormGroup.controls["companyAddress2"].value,
        "companyAddressLine3": this.companyInfoFormGroup.controls["companyAddress3"].value,
        "companyCity": this.companyInfoFormGroup.controls["companyCity"].value,
        "companyState": this.companyInfoFormGroup.controls["companyState"].value,
        "companyPostalCode": this.companyInfoFormGroup.controls["companyPostalCode"].value,
        "companyCountry": 0,
        "companyWebsite": this.companyInfoFormGroup.controls["companyWebsite"].value,
        "companyTurnover": this.companyInfoFormGroup.controls["companyTurnover"].value,
        "industryId": this.companyInfoFormGroup.controls["companyIndustryType"].value,
        "industrySubTypeId": this.companyInfoFormGroup.controls["companyIndustrySubType"].value,
        "leadSource": 0,
        "detailDescription": "string",
        "contactId": null,
        "opportunityId": 0,
        "accountId": null,
        "converted": false,
        "flagActive": true,
        "productList": this.lead.productList,
        "activities": this.lead.activities,
      }
    );
    this.lead.contact=new ContactsDto({
      "contactId": 0,
      "accountId": null,
      "contactFirstName": this.contactInfoFormGroup.controls["contactFirstName"].value,
      "contactLastName": this.contactInfoFormGroup.controls["contactLastName"].value,
      "genderId": this.contactInfoFormGroup.controls["contactGender"].value,
      "designation": this.contactInfoFormGroup.controls["contactDesignation"].value,
      "department": this.contactInfoFormGroup.controls["contactDepartment"].value,
      "email":this.contactInfoFormGroup.controls["contactEmail"].value,
      "workPhone": this.contactInfoFormGroup.controls["contactWorkPhone"].value,
      "mobilePhone": this.contactInfoFormGroup.controls["contactMobilePhone"].value,
      "contactTypeId": this.contactInfoFormGroup.controls["contactType"].value,
      "campaignId": null,
      "flagActive": true,
    });
    console.log(this.lead);
    this.leadService.postLead(this.lead).subscribe(res => {
      this.basicInfoFormGroup.reset();
      this.phoneNumbersFormGroup.reset();
      this.locationFormGroup.reset();
      this.companyInfoFormGroup.reset();
      this.contactInfoFormGroup.reset();
      this.productInfoFormGroup.reset();
      this.sourceInfoFormGroup.reset();
      this.lead.productList=[];
      this.lead.activities=[];
      alert("Lead Created");
    });
  }
}
