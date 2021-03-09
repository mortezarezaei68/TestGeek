"use strict";

function myFunction() {
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;
    const jData={
        lastName: firstName,
        firstName: lastName,
        points:[]
    };
    $.ajax({
        type: "POST",
        url: "https://localhost:5001/api/v1/user"
        , dataType: 'json'
        ,contentType: "application/json; charset=utf-8",
        data: JSON.stringify(jData)
        ,success: function(data) {
            if (localStorage.getItem("userId"))
                localStorage.clear();
            localStorage.setItem("userId", data);
            const y = document.getElementById("div1");
            y.style.visibility = 'hidden';
            const x = document.getElementById("div2");
            x.style.visibility = 'visible'; 
        },
        error: function (x, err, desc) {
            alert(desc);
        }
    })
}