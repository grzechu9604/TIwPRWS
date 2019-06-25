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

window.addEventListener("load", init, false);