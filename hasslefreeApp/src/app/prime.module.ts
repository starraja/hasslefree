import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { DataTableModule } from 'primeng/datatable';
import { TreeTableModule } from 'primeng/treetable';
import { FileUploadModule } from 'primeng/fileupload';

import { DialogModule } from 'primeng/dialog';
import { TabViewModule } from 'primeng/tabview';
import { CalendarModule } from 'primeng/calendar';
import { MultiSelectModule } from 'primeng/multiselect';
import { SpinnerModule } from 'primeng/spinner';
import { InputMaskModule } from 'primeng/inputmask';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { GalleriaModule } from 'primeng/galleria';
import { CarouselModule } from 'primeng/carousel';
import { ConfirmationService } from 'primeng/api';
import { EditorModule } from 'primeng/editor';
import { ListboxModule } from 'primeng/listbox';
import { CheckboxModule } from 'primeng/checkbox'

const PRIME_MODULES = [
    TableModule,
    DataTableModule,
    TreeTableModule,
    FileUploadModule,

            DialogModule,
            TabViewModule,
            CalendarModule,
            MultiSelectModule,
            SpinnerModule,
            InputMaskModule,
            ConfirmDialogModule,
            GalleriaModule,
            CarouselModule,
            EditorModule,
    ListboxModule,
    CheckboxModule
];

const PRIME_PROVIDERS = [
    ConfirmationService
];

@NgModule({
    imports: PRIME_MODULES,
    exports: [PRIME_MODULES],
    providers: [PRIME_PROVIDERS]
})
export class PrimeModule { }
