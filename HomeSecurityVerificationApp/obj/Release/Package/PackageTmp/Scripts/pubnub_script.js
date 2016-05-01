// Initialize the instance
var pubnub = PUBNUB({
    publish_key: 'pub-c-88cffef4-057d-4a44-905b-89d0a574eefe',
    subscribe_key: 'sub-c-7f87a08c-f693-11e5-9086-02ee2ddab7fe'
});

var roomName = "";
var channelID = "";
var rooms = 0;

function sub(channel) {
    channelID = channel;
    pubnub.subscribe({
        channel: channel,
        connect: function (m) { console.log("CONNECTED: " + m); },
        message: function (m) {

            displayDevice(m)
        },
        error: function (error) {
            // Handle error here
            console.log(JSON.stringify(error));
        }
    });
}

function displayDevice(device) { //take the device name recieved in from the channel and display it in a list
    console.log(device)

    if (device.substr(0, 7) == "Details")
    {
        var div = document.getElementById("list");
        var element = document.createElement("button");

        var name = device.split("@");
       

        roomName = name[2] + "@" + name[3];
        rooms++;
        
        element.type = "button";
        element.innerHTML = name[2];
        element.onclick = function () {
            displayDeviceControls(name[2]);
        };
        element.style.textAlign = "center";

        div.appendChild(element); //add the button the the div

       
        $("#devices #list button").addClass('list-group-item');

        document.getElementById("numDevices").innerHTML = rooms + " Security Devices";
    }
}

function sendMessage(channel, message) //send message to channel
{

    if (rooms > 0 && message == "Retrieve")
    {
        clearRoomList();
    }
    pubnub.publish({
        channel: channel,
        message: message,
        callback: function (m) { console.log("PUBLISH:" + m) }
    });
}

function clearRoomList()
{
    $("#list").empty();
    rooms = 0;
}

function displayDeviceControls(roomName) //display a modal which will be in charge of sending the commands to security devices
{
    $('#commandModal').modal('show')
    var title = document.getElementById('commandsTitle');
    title.innerHTML = roomName;
}

function motion(checkbox) {
    if (checkbox.checked) {
        console.log("MOTION ON");
        sendMessage(channelID, "MotionOn" + roomName);
    }
    else {
        console.log("MOTION OFF");
        sendMessage(channelID, "MotionOff" + roomName);
    }
}

function lights(checkbox) {
    if (checkbox.checked) {
        console.log("LIGHTS ON");
        sendMessage(channelID, "LightsOn" + roomName);
    }
    else{
        console.log("LIGHTS OFF");
        sendMessage(channelID, "LightsOff" + roomName);
    }
    
}