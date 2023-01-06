<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css"></style>
</head>
<body>
    <form id="form1" runat="server">
        <table border="2" id="tblGridview" align="center">
           
                <thead>
                    <tr>
                        <th>Pid</th>
                        <th>PRID</th>
                        <th>First Name</th>
                        <th>Middle Name</th>
                        <th>Last Name</th>
                        <th>Mobile Number</th>
                        <th>Address</th>
                        <th>Country</th>
                        <th>State</th>
                        <th>City</th>
                        <th>Pin Code</th>
                        <th>Date Of Brith</th>
                        <th>Gender</th>
                        <th>Hobbies</th>
                        <th>TermsAndConditions</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
             <tbody>
            </tbody>
        </table>
        <br />
        <br />
        <div align="center">
            <input type="button" id="btnAddnew" value="Add New" style="background-color:MediumSlateBlue; color:white" />
        </div>
        <br />
        <table border="2" id="tblForms" align="center">
            <tr>
                <td>
                    <span id="lblFirstName">First Name</span>
                </td>
                <td>
                    <input name="firstname" type="text" id="txtFirstName" />
                    <input name="pid" type="hidden" id="hdnPid" />

                </td>

            </tr>

            <tr>
                <td>
                    <span id="lblMiddleName">Middle Name</span>
                </td>
                <td>
                    <input name="MiddleName" type="text" id="txtMiddleName" />
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblLastName">Last Name</span>
                </td>
                <td>
                    <input name="LastName" type="text" id="txtLastName" />
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblMobile">Mobile Number</span>
                </td>
                <td>
                    <input name="Mobile" type="text" id="txtMobile" maxlength="10" />
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblAddress">Address</span>
                </td>
                <td>
                    <textarea name="Address" rows="2" cols="20" id="txtAddress" wrap="hard"></textarea>
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblCountry">Country</span>
                </td>
                <td>
                    <select name="Country" id="ddlCountry">
                        <option value="0">--Select Country--</option>
                    </select>
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblState">State</span>
                </td>
                <td>
                    <select name="State" id="ddlState">
                        <option value="0">--Select State--</option>
                    </select>
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblCity">City</span>
                </td>
                <td>
                    <select name="City" id="ddlCity">
                        <option value="0">--Select City--</option>
                    </select>
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblPinCode">Pin Code</span>
                </td>
                <td>
                    <input type="text" id="txtPinCode" name="pinCode" maxlength="6" />
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblDateOfBrith">Date Of Brith</span>
                </td>
                <td>
                    <input type="date" id="txtbirthday" name="Birthday" />
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblGender">Gender</span>
                </td>
                <td>
                    <input type="radio" id="male" name="gender" value="Male" />
                    Male
                    <input type="radio" id="female" name="gender" value="Female" />
                    Female
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblHobbies">Hobbies</span>
                </td>
                <td>
                    <input id="cblHobbies_1" type="checkbox" class="ads_Checkbox" name="cblHobbies$0" value="Cricket" />Cricket
                    <input id="cblHobbies_2" type="checkbox" class="ads_Checkbox" name="cblHobbies$0" value="Volleyball" />Volleyball
                    <input id="cblHobbies_3" type="checkbox" class="ads_Checkbox" name="cblHobbies$0" value="Movies" />Movies
                    <input id="cblHobbies_4" type="checkbox" class="ads_Checkbox" name="cblHobbies$0" value="Serial" />Serial
                    <input id="cblHobbies_5" type="checkbox" class="ads_Checkbox" name="cblHobbies$0" value="Football" />Football
                    <input id="cblHobbies_6" type="checkbox" class="ads_Checkbox" name="cblHobbies$0" value="Reading" />Reading
                    <input id="cblHobbies_7" type="checkbox" class="ads_Checkbox" name="cblHobbies$0" value="Writing" />Writing
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <input type="checkbox" id="chkIsTermsAccept" name="chkIsTermsAccept" value="true" />
                    <label for="chkIsTermsAccept">I Agree with this from</label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; align-items: center; align-content: center; align-self: center;">
                    <input type="button" name="Submit" value="Sumbit" id="btnSubmit" disabled="disabled" style="height: 26px; background-color:CornflowerBlue"  />
                    <input type="button" name="Update" value="Update" id="btnUpdate" disabled="disabled" style="height: 26px; background-color:CornflowerBlue" />
                </td>
            </tr>
        </table>
    </form>
