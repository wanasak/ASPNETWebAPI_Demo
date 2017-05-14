// Requesting for token
url: http://localhost:52760/token
body: username=wanasak@gmail.com&password=Smudger433_&grant_type=password

// Using token authen
header: Authorization: Bearer {token}
url: http://localhost:52760/api/employees