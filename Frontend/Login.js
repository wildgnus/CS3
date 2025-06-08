document.addEventListener('DOMContentLoaded', () => {
    const form = {
        login: document.getElementById('username'),
        password: document.getElementById('password')
    };

    document.querySelector('form').addEventListener('submit', async (e) => {
        e.preventDefault();
        try {
            const response = await fetch('http://localhost:5000/api/login', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    Login: form.login.value,
                    Password: form.password.value
                }),
            });
            const data = await response.json();
            if (data.success) {
                console.log('Login successful');
                // Redirect to main page
                window.location.href = 'main.html'; // Adjust path based on serving method
            } else {
                console.log('Invalid credentials');
                alert('Invalid login or password');
            }
        } catch (error) {
            console.error('Error:', error);
            alert('An error occurred');
        }
    });
});