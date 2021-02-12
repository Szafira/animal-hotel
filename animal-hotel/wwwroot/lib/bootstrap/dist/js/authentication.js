// Przykładowe dane użytkowników
const usersJson = {
    1: { "username": "magda_s", "password": "mgS", "jwtToken": "#12398qweWW" },
    2: { "username": "admin", "password": "admin", "jwtToken": "$teproitERT$$%345" },
    3: { "username": "user", "password": "pass", "jwtToken": "rter%%%$ewr324" },
}

// Formularz, do którego przycisku dołączona jest funkcja handleSubmit
const handleSubmit = (username, password) => {
    const filterUser = Object.fromEntries(Object.entries(usersJson).filter(([key, value]) => value.username == username))
    if (Object.keys(filterUser).length === 0) {
        return alert("Nie znaleziono użytkownika o podanym loginie")
    }
    if (Object.values(filterUser)[0].password === password) {
        // Ustawiamy nasz jwtToken w pamięci lokalnej przeglądarki
        localStorage.setItem("jwtToken", Object.values(filterUser)[0].jwtToken)
        console.log("Poprawnie zalogowano")
    // Przerzucamy użytkownika do odpowiedniego endpointa na stronie
    /* window.location.href = "https://localhost:8080/" */;
    } else {
        alert("Podano nieprawidłowe hasło")
    }
}

// WYWOŁANIE FUNKCJI
handleSubmit("magda_s", "mgS")

// W ten sposób można sprawdzić czy masz token w pamięci już
console.log(localStorage.getItem("jwtToken"))


// Funkcja zwraca true jeśli jwtToken istnieje albo false jeśli nie istnieje w pamięci przeglądarki
const isLoggedIn = () => {
    if (localStorage.getItem("jwtToken") !== null) {
        return true
    } else {
        return false
    }
}

// Tę funkcję powinnaś wywoływać na samym początku opdalania każdej podstrony, ona sprawdza czy użytkownik jest wciąż zalogowany i jeśli nie jest to przerzuca go na stronę logowania
const autoRedirect = () => {
    const validLogin = isLoggedIn()
    if (!validLogin && location.pathname !== '/login/') redirect('/login')
    if (validLogin && location.pathname === '/login/') redirect('/')
}

// A tu funkcja do wylogowywania, jeśli nie będzie działać metoda "redirect" to wtedy użyj location.path = "localhost:8080/login"
const logout = () => {
    localStorage.removeItem("jwtToken")
    redirect("/login")
}


