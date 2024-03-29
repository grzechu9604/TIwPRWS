﻿websocket = null;
gameIdCookieName = "GAME_ID_COOKIE_NAME";

// REQUEST CODES

REQUEST_FOR_NEW_GAME_CODE = 1;
REQUEST_FOR_EXISTING_GAME_CODE = 2;
GAMING_REQUEST_CODE = 3;

// GAME CODES

KEY_UP_GAME_CODE = 1;
KEY_DOWN_GAME_CODE = 2;
KEY_LEFT_GAME_CODE = 3;
KEY_RIGHT_GAME_CODE = 4;
KEY_SPACEBAR_GAME_CODE = 5;

function init() {
    websocket = new WebSocket("ws://localhost:50027/ws");
    websocket.binaryType = "arraybuffer";
    websocket.onopen = function (e) { onOpen(e) };
    websocket.onclose = function (e) { onClose(e) };
    websocket.onmessage = function (e) { onMessage(e) };
    websocket.onerror = function (e) { onError(e) };
}

function onError(e) {
    alert("Błąd połączenia z serwerem!");
}

function onClose(e) {
    console.log("Zamknięto WebSocket!");
}

function onOpen(e) {
    gameId = getCookie(gameIdCookieName);
    if (gameId != "") {
        requestForExistingGame();
    }
    else {
        requestForNewGame();
    }
}

function onMessage(e) {
    var view = new DataView(e.data);
    var playerId = view.getUint32(0, true);

    if (view.byteLength > 4) {
        clearCanvas();

        var self_x = view.getInt32(4, true); 
        var self_y = view.getInt32(8, true);
        var self_score = view.getInt8(12, true); 

        drawRectangle(self_x * 50, self_y * 50, 50, 50, "#f4bf42")

        var opponent_x = view.getInt32(18, true);
        var opponent_y = view.getInt32(22, true);
        var opponent_score = view.getInt8(26, true);

        drawRectangle(opponent_x * 50, opponent_y * 50, 50, 50, "#0c140c")

        drawScore(self_score, opponent_score);
    }

    addCookie(gameIdCookieName, playerId);
}

function spacebarClicked() {
    sendGameCommunicate(GAMING_REQUEST_CODE, KEY_SPACEBAR_GAME_CODE, getPlayerIdAsUint32());
}

function keyUpClicked() {
    sendGameCommunicate(GAMING_REQUEST_CODE, KEY_UP_GAME_CODE, getPlayerIdAsUint32());
}

function keyDownClicked() {
    sendGameCommunicate(GAMING_REQUEST_CODE, KEY_DOWN_GAME_CODE, getPlayerIdAsUint32());
}

function keyRightClicked() {
    sendGameCommunicate(GAMING_REQUEST_CODE, KEY_RIGHT_GAME_CODE, getPlayerIdAsUint32());
}

function keyLeftClicked() {
    sendGameCommunicate(GAMING_REQUEST_CODE, KEY_LEFT_GAME_CODE, getPlayerIdAsUint32());
}

function sendGameCommunicate(requestCode, keyCode, playerId) {
    var buffer = new ArrayBuffer(6);
    var view = new DataView(buffer);
    view.setInt8(0, requestCode);
    view.setInt8(1, keyCode);
    view.setUint32(2, playerId, true);
    websocket.send(view);
}

function fkey(e) {
    e = e || window.event;

    switch (e.keyCode) {
        case 38:
            keyUpClicked();
            return false;
        case 40:
            keyDownClicked();
            return false;
        case 39:
            keyRightClicked();
            return false;
        case 37:
            keyLeftClicked();
            return false;
        case 32:
            spacebarClicked();
            return false;
        default:
    }
}

document.onkeydown = fkey;

function addCookie(name, value) {
    document.cookie = name + "=" + value;
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function requestForNewGame() {
    sendGameCommunicate(REQUEST_FOR_NEW_GAME_CODE, 0, 0);
}

function requestForExistingGame() {
    sendGameCommunicate(REQUEST_FOR_EXISTING_GAME_CODE, 0, getPlayerIdAsUint32());
}

function getPlayerIdAsUint32() {
    var currentPlayerId = parseInt(getCookie(gameIdCookieName), 10);
    return currentPlayerId >>> 0;
}

function drawScore(score, opponentScore) {
    $('#Score').text("Twój wynik: " + score + " Wynik przeciwnika: " + opponentScore);
}

function drawRectangle(x, y, size_x, size_y, color) {
    var canvas = document.getElementById("gameCanvas");
    var ctx = canvas.getContext("2d");
    ctx.fillStyle = color;
    ctx.fillRect(x, y, size_x, size_y);
}

function clearCanvas() {
    var canvas = document.getElementById("gameCanvas");
    const context = canvas.getContext('2d');
    context.clearRect(0, 0, canvas.width, canvas.height);
}

window.addEventListener("load", init, false);