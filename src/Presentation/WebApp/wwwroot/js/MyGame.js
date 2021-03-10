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
var id = null;
function start() {
    var elem = document.querySelector('.mydiv');
    var images = [{url: " url(\"../images/001-c.jpg\") no-repeat center center / 100%", nationality: 'chinese'},
        {url: " url(\"../images/002-t.jpg\") no-repeat center center / 100%", nationality: 'thai'},
        {url:" url(\"../images/003-c.jpg\") no-repeat center center / 100%", nationality: 'chinese'},
        {url:" url(\"../images/004-t.jpg\") no-repeat center center / 100%", nationality: 'thai'},
        {url:" url(\"../images/001-c.jpg\") no-repeat center center / 100%", nationality: 'chinese'},
        {url:" url(\"../images/005-j.jpg\") no-repeat center center / 100%", nationality: 'japanese'},
        {url:" url(\"../images/006-j.jpg\") no-repeat center center / 100%", nationality: 'japanese'},
        {url:" url(\"../images/007-j.jpg\") no-repeat center center / 100%", nationality: 'japanese'},
        {url:" url(\"../images/008-k.jpg\") no-repeat center center / 100%", nationality: 'korean'},
        { url:" url(\"../images/009-k.jpg\") no-repeat center center / 100%", nationality: 'korean'},
        {url:" url(\"../images/010-k.jpg\") no-repeat center center / 100%", nationality: 'korean'}
    ];
    clearInterval(id);
    id = setInterval(frame, 10);
    var i=0;
    var pos=0;
    function frame() {
        if (pos === 350) {
            pos=0;
            if(i===images.length)
            {

               
                clearInterval(id);
                SendData();
                return;
            }
            elem.style.background=images[i].url;
            elem.dataset.src= images[i].nationality;

            clearInterval(id);
            id = setInterval(frame, 10);
  
            i++;
        } else {
            pos++;
            elem.style.top = pos + 'px';
            elem.style.bottom = pos + 'px';
        }
    }
    
}
function SendData(){
    document.getElementById("gameBoard").style.display = 'none';

    var user=localStorage.getItem("userId");
    var data={userId:user,point:score}
    $.ajax({
        type: "POST",
        url: "/api/v1/user/add-point"
        , dataType: 'json'
        , contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data)
        , success: function (data) {
            alert(data.name+" your point is:"+data.point);

        },
        error: function (x, err, desc) {
            alert(desc);
        }
    })
}
const dragItem = document.querySelector("#myDIV");
const src = dragItem.dataset.src;
const container = document.querySelector('.main-section')

let currentDroppable = null;

dragItem.onmousedown = function (event) {

    let shiftX = event.clientX - dragItem.getBoundingClientRect().left;
    let shiftY = event.clientY - dragItem.getBoundingClientRect().top;

    dragItem.style.position = 'absolute';
    dragItem.style.zIndex = 1000;
    document.body.append(dragItem);

    moveAt(event.pageX, event.pageY);

    function moveAt(pageX, pageY) {
        dragItem.style.left = pageX - shiftX + 'px';
        dragItem.style.top = pageY - shiftY + 'px';
    }

    function onMouseMove(event) {
        moveAt(event.pageX, event.pageY);

        dragItem.hidden = true;
        let elemBelow = document.elementFromPoint(event.clientX, event.clientY);
        dragItem.hidden = false;

        if (!elemBelow) return;

        let droppableBelow = elemBelow.closest('.droppable');
        if (currentDroppable != droppableBelow) {
            if (currentDroppable) {
                leaveDroppable(currentDroppable);
            }
            currentDroppable = droppableBelow;
            if (currentDroppable) {
                enterDroppable(currentDroppable);
            }
        }
    }

    document.addEventListener('mousemove', onMouseMove);

    dragItem.onmouseup = function () {
        document.removeEventListener('mousemove', onMouseMove);
        dragItem.onmouseup = null;
    };

};

function enterDroppable(elem) {
    elem.dispatchEvent(new Event("click"));
}

function leaveDroppable(elem) {
    // elem.style.background = 'blue';
}

dragItem.ondragstart = function () {
    return false;
};

let score = 0; 

function chineseClicked() {
    if (src) {
        if (src === 'chinese') {
            score += 20;
            // add score 20
        } else {
            score -= 5;

            // add score -5
        }
    }
    alert('chinese');
}

function koreanClicked() {
    if (src) {
        if (src === 'korean') {
            score += 20;
        } else {
            score -= 5;
        }
    }
    alert('korean');
}

function japaneseClicked() {
    if (src) {
        if (src === 'japanese') {
            score += 20;
        } else {
            score -= 5;
        }
    }
    alert('japanese');
}

function thaiClicked() {
    if (src) {
        if (src === 'thai') {
            score += 20;
        } else {
            score -= 5;
        }
    }
    alert('thai');
}

