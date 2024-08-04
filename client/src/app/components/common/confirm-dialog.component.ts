import {MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";
import {Component, Inject} from "@angular/core";

@Component({
  selector: 'app-confirm-dialog',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  template: `
    <div class="custom-dialog-container">
    <h2 mat-dialog-title>{{data.title}}</h2>
    <mat-dialog-content>{{data.message}}</mat-dialog-content>
    <mat-dialog-actions>
      <button mat-flat-button color="warn" [mat-dialog-close]="false">No</button>
      <button mat-flat-button color="primary" [mat-dialog-close]="true" cdkFocusInitial>Yes</button>
    </mat-dialog-actions>
    </div>
  `,
  styles: [`
    .custom-dialog-container {
      background-color: whitesmoke;
      color: #000000;
    }

    mat-dialog-content {
      color: #000;
    }

    h2 {
      color: #3f51b5;
    }

    mat-dialog-content {
      color: #ffffff;
    }

    mat-dialog-actions {
      justify-content: flex-end;
    }

    button {
      margin-left: 8px;
    }

  `]
})
export class ConfirmDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {title: string, message: string}
  ) {}
}
