// src/app/task-filter/task-filter.component.ts
import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-task-filter',
  standalone: false,
  template: `
    <button (click)="filterTasks('all')">All</button>
    <button (click)="filterTasks('completed')">Completed</button>
    <button (click)="filterTasks('pending')">Pending</button>
  `
})
export class TaskFilterComponent {
  @Output() filterChange = new EventEmitter<string>();

  filterTasks(status: string) {
    this.filterChange.emit(status);
  }
}