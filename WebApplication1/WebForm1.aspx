<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css"></style>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" id="btnAddnew" value="Add New" />
        <table border="2">
            <tr>
                <td>
                    <span id="lblFirstName">First Name</span>
                </td>
                <td>
                    <input name="firstname" type="text" id="txtFirstName" />

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
                    <textarea name="Address" rows="2" cols="20" id="txtAddress"></textarea>
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
                    <input type="date" id="txtbirthday" name="birthday" />
                </td>
            </tr>

            <tr>
                <td>
                    <span id="lblGender">Gender</span>
                </td>
                <td>
                    <input type="radio" name="gender" value="male" />
                    Male
                    <input type="radio" name="gender" value="female" />
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

                    <input id="chkIsTermsAccept" type="checkbox" name="chkIsTermsAccept" />
                    <label for="chkIsTermsAccept">I Agree with this from</label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; align-items: center; align-content: center; align-self: center;">
                    <input type="button" name="Submit" value="Sumbit" id="btnSubmit" style="height: 26px" />
                </td>
            </tr>
        </table>
    </form>
</body>
<script src="Scripts/jquery-3.6.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
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
            person.birthday = $("#txtbirthday").val();
            person.Gender = $("input[type='radio']:checked").val();
            person.TermsAndConditions = $("#chkIsTermsAccept").val();
            var arr = [];
            $("input:checkbox[class=ads_Checkbox]:checked").each(function () {
                arr.push($(this).val());
            });
            person.Hobbies = arr.toString();
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
    });

    function disableDropDown(idDrop, name) {
        $("#" + idDrop + "").prop("disabled", true);
        resetDropDown(idDrop, name);
    }

    function resetDropDown(idDrop, name) {
        $("#" + idDrop + "").empty();
        $("#" + idDrop + "").append($("<option></option>").val('0').html('--Select ' + name + '--'));
    }

</script>
</html>
