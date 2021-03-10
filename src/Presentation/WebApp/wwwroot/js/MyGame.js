"use strict";

function myFunction() {
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const jData = {
        lastName: firstName,
        firstName: lastName,
        points: []
    };
    $.ajax({
        type: "POST",
        url: "/api/v1/user"
        , dataType: 'json'
        , contentType: "application/json; charset=utf-8",
        data: JSON.stringify(jData)
        , success: function (data) {
            if (localStorage.getItem("userId"))
                localStorage.clear();
            localStorage.setItem("userId", data);
            document.getElementById("loginPanel").style.display = 'none';
            document.getElementById("gameBoard").style.display = 'block';
            
        },
        error: function (x, err, desc) {
            alert(desc);
        }
    })
}




document.getElementById('myDIV').onclick = function clickEvent(e) {
    // e = Mouse click event.
    var rect = e.target.getBoundingClientRect();
    var x = e.clientX - rect.left; //x position within the element.
    var y = e.clientY - rect.top;  //y position within the element.
    console.log("Left? : " + x + " ; Top? : " + y + ".");
}

