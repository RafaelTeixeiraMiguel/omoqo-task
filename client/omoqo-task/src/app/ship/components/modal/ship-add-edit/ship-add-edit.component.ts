import { DialogRef } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { CoreService } from 'src/app/core/core.service';
import { ShipService } from 'src/app/ship/ship.service';

@Component({
  selector: 'app-ship-add-edit',
  templateUrl: './ship-add-edit.component.html',
  styleUrls: ['./ship-add-edit.component.scss']
})
export class ShipAddEditComponent implements OnInit{
  shipForm: FormGroup;

  constructor(private _fb: FormBuilder, 
              private _shipService: ShipService, 
              private _dialogRef: MatDialogRef<ShipAddEditComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any,
              private _coreService: CoreService){
    this.shipForm = this._fb.group({
      id: Guid,
      name: '',
      code: '',
      width: 0,
      length: 0
    })
  }

  ngOnInit(): void {
    this.shipForm.patchValue(this.data);
  }

  onFormSubmit(){
    if(this.shipForm.valid){
      if(this.data){
        this._shipService.update(this.shipForm.value).subscribe({
          next: (val : any) => {
            this._coreService.openSnackBar('Ship updated');
            this._dialogRef.close(true);
          },
          error: (err : any) => {
            console.error(err);
          }
        });
      } else {
        this._shipService.create(this.shipForm.value).subscribe({
          next: (val : any) => {
            this._coreService.openSnackBar('Ship created');
            this._dialogRef.close(true);
          },
          error: (err : any) => {
            console.error(err);
          }
        });
      }
    }
  }
}
