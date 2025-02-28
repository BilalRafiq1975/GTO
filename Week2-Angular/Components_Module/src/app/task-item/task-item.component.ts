// src/app/task-item/task-item.component.ts
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-task-item',
  standalone: false,
  template: `
    <p>{{ task.name }} - {{ task.completed ? 'Done' : 'Pending' }}</p>
    <button (click)="toggleTask()">Toggle</button>
  `
})
export class TaskItemComponent {
  @Input() task: any;
  toggleTask() {
    this.task.completed = !this.task.completed;
  }
}