import { DialogRef } from '@angular/cdk/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Guid } from 'guid-typescript';
import { CoreService } from 'src/app/core/core.service';
import { Ship } from 'src/app/ship/model/ship.model';
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
      name: ['', Validators.required],
      code: ['', Validators.required],
      width: ['', Validators.required],
      length: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.shipForm.patchValue(this.data);
  }

  onFormSubmit(){
    if (!this.shipForm) {
      return;
    }

    if (!this.shipForm.valid) {
      this.shipForm.markAllAsTouched();
      return;
    }

    const ship: Ship = this.shipForm.value;

    if(this.data){
      this.updateShip(ship);
    } else {
      this.addNewShip(ship);
    }
  }

  addNewShip(ship : Ship) : void {
    this._shipService.create(ship).subscribe({
      next: (val : any) => {
        this._coreService.openSnackBar('Ship created');
        this._dialogRef.close(true);
      },
      error: (err : any) => {
        console.error(err);
      }
    });
  }

  updateShip(ship : Ship) : void {
    this._shipService.update(ship).subscribe({
      next: (val : any) => {
        this._coreService.openSnackBar('Ship updated');
        this._dialogRef.close(true);
      },
      error: (err : any) => {
        console.error(err);
      }
    });
  }
}
