/// <reference path="prime.module.ts" />
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';
import { MatMomentDateModule } from '@angular/material-moment-adapter';
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { TranslateModule } from '@ngx-translate/core';
import 'hammerjs';
import { PrimeModule } from 'app/prime.module'

import { FuseModule } from '@fuse/fuse.module';
import { FuseSharedModule } from '@fuse/shared.module';
import { FuseNavigationModule } from '@fuse/components';
import {
    FuseProgressBarModule, FuseSidebarModule, FuseThemeOptionsModule,
    FuseSearchBarModule, FuseShortcutsModule
} from '@fuse/components';
import {
    MatButtonModule, MatIconModule, MatToolbarModule,
    MatDividerModule, MatListModule, MatSlideToggleModule,
    MatMenuModule, MatAutocompleteModule, MatInputModule,
    MatCheckboxModule, MatFormFieldModule
} from '@angular/material';
import { fuseConfig } from 'app/fuse-config';
import { FuseConfigService } from '@fuse/services/config.service';
import { FakeDbService } from 'app/fake-db/fake-db.service';
import { AppComponent } from 'app/app.component';
import { AppStoreModule } from 'app/store/store.module';
import {
    ContentComponent, FooterComponent, NavbarComponent,
    QuickPanelComponent, ToolbarComponent, LayoutComponent
} from './layout/layout';
import {
    LoginComponent, ForgotPasswordComponent, MailConfirmComponent,
    RegisterComponent, ResetPasswordComponent
} from './authentication/authentication';
// import { LayoutModule } from 'app/layout/layout.module';
import { AuthGuard } from './shared/shared';
const appRoutes: Routes = [
    {
        path: 'auth/login',
        component: LoginComponent
    },
    {
        path: 'auth/forgot-password',
        component: ForgotPasswordComponent
    },
    {
        path: 'auth/mail-confirm',
        component: MailConfirmComponent
    },
    {
        path: 'auth/register',
        component: RegisterComponent
    },
    {
        path: 'auth/reset-password',
        component: ResetPasswordComponent
    },
    {
        path: 'apps',
        component: LayoutComponent,
        loadChildren: './main/apps/apps.module#AppsModule',
        canActivate: [AuthGuard]
    },
    {
        path: '**',
        redirectTo: 'auth/login'
    }
];

@NgModule({
    declarations: [
        AppComponent,
        ContentComponent,
        FooterComponent,
        NavbarComponent,
        QuickPanelComponent,
        ToolbarComponent,
        LayoutComponent,
        LoginComponent,
        ForgotPasswordComponent,
        MailConfirmComponent,
        RegisterComponent,
        ResetPasswordComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        PrimeModule,
        RouterModule.forRoot(appRoutes),

        TranslateModule.forRoot(),
        InMemoryWebApiModule.forRoot(FakeDbService, {
            delay: 0,
            passThruUnknownUrl: true
        }),

        // Material moment date module
        MatMomentDateModule,

        // Material
        MatInputModule,
        MatButtonModule,
        MatIconModule,
        MatIconModule,
        MatToolbarModule,
        MatDividerModule,
        MatListModule,
        MatSlideToggleModule,
        MatMenuModule,
        MatAutocompleteModule,
        MatCheckboxModule,
        MatFormFieldModule,
        // Fuse modules
        FuseModule.forRoot(fuseConfig),
        FuseSharedModule,
        FuseProgressBarModule,
        FuseNavigationModule,
        FuseSidebarModule,
        FuseThemeOptionsModule,
        FuseSearchBarModule,
        FuseShortcutsModule,

        // App modules

        AppStoreModule
    ],
    providers: [AuthGuard, FuseConfigService],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {
}
