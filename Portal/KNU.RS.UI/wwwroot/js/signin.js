window.blazorExtensions = {
    SET_AUTHN_FAILED : function setAuthNFailed() {
        document.getElementById('login-error-wrapper').style.display = 'block';
        document.getElementById('account-email-input').style.borderColor = 'red';
        document.getElementById('account-password-input').style.borderColor = 'red';
    },

    CLEAR_AUTN_FAILED : function clearAuthNFailed() {
        document.getElementById('login-error-wrapper').style.display = 'none';
        document.getElementById('account-email-input').style.borderColor = null;
        document.getElementById('account-password-input').style.borderColor = null;
    },

    WRITE_COOKIE: function writeCookie(name, value, days) {

        var expires;
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toGMTString();
        }
        else {
            expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    },

    LOGIN: function Login(login, password) {
        var data = {
            "Email": login,
            "Password": password
        };

        $.ajax({
            url: "api/login",
            type: 'POST',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            processData: false,
            success: function (result) {
                alert(result.success); 
            },
        });
    }
}



