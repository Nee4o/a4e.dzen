
async function CreateUser(userName, userPass, userMail) {
    if (userName == "") {
        alert("Введите хотя бы имя пользователя!");
        return;
    }    
    const response = await fetch("api/dzenapi", {
        method: "POST",
        headers: {
            "Accept": "application/json", "Content-Type":
                "application/json"
        },
        body: JSON.stringify({
            login: userName,
            password: userPass,
            email: userMail,
            role: "user"
        })
    });
    if (response.ok === true) {
        const user = await response.json();
        alert("Регистрация успешна! " + user.login);
    }
    else {
        alert("такой пользователь уже существует!");
    }
}

async function Login(username, userpass) {
    const response = await fetch("/api/dzenapi/"+username+"/"+userpass , {
        method: "Get",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        alert("Успешно!");
    }
    else {
        alert("ничего не найдено");
    }
}
function InitialFunction() {
    document.getElementById("submitBTN").addEventListener("click", e => {
        e.preventDefault();
        const form = document.forms["regForm"];
        const username = form.elements["nameTB"].value;
        const userpass = form.elements["passTB"].value;
        const usermail = form.elements["mailTB"].value;
        CreateUser(username, userpass, usermail);
    });   
}
function LoginFunction() {   
    document.getElementById("logsubmitBTN").addEventListener("click", e => {
        e.preventDefault();
        const form = document.forms["logForm"];
        const username = form.elements["nameTB"].value;
        const userpass = form.elements["passTB"].value;
        Login(username, userpass);
    });
}