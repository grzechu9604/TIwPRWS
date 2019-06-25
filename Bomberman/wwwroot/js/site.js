function init() {
    websocket = new WebSocket("ws://localhost:50027/ws");
    websocket.onopen = function (e) { onOpen(e) };
    websocket.onclose = function (e) { onClose(e) };
    websocket.onmessage = function (e) { onMessage(e) };
    websocket.onerror = function (e) { onError(e) };
}

function onOpen(e) {
    alert(e.type);
    websocket.send("Hello");
}

function onMessage(e) {
    alert('rcvd: ' + e.data);
    websocket.close();
}

function spacebarClicked() {
    alert("spacebarClicked");
}

function keyUpClicked() {
    alert("keyUpClicked");
}

function keyDownClicked() {
    alert("keyDownClicked");
}

function keyRightClicked() {
    alert("keyRightClicked");
}

function keyLeftClicked() {
    alert("keyLeftClicked");
}

function fkey(e) {
    e = e || window.event;

    switch (e.keyCode) {
        case 38:
            keyUpClicked();
            break;
        case 40:
            keyDownClicked();
            break;
        case 39:
            keyRightClicked();
            break;
        case 37:
            keyLeftClicked();
            break;
        case 32:
            spacebarClicked();
            break;
        default:
    }
}

document.onkeydown = fkey;

window.addEventListener("load", init, false);