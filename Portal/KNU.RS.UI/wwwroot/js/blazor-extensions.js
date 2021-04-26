window.blazorExtensions = {
    SET_AUTHN_FAILED : function () {
        document.getElementById('login-error-wrapper').style.display = 'block';
        document.getElementById('account-email-input').style.borderColor = 'red';
        document.getElementById('account-password-input').style.borderColor = 'red';
    },

    CLEAR_AUTHN_FAILED : function () {
        document.getElementById('login-error-wrapper').style.display = 'none';
        document.getElementById('account-email-input').style.borderColor = null;
        document.getElementById('account-password-input').style.borderColor = null;
    },

    DISABLE_LOGIN_BUTTON: function () {
        document.getElementById('login-submit-button').disabled = true;
    },

    ENABLE_LOGIN_BUTTON: function () {
        document.getElementById('login-submit-button').disabled = false;
    },

    LOGIN: function (login, password) {
        var data = {
            "Email": login,
            "Password": password
        };

        $.ajax({
            url: "api/login",
            type: 'POST',
            async: false,  
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            processData: false,
            success: function (resultData) {
                window.location.href = "/main";
            }
        });
    },

    LOGOUT: function () {
        $.ajax({
            url: "api/logout",
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            processData: false,
            success: function (resultData) {
                window.location.href = "/signin";
            }
        });
    },

    SET_SELECT2: function () {
        $('.select').select2({
            minimumResultsForSearch: -1,
            width: '100%'
        });
    },

    ONCHANGE_SELECT2: function (id, dotnetHelper, nameFunc) {
        $('#' + id).on('select2:select', function (e) {
            dotnetHelper.invokeMethodAsync(nameFunc, $('#' + id).val());
        });
    },

    RESET_SIDEBAR_OPENED: function () {
        document.getElementById('sidebar').removeAttribute('style');
        $('#mobile_btn').removeClass('opened');
        $('html').removeClass('menu-opened');
        var $wrapper = $('.main-wrapper');
        $wrapper.removeClass('slide-nav');
    }
}



