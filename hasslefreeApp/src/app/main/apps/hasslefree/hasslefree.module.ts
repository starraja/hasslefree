import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
    MatButtonModule, MatDatepickerModule, MatDialogModule, MatFormFieldModule, MatIconModule, MatInputModule, MatSlideToggleModule, MatToolbarModule, MatTooltipModule
,MatOptionModule,MatSelectModule,MatStepperModule,MatAutocompleteModule,MatCheckboxModule,MatRadioModule,MatChipsModule
} from '@angular/material';
import { ColorPickerModule } from 'ngx-color-picker';
import { CalendarModule as AngularCalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { PrimeModule } from '../../../prime.module'
import { FuseSharedModule } from '@fuse/shared.module';
import {  FuseSidebarModule } from '@fuse/components';

import { FuseConfirmDialogModule } from '@fuse/components';
import { HassleService } from './hasslefree.service';
import { LeadComponent } from './lead/lead.componenet';
import { ReactiveFormsModule } from '@angular/forms';



const routes: Routes = [
    {
        path: '**',
        component: LeadComponent,
        children: [],
        
    }
];

@NgModule({
    declarations: [
        LeadComponent
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
        AngularCalendarModule.forRoot({
            provide: DateAdapter,
            useFactory: adapterFactory
        }),
        ColorPickerModule,

        FuseSharedModule,
        FuseConfirmDialogModule,
        FuseSidebarModule
    ],
  
  providers      : [
        HassleService
    ],
})
export class HasslefreeModule {
}
