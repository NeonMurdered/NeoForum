class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}

// userName is declared in razor page.
const username = userName;
const textInput = document.getElementById('messageText');
const whenInput = document.getElementById('when');
const chat = document.getElementById('chat');
const messagesQueue = [];

document.getElementById('submitButton').addEventListener('click', () => {
    var currentdate = new Date();
    when.innerHTML =
        currentdate.getDate() + "."
        + (currentdate.getMonth() + 1) + "."
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: false })
});

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;
    
    let when = new Date();
    let message = new Message(username, text);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    let isCurrentUserMessage = message.userName === username;

    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "container bg__primary" : "container bg__default";

    let containernametime = document.createElement('div');
    containernametime.className = "container__name__time";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = message.userName;
    let text = document.createElement('p');
    text.className = "chatp";
    text.innerHTML = message.text;

    let when = document.createElement('span');
    when.className = isCurrentUserMessage ? "time-left" : "time-right";
    var currentdate = new Date();
    when.innerHTML =
        currentdate.getDate() + "."
        + (currentdate.getMonth() + 1) + "."
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: false })

    container.appendChild(containernametime);
    containernametime.appendChild(sender);
    containernametime.appendChild(when);
    container.appendChild(text);
    chat.appendChild(container);
}
