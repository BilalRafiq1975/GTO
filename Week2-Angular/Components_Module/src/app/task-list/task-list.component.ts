// src/app/task-list/task-list.component.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-task-list',
  standalone: false,
  template: `
    <h2>Task List</h2>
    <app-task-filter (filterChange)="updateFilter($event)"></app-task-filter>
    <ul>
      <li *ngFor="let task of filteredTasks">
        <app-task-item [task]="task"></app-task-item>
      </li>
    </ul>
  `
})
export class TaskListComponent {
  tasks = [
    { name: 'Write code', completed: false },
    { name: 'Test app', completed: true },
    { name: 'Deploy', completed: false }
  ];
  filteredTasks = this.tasks;
  filter = 'all';

  updateFilter(status: string) {
    this.filter = status;
    if (status === 'completed') {
      this.filteredTasks = this.tasks.filter(task => task.completed);
    } else if (status === 'pending') {
      this.filteredTasks = this.tasks.filter(task => !task.completed);
    } else {
      this.filteredTasks = this.tasks;
    }
  }
}