import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {ActivatedRoute, Router, RouterModule} from '@angular/router';
import { UserService } from '../../../services/user/user.service';
import { VisitService } from '../../../services/visit/visit.service';
import { Visit } from '../../../models/visit.model';

@Component({
  selector: 'app-add-visit',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    RouterModule
  ],
  templateUrl: './add-visit.component.html',
  styleUrls: ['./add-visit.component.css']
})
export class AddVisitComponent implements OnInit {
  visitForm: FormGroup;
  patientId: string = '';
  organizationId: string = '';

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    protected router: Router,
    private userService: UserService,
    private visitService: VisitService
  ) {
    this.visitForm = this.fb.group({
      date: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      this.patientId = params['patientId'];
      this.organizationId = params['organizationId'];
    });
  }

  onSubmit() {
    if (this.visitForm.valid) {
      const formValue = this.visitForm.value;
      const visit: Visit = {
        id: '',
        date: formValue.date,
        description: formValue.description,
        createdByUserId: this.userService.user.id,
        patientId: this.patientId,
        organizationId: this.organizationId
      };

      this.visitService.createVisit(visit).subscribe({
        next: () => {
          console.log('Visit created successfully');
          this.router.navigate(['/patient', this.patientId]).then();
        },
        error: (error) => {
          console.error('Error creating visit', error);
        }
      });
    }
  }
}
