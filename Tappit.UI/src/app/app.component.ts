import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PersonAddEditComponent } from './person-add-edit/person-add-edit.component';
import { PersonService } from './services/person.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CoreService } from './core/core.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = [
  
    'firstName',
    'lastName',
    'IsValid',
    'IsEnabled',
    'IsAuthorised',
    'FavouriteSports'
    ,
  ];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _dialog: MatDialog,
    private _personService: PersonService,
    private _coreService: CoreService
  ) {}

  ngOnInit(): void {
    this.getPeopleList();
  }

  openAddEditPersonForm() {
    const dialogRef = this._dialog.open(PersonAddEditComponent);
    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getPeopleList();
        }
      },
    });
  }

  getPeopleList() {
    this._personService.getPersonList().subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      error: console.log,
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deletePerson(id: number) {
    this._personService.deletePerson(id).subscribe({
      next: (res) => {
        this._coreService.openSnackBar('Person Deleted!', 'done');
        this.getPeopleList();
      },
      error: console.log,
    });
  }

  openEditForm(data: any) {
    const dialogRef = this._dialog.open(PersonAddEditComponent, {
      data,
    });

    dialogRef.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getPeopleList();
        }
      },
    });
  }
}
