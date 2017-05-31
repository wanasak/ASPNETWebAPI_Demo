// Requesting for token
url: http://localhost:52760/token
body: username=wanasak@gmail.com&password=password1234&grant_type=password

// Using token authen
header: Authorization: Bearer {token}
url: http://localhost:52760/api/employees
