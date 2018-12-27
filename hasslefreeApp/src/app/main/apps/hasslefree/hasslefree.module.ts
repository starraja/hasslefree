import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
    MatButtonModule, MatDatepickerModule, MatDialogModule, MatFormFieldModule, MatIconModule, MatInputModule, MatSlideToggleModule, MatToolbarModule, MatTooltipModule
,MatOptionModule,MatSelectModule,MatStepperModule,MatAutocompleteModule,MatCheckboxModule,MatRadioModule,MatChipsModule, MatTableModule
} from '@angular/material';
import { ColorPickerModule } from 'ngx-color-picker';
import { CalendarModule as AngularCalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { PrimeModule } from '../../../prime.module'
import { FuseSharedModule } from '@fuse/shared.module';
import { FuseSidebarModule } from '@fuse/components';
import { FuseConfirmDialogModule } from '@fuse/components';
import { HassleService } from './hasslefree.service';
import { LeadComponent } from './lead/lead.componenet';
import { ReactiveFormsModule } from '@angular/forms';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { AppointmentComponent } from './appointment/appointment.component';
import { EditleadComponent } from './editlead/editlead.component';
import { AddLeadComponent } from './add-lead/add-lead.component';
import { AddActivityComponent } from './addactivity/addactivity.component';

const routes: Routes = [
    {
        path: 'lead',
        component: LeadComponent
    }, 
    {
        path: 'addlead',
        component: AddLeadComponent
    },
    {
        path: 'addlead/:leadId',
        component: AddLeadComponent
    },
    {
        path: 'appointment',
        component: AppointmentComponent
    },
    {
        path: 'edit-appointment',
        component: EditleadComponent
    }
];

@NgModule({
    declarations: [
        LeadComponent,
        AppointmentComponent,
        EditleadComponent,
        AddActivityComponent,
        AddLeadComponent
    ],
    imports: [
        RouterModule.forChild(routes),
        MatButtonModule,
        MatDatepickerModule,
        MatDialogModule,
        MatFormFieldModule,
        MatIconModule,
        MatInputModule,
        MatSlideToggleModule,
        MatToolbarModule,
        MatTooltipModule,
        PrimeModule,
        MatOptionModule,
        MatSelectModule,
        MatStepperModule,
        MatAutocompleteModule,
        MatCheckboxModule,
        MatRadioModule,
        ReactiveFormsModule,
        MatChipsModule,
        MatTableModule,
        AngularCalendarModule.forRoot({
            provide: DateAdapter,
            useFactory: adapterFactory
        }),
        ColorPickerModule,

        FuseSharedModule,
        FuseConfirmDialogModule,
        FuseSidebarModule, 
        OwlDateTimeModule, 
        OwlNativeDateTimeModule,
    ],
  
    providers      : [
        HassleService
    ],
    entryComponents: [AddActivityComponent]
})
export class HasslefreeModule {
}