</body>
<script src="Scripts/jquery-3.6.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#btnUpdate").hide();
        
        $('#btnSubmit').click(function () {
            var person = {};
            person.FirstName = $("#txtFirstName").val();
            person.MiddleName = $("#txtMiddleName").val();
            person.LastName = $("#txtLastName").val();
            person.Mobile = $("#txtMobile").val();
            person.Address = $("#txtAddress").val();
            person.Country = $("#ddlCountry").val();
            person.State = $("#ddlState").val();
            person.City = $("#ddlCity").val();
            person.PinCode = $("#txtPinCode").val();
            person.Birthday = $("#txtbirthday").val();
            person.Gender = $("input[type='radio']:checked").val();

            var arr = [];
            $("input:checkbox[class=ads_Checkbox]:checked").each(function () {
                arr.push($(this).val());
            });
            person.Hobbies = arr.toString();
            person.TermsAndConditions = $("#chkIsTermsAccept").val();

            //debugger;

            var values = {};
            values.per = JSON.stringify(person);
            $.ajax({
                type: "POST",
                url: "/PersonService.asmx/AddPerson",
                data: JSON.stringify(values),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != null && !data.d.success && data.d.error != null) {
                        alert(data.d.error);
                    } else {
                        formReset();
                        bindGrid();
                    }
                    //debugger;
                    //console.log(data);
                },
                error: function (err) {
                    //debugger;
                    console.log(err);
                }
            });

        });

        //update record
        $('#btnUpdate').click(function () {
            var person = {};
            person.Pid = $("#hdnPid").val();
            person.FirstName = $("#txtFirstName").val();
            person.MiddleName = $("#txtMiddleName").val();
            person.LastName = $("#txtLastName").val();
            person.Mobile = $("#txtMobile").val();
            person.Address = $("#txtAddress").val();
            person.Country = $("#ddlCountry").val();
            person.State = $("#ddlState").val();
            person.City = $("#ddlCity").val();
            person.PinCode = $("#txtPinCode").val();
            person.Birthday = $("#txtbirthday").val();
            person.Gender = $("input[type='radio']:checked").val();
            var arr = [];
            $("input:checkbox[class=ads_Checkbox]:checked").each(function () {
                arr.push($(this).val());
            });
            person.Hobbies = arr.toString();
            person.TermsAndConditions = $("#chkIsTermsAccept").val();
            //debugger;
            var values = {};
            values.per = JSON.stringify(person);
            $.ajax({
                type: "POST",
                url: "/PersonService.asmx/UpdateRecord",
                data: JSON.stringify(values),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.d != null && !data.d.success && data.d.error != null) {
                        alert(data.d.error);
                    } else {
                        bindGrid();
                        formReset();
                    }
                    //debugger;
                    console.log(data);
                },
                error: function (err) {
                    //debugger;
                    console.log(err);
                }
            });

        });

        // Country Dropdouwn list 
        $.ajax({
            type: "POST",
            url: "/PersonService.asmx/GetCountries",
            //data: JSON.stringify(values),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {
                //debugger;
                $.each(res.d, function (data, value) {
                    $("#ddlCountry").append($("<option></option>").val(value.CountryId).html(value.CountryName));
                })
            },
            error: function (err) {
                console.log(err);
            }
        });

        // State Dropdouwn list
        $("#ddlCountry").change(function () {
            var CountryId = $(this).val();
            if (!isNaN(CountryId)) {
                var Cid = {};
                Cid.CounrtyId = CountryId;
                if ($(this).val() != "0") {
                    $("#ddlState").prop("disabled", false);
                    $.ajax({
                        url: "/PersonService.asmx/GetState",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(Cid),
                        success: function (res) {
                            //debugger;
                            resetDropDown('ddlState', 'State');
                            $.each(res.d, function (data, value) {
                                $("#ddlState").append($("<option></option>").val(value.StateId).html(value.StateName));
                            });
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });
                }
                else {
                    disableDropDown('ddlState', 'State');
                    disableDropDown('ddlCity', 'City');
                }
            }
            else {
                disableDropDown('ddlState', 'State');
                disableDropDown('ddlCity', 'City');
            }
        });

        // City Dropdouwn list
        $("#ddlState").change(function () {
            var StateId = $(this).val();

            if (!isNaN(StateId)) {
                var CiId = {};
                CiId.StateId = StateId;
                if ($(this).val() != "0") {
                    $("#ddlCity").prop("disabled", false);
                    $.ajax({
                        url: "/PersonService.asmx/GetCity",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(CiId),
                        success: function (res) {
                            //debugger;
                            resetDropDown('ddlCity', 'City');
                            $.each(res.d, function (data, value) {
                                $("#ddlCity").append($("<option></option>").val(value.CityId).html(value.CityName));
                            });
                        },
                        error: function (err) {
                            console.log(err);
                        }
                    });
                }
                else {
                    disableDropDown('ddlCity', 'City');
                }
            }
            else {
                disableDropDown('ddlCity', 'City');
            }
        });

        // data on edit button and fill in forms
        $('body').on('click', '#btnEdit', function () {
            var pid = $(this).parents("tr").find('td:eq(0)').text();
            var prid = $(this).parents("tr").find('td:eq(1)').text();
            var firstname = $(this).parents("tr").find('td:eq(2)').text();
            var middlename = $(this).parents("tr").find('td:eq(3)').text();
            var lastname = $(this).parents("tr").find('td:eq(4)').text();
            var mobilenumber = $(this).parents("tr").find('td:eq(5)').text();
            var address = $(this).parents("tr").find('td:eq(6)').text();
            var country = $(this).parents("tr").find('td:eq(7)').text();
            var state = $(this).parents("tr").find('td:eq(8)').text();
            var city = $(this).parents("tr").find('td:eq(9)').text();
            var pincode = $(this).parents("tr").find('td:eq(10)').text();
            var dateofbrith = $(this).parents("tr").find('td:eq(11)').text();
            var gender = $(this).parents("tr").find('td:eq(12)').text();
            var hobbies = $(this).parents("tr").find('td:eq(13)').text();
            var termsandconditions = $(this).parents("tr").find('td:eq(14)').text().toString();

            //debugger;
            // data fill the form
            var data = {};
            data.Pid = pid;
            $.ajax({
                url: "/PersonService.asmx/FilltheData",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data),
                success: function (res) {
                    //console.log(res);
                    var arrData = JSON.parse(res.d);
                    $("#hdnPid").val(pid);
                    $("#txtFirstName").val(arrData[0].FirstName);
                    $("#txtMiddleName").val(arrData[0].MiddleName);
                    $("#txtLastName").val(arrData[0].LastName);
                    $("#txtMobile").val(arrData[0].MoblieNumber);
                    $("#txtAddress").val(arrData[0].Address);

                    $("#ddlCountry").val(arrData[0].Country);

                    //----------------

                    var CountryId = arrData[0].Country;
                    var StateId = arrData[0].State;
                    var CityId = arrData[0].City;

                    if (!isNaN(CountryId)) {
                        var Cid = {};
                        Cid.CounrtyId = CountryId;
                        if ($("#ddlCountry").val() != "0") {
                            $("#ddlState").prop("disabled", false);
                            $.ajax({
                                url: "/PersonService.asmx/GetState",
                                type: "POST",
                                dataType: "json",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify(Cid),
                                success: function (res) {
                                    //debugger;
                                    resetDropDown('ddlState', 'State');
                                    $.each(res.d, function (data, value) {
                                        $("#ddlState").append($("<option></option>").val(value.StateId).html(value.StateName));
                                    });
                                    $("#ddlState").val(StateId);

                                    //----------State Change--------

                                    if (!isNaN(StateId)) {
                                        var CiId = {};
                                        CiId.StateId = StateId;
                                        if ($("#ddlState") != "0") {
                                            $("#ddlCity").prop("disabled", false);
                                            $.ajax({
                                                url: "/PersonService.asmx/GetCity",
                                                type: "POST",
                                                dataType: "json",
                                                contentType: "application/json; charset=utf-8",
                                                data: JSON.stringify(CiId),
                                                success: function (res) {
                                                    //debugger;
                                                    resetDropDown('ddlCity', 'City');
                                                    $.each(res.d, function (data, value) {
                                                        $("#ddlCity").append($("<option></option>").val(value.CityId).html(value.CityName));
                                                    });
                                                    $("#ddlCity").val(CityId);
                                                },
                                                error: function (err) {
                                                    console.log(err);
                                                }
                                            });
                                        }
                                        else {
                                            disableDropDown('ddlCity', 'City');
                                        }
                                    }
                                    else {
                                        disableDropDown('ddlCity', 'City');
                                    }

                                    //---------State Change--------

                                },
                                error: function (err) {
                                    console.log(err);
                                }
                            });
                        }
                        else {
                            disableDropDown('ddlState', 'State');
                            disableDropDown('ddlCity', 'City');
                        }
                    }
                    else {
                        disableDropDown('ddlState', 'State');
                        disableDropDown('ddlCity', 'City');
                    }

                    //----------------



                    $("#txtPinCode").val(arrData[0].Pincode);

                    // Date
                    var year = new Date(arrData[0].DateOfBrith).getFullYear();
                    var month = (new Date(arrData[0].DateOfBrith).getMonth() + 1) < 10 ? ("0" + (new Date(arrData[0].DateOfBrith).getMonth() + 1)) : (new Date(arrData[0].DateOfBrith).getMonth() + 1);
                    var day = (new Date(arrData[0].DateOfBrith).getDate()) < 10 ? ("0" + (new Date(arrData[0].DateOfBrith).getDate())) : (new Date(arrData[0].DateOfBrith).getDate());
                    $("#txtbirthday").val(year + "-" + month + "-" + day);

                    // gender
                    $('[name="gender"]').removeAttr('checked');
                    $("input[name=gender][id=" + arrData[0].Gender.toLowerCase() + "]").prop('checked', true);

                    // hobbies
                    $('[name="cblHobbies$0"]').prop('checked', false);
                    var arr = arrData[0].Hobbies.split(',');
                    for (var i = 0; i < arr.length; i++) {
                        $("input:checkbox[class=ads_Checkbox][value=" + arr[i] + "]").prop('checked', true);
                    }

                    $("#chkIsTermsAccept").removeProp('checked');
                    $("#chkIsTermsAccept").val(arrData[0].TermsAndConditions).prop('checked', true);
                   
                    // button update show and submit button hide
                    $('#btnUpdate').show()
                    $('#btnSubmit').hide();
                    if ($("#chkIsTermsAccept").is(':checked')) {
                        $('#btnSubmit').removeAttr('disabled');
                        $('#btnUpdate').removeAttr('disabled');

                    } else {
                        $('#btnSubmit').attr('disabled', 'disabled');
                        $('#btnUpdate').attr('disabled', 'disabled');
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });

        //Delete button
        $('body').on('click', '#btnDelete', function () {
            $(this).closest("tr").remove();
            var pid = $(this).parents("tr").find('td:eq(0)').text();
            var prid = $(this).parents("tr").find('td:eq(1)').text();
            var firstname = $(this).parents("tr").find('td:eq(2)').text();
            var middlename = $(this).parents("tr").find('td:eq(3)').text();
            var lastname = $(this).parents("tr").find('td:eq(4)').text();
            var mobilenumber = $(this).parents("tr").find('td:eq(5)').text();
            var address = $(this).parents("tr").find('td:eq(6)').text();
            var country = $(this).parents("tr").find('td:eq(7)').text();
            var state = $(this).parents("tr").find('td:eq(8)').text();
            var city = $(this).parents("tr").find('td:eq(9)').text();
            var pincode = $(this).parents("tr").find('td:eq(10)').text();
            var dateofbrith = $(this).parents("tr").find('td:eq(11)').text();
            var gender = $(this).parents("tr").find('td:eq(12)').text();
            var hobbies = $(this).parents("tr").find('td:eq(13)').text();
            var termsandconditions = $(this).parents("tr").find('td:eq(14)').text().toString();

            //debugger;
           
            var data = {};
            data.Pid = pid;
            $.ajax({
                url: "/PersonService.asmx/DeleteRecord",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(data),
                success: function (res) {
                    var arrData = JSON.parse(res.d);
                    $("#hdnPid").val(pid);
                    
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });

        // data table function call 
        bindGrid();

        
        /* disable button */
        $(function () {
            $('#chkIsTermsAccept').click(function () {
                if ($(this).is(':checked')) {
                    $('#btnSubmit').removeAttr('disabled');
                    $('#btnUpdate').removeAttr('disabled');
                    
                } else {
                    $('#btnSubmit').attr('disabled', 'disabled');
                    $('#btnUpdate').attr('disabled', 'disabled');
                    
                }
            });
        });
        

        // data table function
        function bindGrid() {
            $.ajax({
                type: "POST",
                url: "/PersonService.asmx/DataDisplay",
                dataType: "json",
                success: function (data) {
                    //console.log(data);
                    $("#tblGridview").find('tbody').html('');
                    for (let i = 0; i < data.length; i++) {
                        $("#tblGridview").find('tbody').append('<tr>   <td align="center">' + data[i].Pid + '</td>   <td align="center">' + data[i].PRID + '</td>   <td align="center">' + data[i].FirstName + '</td>  <td align="center">' + data[i].MiddleName + '</td>     <td align="center">' + data[i].LastName + '</td>     <td align="center">' + data[i].MoblieNumber + '</td>    <td align="center">' + data[i].Address + '</td>    <td align="center">' + data[i].Country + '</td>     <td align="center">' + data[i].State + '</td>    <td align="center">' + data[i].City + '</td>    <td align="center">' + data[i].Pincode + '</td>   <td align="center">' + data[i].DateOfBrith + '</td>   <td align="center">' + data[i].Gender + '</td>   <td align="center">' + data[i].Hobbies + '</td>  <td align="center"><input type="checkbox" id="cheTeam" disabled="true" name="TermsAndConditions" checked=?data[i].TermsAndConditions ?></td>    <td><input type="button" id="btnEdit" value="Edit" style="background-color:RoyalBlue; color:white"> </td><td><input type="button" id="btnDelete" value="Delete" style="background-color:Red; color:white"></td>  </tr>');
                        
                    };
                },
                error: function (err) {
                    console.log(err);
                }
                //console.log(data); console.log(data[0].Pid); console.log(data[0]["Pid"]);
            });
        }

        function disableDropDown(idDrop, name) {
            $("#" + idDrop + "").prop("disabled", true);
            resetDropDown(idDrop, name);
        }

        function resetDropDown(idDrop, name) {
            $("#" + idDrop + "").empty();
            $("#" + idDrop + "").append($("<option></option>").val('0').html('--Select ' + name + '--'));
        }

        function formReset() {
            $("#hdnPid").val('');
            $("#txtFirstName").val('');
            $("#txtMiddleName").val('');
            $("#txtLastName").val('');
            $("#txtMobile").val('');
            $("#txtAddress").val('');
            //dropdown list 
            $("#ddlCountry").prop('selectedIndex', 0).removeAttr('disabled', true);
            $("#ddlState").prop('selectedIndex', 0).removeAttr('disabled', true);
            $("#ddlCity").prop('selectedIndex', 0).removeAttr('disabled', true);
            $('#ddlCountry').change(ddlState);
            $('#ddlState').change(ddlCity).prop('disabled', true);
            $('#ddlCity').prop('disabled', true);

            $("#txtPinCode").val('');
            $("#txtbirthday").val('');
            $("input[type='radio']:checked").prop('checked', false);
            $("input:checkbox[class=ads_Checkbox]:checked").each(function () {
                $(this).prop('checked', false);
            });
            $("#chkIsTermsAccept").prop('checked', false).removeAttr('disabled', true);
            $('#btnSubmit').attr('disabled', 'disabled');
        }

        $("#btnAddnew").click(function () {
            $("#btnSubmit").show();
            $("#btnUpdate").hide();
            formReset();
        });
    });

</script>
</html>
