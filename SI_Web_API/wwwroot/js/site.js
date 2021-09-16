// Web API URL
let web_api_url = 'api/SimpleInterests';

// Function to Display Data in Tabular Structure and collect from API
function loadAllInterest() {
    // Generate AJAX request for collecting All Tutorial Details
    $.ajax({
        type: "GET",
        url: web_api_url,
        cache: false,
        success: function (data) {
            // Capture the reference of Table Body present in Home Page
            const tableBody = $("#tbody_simple");

            $(tableBody).empty(); // Empty the content of Previous Table Body 

            if (data.length == 0) { // If there is no data present
                // Prepare a row for display no data
                const tr = $("<tr></tr>")
                    .append('<td colspan="6" align="center">No Simple Interest information</td>');
                // Add table row in table body
                tr.appendTo(tableBody);
            } else {
                // Iterate all JSON rating json present in data
                $.each(data, function (key, item) {
                    // prepare a row with table column with data 
                    const tr = $("<tr></tr>")
                        .append($("<td></td>").text(item.principal))
                        .append($("<td></td>").text(item.rate))
                        .append($("<td></td>").text(item.year))
                        .append($("<td></td>").text(item.interest))
                        .append($("<td></td>").append('<button class="btn btn-primary" data-toggle="modal" data-target="#updateForm">Edit Details</button>')
                            .on("click", function () {
                                // Call fetch Rating For getting data for edit the details
                                fetchSimple(item.id);
                            })
                        )
                        .append($("<td></td>").append('<button class="btn btn-danger">Delete Details</button>')
                            .on("click", function () {
                                // Call Delete Rating Function For Removing Rating Details
                                deleteSimple(item.id);
                            })
                        );
                    // Add The table row at the end of table body
                    tr.appendTo(tableBody)
                });
            }
        }
    });
}

// Function used to collect information, call the API for calculate Simple INterest and save it
function calculateInterest() {
    // Collect Form Details
    let p_value = parseFloat($('#principal').val());
    let r_value = parseFloat($('#rate').val());
    let y_value = parseInt($('#year').val());
    let si_value = (p_value * r_value * y_value) / 100;
    // Prpeare JSON Data
    let simple = {
        principal: p_value,
        rate: r_value,
        year: y_value,
        interest: si_value
    };

    // Request the API for Insertion
    $.ajax({
        type: "POST",
        url: web_api_url,
        data: JSON.stringify(simple),
        contentType: "application/json; charset=utf-8"
    }).done(function (response) {
        // Display the appropriate message 
        $("#result").html("Simple Interest Details are stored");
        // Call to again Load the Data for displaying
        $('#principal').val("");
        $('#rate').val("");
        $('#year').val("");
        loadAllInterest();
    }).fail(function (xhr, status) {
        // Display the appropriate message 
        $("#result").html("Failure in storing Rating Details");
    });
}

// Function to call API for Updation
function updateInterest() {
    // Collect Form Details
    let p_value = parseFloat($('#principal1').val());
    let r_value = parseFloat($('#rate1').val());
    let y_value = parseInt($('#year1').val());
    let id_value = parseInt($('#id').val());
    let si_value = (p_value * r_value * y_value) / 100;
    // Prpeare JSON Data
    let simple = {
        id: id_value,
        principal: p_value,
        rate: r_value,
        year: y_value,
        interest: si_value
    };

    // Generate API request for Updating the Record
    $.ajax({
        type: "PUT",
        url: web_api_url + "/" + id_value,
        data: JSON.stringify(simple),
        contentType: "application/json; charset=utf-8"
    }).done(function (response) {
        // Display the appropriate message 
        $("#resultUpdate").html("Simple Interest Details are Updated");
        // Call to load All Interest on page
        loadAllInterest();
    }).fail(function (xhr, status) {
        // Display the appropriate message 
        $("#resultUpdate").html("Failure in Updation of Simple Interest Details");
    });
}

// Function to call API for Delete the Record
function deleteSimple(id) {
    // Display a confirm message before generating request of delete
    let result = confirm("Are You Sure to Remove Simple Interest Details?");

    if (result) {
        // Generate Request of API for Delete the Simple Interest Details
        $.ajax({
            type: "DELETE",
            url: web_api_url + "/" + id,
        }).done(function (response) {
            // Again Load the Table Data for Display
            loadAllInterest();
        });
    }
}

// Function to generate request based upon id
function fetchSimple(id) {
    $.ajax({
        type: "GET",
        url: web_api_url + "/" + id,
        contentType: "application/json"
    }).done(function (detail) {
        // Update the Form data for edit rating details        
        $('#id').val(detail.id);
        $('#principal1').val(detail.principal);
        $('#rate1').val(detail.rate);
        $('#year1').val(detail.year);
    });
}