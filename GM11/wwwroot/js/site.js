// Write your Javascript code.
$(document).ready(function () {
    $("#start_datepicker").datepicker();
    $("#end_datepicker").datepicker();

   /* function postdata(location) {
        var url = '@: Url.Action("Authenticate", "Login", new { username = XXX, password = YYY)';
        var Username = document.getElementById(Username).value;
        var Password = document.getElementById(Password).value;
        url = url.replace("XXX", Username);
        url = url.replace("YYY", Password);
        location.href = url;
    }

    <button type="button" id="btnLogin" onclick="postdata()" runat="server"></button>
    */
});

/*function ShowCar(img, regNoText, regNo, serviceIdText, serviceId, currentMilText, currentMil, nextSerText, nextSer, doorsText, doors, seatsText, seats, fuelText, fuel, fuelPerKmText, fuelPerKm, transText, trans, carTypeText, carType) { 

    var carInfo = [
        regNoText,
        regNo,
        serviceIdText,
        serviceId,
        currentMilText,
        currentMil,
        doorsText,
        doors,
        seatsText,
        seats,
        fuelText,
        fuel,
        fuelPerKmText,
        fuelPerKm,
        transText,
        trans,
        carTypeText,
        carType
    ];

    var table = "<table>";
                                                                                    { !DOES NOT WORK!
    table += "<tr>";

    for (var i = 0; 0 < carInfo; i++) {

        table += "<td>" + carInfo[i] + "</td>";

    }

    table += "</tr>";
    table += "</table>";

    $(".Car").append(table);

}*/