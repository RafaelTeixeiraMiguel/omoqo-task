import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ShipAddEditComponent } from './ship/components/modal/ship-add-edit/ship-add-edit.component';
import { ShipService } from './ship/ship.service';
import {ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { Guid } from 'guid-typescript';
import { CoreService } from './core/core.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  displayedColumns: string[] = ['id', 'name', 'code', 'length', 'width', 'action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;


  constructor(private _dialog: MatDialog, private _shipService: ShipService, private _coreService: CoreService){

  }

  ngOnInit(): void {
    this.getShipList();
  }

  addNewShip(){
    const dialogRef  = this._dialog.open(ShipAddEditComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        this.getShipList();
      }
    })
  }

  updateShip(data: any){
    const dialogRef  = this._dialog.open(ShipAddEditComponent, {
      data,
    });
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        this.getShipList();
      }
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getShipList(){
    this._shipService.listAll().subscribe({
      next: (res) => {
        console.log(res);
        this.dataSource = new MatTableDataSource(res.ships);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  deleteShip(id: Guid){
    this._shipService.delete(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('Ship deleted');
        this.getShipList();
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
