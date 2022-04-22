async function CreateUser(userName, userPass, userMail) {
    if (userName == "") {
        alert("Введите хотя бы имя пользователя!");
        return;
    }
    const response = await fetch("api/dzenapiuser", {
        method: "Post",
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
