
//Function To Display Popup
function popUp_show() {
document.getElementById('abc').style.display = "block";
}
//Function to Hide Popup
window.onload = function () {
    document.getElementById('close').onclick = function () {
        document.getElementById('abc').style.display = "none";
        return false;
    };
};
// Picture Display
function HandleBrowseClick(input_image) {
    var fileinput = document.getElementById('input_image');
    fileinput.click();
}
// Image insert
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#imagepreview').attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}
// compare the password and confirm password
var check = function () {
    if (document.getElementById('password').value ===
        document.getElementById('cpassword').value) {
        document.getElementById('message').style.color = 'green';
        document.getElementById('message').innerHTML = 'matching';
        document.getElementById("submit").disabled = false;
    } else {
        document.getElementById('message').style.color = 'red';
        document.getElementById('message').innerHTML = 'not matching';
        document.getElementById("submit").disabled = true;
    }
}