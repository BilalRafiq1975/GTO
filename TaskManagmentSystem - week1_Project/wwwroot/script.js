let token = null;
let editingTaskId = null;

function showMessage(msg, type = 'error') {
    const message = document.getElementById('message');
    message.textContent = msg;
    message.className = `message ${type}`;
    setTimeout(() => message.className = 'message', 3000);
}

function showSignup() {
    document.getElementById('signup-card').style.display = 'block';
    document.getElementById('login-card').style.display = 'none';
}

function showLogin() {
    document.getElementById('signup-card').style.display = 'none';
    document.getElementById('login-card').style.display = 'block';
}

async function signup() {
    const username = document.getElementById('signup-username').value;
    const email = document.getElementById('signup-email').value;
    const password = document.getElementById('signup-password').value;
    const signupBtn = document.getElementById('signup-btn');

    signupBtn.disabled = true;
    signupBtn.textContent = 'Signing Up...';

    try {
        const response = await fetch('/api/user/signup', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ username, email, password })
        });
        const data = await response.json();
        if (response.ok) {
            showMessage('Signup successful! Please log in.', 'success');
            showLogin();
            document.getElementById('signup-username').value = '';
            document.getElementById('signup-email').value = '';
            document.getElementById('signup-password').value = '';
        } else {
            showMessage(data.detail || 'Signup failed');
        }
    } catch (error) {
        showMessage('Error: ' + error.message);
    } finally {
        signupBtn.disabled = false;
        signupBtn.innerHTML = '<i class="fas fa-arrow-right"></i> Sign Up';
    }
}

async function login() {
    const email = document.getElementById('login-email').value;
    const password = document.getElementById('login-password').value;
    const loginBtn = document.getElementById('login-btn');

    loginBtn.disabled = true;
    loginBtn.textContent = 'Logging In...';

    try {
        const response = await fetch('/api/user/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password })
        });
        const data = await response.json();
        if (response.ok) {
            token = data.token;
            document.getElementById('auth-section').style.display = 'none';
            document.getElementById('task-section').style.display = 'block';
            showMessage('Logged in successfully!', 'success');
            loadTasks();
        } else {
            showMessage(data.detail || 'Login failed');
        }
    } catch (error) {
        showMessage('Error: ' + error.message);
    } finally {
        loginBtn.disabled = false;
        loginBtn.innerHTML = '<i class="fas fa-arrow-right"></i> Login';
    }
}

async function addTask() {
    const title = document.getElementById('task-title').value;
    const desc = document.getElementById('task-desc').value;
    const due = document.getElementById('task-due').value;
    const addBtn = document.getElementById('add-task-btn');

    addBtn.disabled = true;
    addBtn.textContent = 'Adding...';

    try {
        const response = await fetch('/api/task', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({ title, description: desc, dueDate: due + 'T00:00:00' })
        });
        if (response.ok) {
            showMessage('Task added successfully!', 'success');
            loadTasks();
            document.getElementById('task-title').value = '';
            document.getElementById('task-desc').value = '';
            document.getElementById('task-due').value = '';
        } else {
            showMessage('Failed to add task');
        }
    } catch (error) {
        showMessage('Error: ' + error.message);
    } finally {
        addBtn.disabled = false;
        addBtn.innerHTML = '<i class="fas fa-plus"></i> Add Task';
    }
}

async function loadTasks() {
    try {
        const response = await fetch('/api/task', {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        const tasks = await response.json();
        const taskList = document.getElementById('task-list');
        taskList.innerHTML = '';
        if (tasks.length === 0) {
            taskList.innerHTML = '<li>No tasks yet!</li>';
        } else {
            tasks.forEach(task => {
                const li = document.createElement('li');
                li.innerHTML = `
                    <span>${task.title} - ${task.description || 'No description'} (Due: ${new Date(task.dueDate).toLocaleDateString()})</span>
                    <div class="task-actions">
                        <button class="edit-btn" onclick="editTask(${task.id}, '${task.title}', '${task.description || ''}', '${task.dueDate.split('T')[0]}')"><i class="fas fa-edit"></i> Edit</button>
                        <button class="delete-btn" onclick="deleteTask(${task.id})"><i class="fas fa-trash"></i> Delete</button>
                    </div>
                `;
                taskList.appendChild(li);
            });
        }
    } catch (error) {
        showMessage('Error loading tasks: ' + error.message);
    }
}

function editTask(taskId, title, description, dueDate) {
    editingTaskId = taskId;
    document.getElementById('edit-task-id').value = taskId;
    document.getElementById('edit-task-title').value = title;
    document.getElementById('edit-task-desc').value = description;
    document.getElementById('edit-task-due').value = dueDate;
    document.getElementById('edit-form').style.display = 'block';
    document.getElementById('task-form').style.display = 'none';
}

async function updateTask() {
    const taskId = document.getElementById('edit-task-id').value;
    const title = document.getElementById('edit-task-title').value;
    const desc = document.getElementById('edit-task-desc').value;
    const due = document.getElementById('edit-task-due').value;
    const updateBtn = document.getElementById('update-task-btn');

    updateBtn.disabled = true;
    updateBtn.textContent = 'Saving...';

    try {
        const response = await fetch(`/api/task/${taskId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({ id: taskId, title, description: desc, dueDate: due + 'T00:00:00' })
        });
        if (response.ok) {
            showMessage('Task updated successfully!', 'success');
            loadTasks();
            cancelEdit();
        } else {
            showMessage('Failed to update task');
        }
    } catch (error) {
        showMessage('Error: ' + error.message);
    } finally {
        updateBtn.disabled = false;
        updateBtn.innerHTML = '<i class="fas fa-save"></i> Save';
    }
}

function cancelEdit() {
    editingTaskId = null;
    const editForm = document.getElementById('edit-form');
    const taskForm = document.getElementById('task-form');

    if (!editForm) console.error("Edit form not found!");
    if (!taskForm) console.error("Task form not found!");

    if (editForm) editForm.style.display = 'none';
    if (taskForm) taskForm.style.display = 'block';
}

async function deleteTask(taskId) {
    if (!confirm('Are you sure you want to delete this task?')) return;

    try {
        const response = await fetch(`/api/task/${taskId}`, {
            method: 'DELETE',
            headers: { 'Authorization': `Bearer ${token}` }
        });
        if (response.ok) {
            showMessage('Task deleted successfully!', 'success');
            loadTasks();
        } else {
            showMessage('Failed to delete task');
        }
    } catch (error) {
        showMessage('Error: ' + error.message);
    }
}

function logout() {
    token = null;
    document.getElementById('auth-section').style.display = 'block';
    document.getElementById('task-section').style.display = 'none';
    showSignup();
    showMessage('Logged out successfully!', 'success');
}

// Initial setup
showSignup();