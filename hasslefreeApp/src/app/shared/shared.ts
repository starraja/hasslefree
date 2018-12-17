import { ActivityService } from './services/activity.service';
import { LeadService } from  './services/lead.service';
import { NoteService } from  './services/note.service';
import { UserService,API_BASE_URL } from  './services/user.service';
import {ActivitiesDto,IActivitiesDto} from './models/activitiesDto';
import {CreateUserDto,ICreateUserDto} from './models/createUserDto';
import {IIdentityError,IdentityError} from './models/identityError';
import {LeadDto,ILeadDto} from './models/leadDto';
import {INotesDto,NotesDto} from './models/notesDto';
import {IUserDto,UserDto} from './models/userDto';
import {IUserMailConfirmDto,UserMailConfirmDto} from './models/userMailConfirmDto';

import { AuthGuard} from './AuthGuard';
import{AuthInterceptor} from './auth.interceptor';

export {
    UserService,
    ActivityService,
    LeadService,
    NoteService,
    UserDto,
    CreateUserDto,
    AuthGuard,
    AuthInterceptor,
    UserMailConfirmDto,
    ActivitiesDto,
    LeadDto,
    NotesDto,
    API_BASE_URL
}