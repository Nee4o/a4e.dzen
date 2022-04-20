var curUser = new Object();
async function CreateArticle(articleTitle, articleContent, articleBinaryImage, articalDate) {
    let curuserId = GetCurrentUser();
    if (articleTitle == "" || articleContent == "" || articalDate == "") {
        alert("Были обнаружены пустые поля");
        return;
    }
    //alert(GetCurrentUser());
    const response = await fetch("api/dzenapiarticle", {
        method: "Post",
        headers: {
            "Accept": "application/json", "Content-Type":
                "application/json"
        },
        body: JSON.stringify({
            title: articleTitle,
            content: articleContent,
            binary: null,
            date: Date.now().toString(),
            userId: parseInt(curuserId),
            user: null
        })
    });
    if (response.ok === true) {
        const article = await response.json();
        alert("Создана статья " + article.title);
    }
    else
        alert("Ошибка");
}

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

//поиск
async function Search() {
    //document.getElementById('result').innerHTML = '';
    //var l = this.value.length;
    //if (l > 0) {
    //    for (var i = 0; i < arr.length; i++) {
    //        var _ = arr[i].split('').slice(0, l).join('');
    //        if (_ == this.value) {
    //            document.getElementById('result').innerHTML += arr[i] + '<br/>';
    //        }
    //    }
    //}
}
function GetCurrentUser(){
    return document.cookie.match(/id=(.+?)(;|$)/)[1];
}
async function Login(username, userpass) {
    const response = await fetch("/api/dzenapiuser/"+username+"/"+userpass , {
        method: "Get",
        headers: { "Accept": "application/json" }
    });
    if (response.ok == true) {
        
        window.curUser = await response.json();
        document.cookie = "id="+window.curUser.id;
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

function ArticleFunction() {
    document.getElementById('search').addEventListener("onkeyup", e => {
        e.preventDefault();
    });
}

function PostingFunction() {
    const nowDate = new Date();
    const formatedDate = nowDate.getDate() + "." + (nowDate.getMonth() + 1) + "." + nowDate.getFullYear();
    document.getElementById("dateFolder").innerHTML = formatedDate;
    document.getElementById("postsubmitBTN").addEventListener("click", e => {
        e.preventDefault();
        const form = document.forms["postForm"];
        const titleName = form.elements["titleTB"].value;
        const articleContent = form.elements["contentTB"].value;
        const articleImage = form.elements["imageB"].value;
        const articleDate = formatedDate;
        CreateArticle(titleName, articleContent, articleImage, articleDate); // вместо затычки (0) - авторизованный пользователь
    })
};