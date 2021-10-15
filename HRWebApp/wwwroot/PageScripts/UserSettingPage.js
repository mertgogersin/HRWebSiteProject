$(document).ready(function () {
    GetCompanyInfo();
    GetDayOff();
})

var apiUrl = "http://localhost:11404";

function GetCompanyInfo() {
    var companyName = $(".companyName").val();
    var description = $(".description").val();
    var address = $(".address").val();
    var isActive = $(".isActive").val();

    var companySaveDTO = {
        "companyName": companyName,
        "description": description,
        "address": address,
        "isActive": isActive
    }

    $.ajax({
        url: apiUrl + "/api/Company/GetAllCompanies",
        type: "GET",
        data: { "companySaveDTO": companySaveDTO },
        success: function (data) {
            var companyVMs = [];
            companyVMs.push(data.companySaveDTO);
            $.ajax({
                url: "/UserSettings/GetCompany",
                type: "POST",
                data: { "companyVMs": companyVMs },
                success: function (response) {
                    $("#settings").html(response);
                }
            })
        }
    })
}

function GetDayOff() {
    $.ajax({
        url: apiUrl + "/api/DayOff/GetDayOffByUserIDAsync",
        type: "GET",
        success: function (response) {
            $("dayOff").html(response);
        }
    })
}