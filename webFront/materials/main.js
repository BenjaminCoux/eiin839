//api key = 


var globalrep;
function retrieveAllContracts() {
    let input = document.getElementById("monInput").value
    let apiCall = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + input
    var request = "GET"
    var caller = new XMLHttpRequest()
    caller.open(request, apiCall, true)
    caller.setRequestHeader("Accept", "application/json");
    caller.onload = contractsRetrieved;
    caller.send();
    
}

function contractsRetrieved() {
    var response = JSON.parse(this.responseText);
    // console.log(response)
    if (response.length > 25) {
        globalrep = response
    }
    var newLabel = document.createElement("label")
    var newDataList = document.getElementById("contract")
   /* var newInput = document.createElement("input")
    var newDataList = document.createElement("datalist")
    newDataList.id = "contrat"*/
    for (let i = 0; i < response.length;i++) {
        var option = document.createElement("option")
        option.value = response[i].name
        newDataList.appendChild(option)
    }
    var content = document.createTextNode("salut à tous les amis c'est david lafarge")
    newLabel.appendChild(content)
   /* document.body.insertBefore(newLabel, currentdiv)
    document.body.insertBefore(newInput, newLabel)*/
}


function retrieveContractStations() {
    var apikey = document.getElementById("monInput")
    var contract = document.getElementById("inC")
    let apiCall = "https://api.jcdecaux.com/vls/v1/stations?contract=" + contract.value + "&apiKey=" + apikey.value
    var request = "GET"
    var caller = new XMLHttpRequest()
    caller.open(request, apiCall, true)
    caller.setRequestHeader("Accept", "application/json");
    caller.onload = contractsRetrieved;
    caller.send();
    
}


function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2 - lat1);
    var dLon = deg2rad(lon2 - lon1);
    var a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI / 180)
}

function stationsRetrieved() {
    
    var response = globalrep
    console.log(response)
    let mypos = [document.getElementById("in").value, document.getElementById("inn").value]
    let distance = getDistanceFrom2GpsCoordinates(response[0].position.lat, response[0].position.lon, mypos[0], mypos[1])
    let currStats = response[0]
    console.log(currStats)
    for (let i = 0; i < response.length; i++) {
        let tmp = getDistanceFrom2GpsCoordinates(response[i].position.lat, response[i].position.lon, mypos[0], mypos[1])
        if (tmp < distance) {
            distance = tmp;
            currStats = response[i]
        }
    }
    console.log("prout" + currStats.name)
    var newContent = document.createTextNode("the closest station is : " + currStats.name);
    var currentDiv = document.getElementById("end")
    var newDiv = document.createElement("div");
    newDiv.appendChild(newContent);
    document.body.insertBefore(newDiv,currentDiv)

}