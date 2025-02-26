let token = null;

function showMessage(msg, type = 'error') {
    const message = document.getElementById('message');
    message.textContent = msg;
    message.className = `message ${type}`;
    setTimeout(() => message.className = 'message', 3000); // Hide after 3s
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
                `;
                taskList.appendChild(li);
            });
        }
    } catch (error) {
        showMessage('Error loading tasks: ' + error.message);
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