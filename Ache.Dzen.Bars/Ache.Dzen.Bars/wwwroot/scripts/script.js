﻿var curUser = new Object();

async function CreateArticle(articleTitle, articleContent, articleBinaryImage, articalDate) {
    let curuserId = GetCurrentUser();
    if (articleTitle == "" || articleContent == "" || articalDate == "") {
        alert("Были обнаружены пустые поля");
        return;
    }
    
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
            date: articalDate,
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
}