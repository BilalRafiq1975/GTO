import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: false,
  template: `
    <h1>Task Manager</h1>
    <app-task-list></app-task-list>
  `
})
export class AppComponent {}  // ✅ Remove standalone: true
