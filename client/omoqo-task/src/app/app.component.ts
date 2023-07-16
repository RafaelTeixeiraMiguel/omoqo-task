import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ShipAddEditComponent } from './common/dialog/ship-add-edit/ship-add-edit.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'omoqo-task';

  constructor(private _dialog: MatDialog){

  }

  openAddEditEmpForm(){
    this._dialog.open(ShipAddEditComponent)
  }
}
