import { Component, ViewEncapsulation,OnInit } from '@angular/core';
import { ActivatedRoute  } from '@angular/router';

import { FuseConfigService } from '@fuse/services/config.service';
import { fuseAnimations } from '@fuse/animations';
import {UserService,UserMailConfirmDto} from '../../shared/shared';
@Component({
    selector     : 'mail-confirm',
    templateUrl  : './mail-confirm.component.html',
    styleUrls    : ['./mail-confirm.component.scss'],
    encapsulation: ViewEncapsulation.None,
    animations   : fuseAnimations
})
export class MailConfirmComponent implements OnInit
{
    mailconfirm:UserMailConfirmDto=new UserMailConfirmDto();
   
 
    /**
     * Constructor
     *
     * @param {FuseConfigService} _fuseConfigService
     */
    constructor(
        private _fuseConfigService: FuseConfigService,
        private route:ActivatedRoute ,
        private userService:UserService   
    )
    {
        
        // Configure the layout
        this._fuseConfigService.config = {
            layout: {
                navbar   : {
                    hidden: true
                },
                toolbar  : {
                    hidden: true
                },
                footer   : {
                    hidden: true
                },
                sidepanel: {
                    hidden: true
                }
            }
        };
    }
    ngOnInit(): void {
        this.mailconfirm.token=this.route.snapshot.queryParamMap.get("token");
        this.mailconfirm.userName=this.route.snapshot.queryParamMap.get("username");
        this.userService.verifyEmail(this.mailconfirm).subscribe(res=>{
        });
    }
}
