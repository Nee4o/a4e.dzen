async function Login(username, userpass) {
    const response = await fetch("/api/dzenapiuser/" + username + "/" + userpass, {
        method: "Get",
        headers: {"Accept": "application/json"}
    });
    if (response.ok == true) {
        let user = await response.json();
        document.cookie = "id=" + user.id;
        alert("Успешно!");
    } else {
        alert("ничего не найдено");
    }
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