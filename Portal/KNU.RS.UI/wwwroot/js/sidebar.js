window.blazorSidebarExtensions = {
    SET_PANEL_ACTIVE: function setAuthNFailed() {
        if (!($('#side-li-panel').hasClass('active'))) {
            $('#side-li-panel').addClass('active');
        }
        if ($('#side-li-doctors').hasClass('active')) {
            $('#side-li-doctors').removeClass('active');
        }
        if ($('#side-li-patients').hasClass('active')) {
            $('#side-li-patients').removeClass('active');
        }
        if ($('#side-li-settings').hasClass('active')) {
            $('#side-li-settings').removeClass('active');
        }
    },
    SET_DOCTORS_ACTIVE: function setAuthNFailed() {
        if ($('#side-li-panel').hasClass('active')) {
            $('#side-li-panel').removeClass('active');
        }
        if (!($('#side-li-doctors').hasClass('active'))) {
            $('#side-li-doctors').addClass('active');
        }
        if ($('#side-li-patients').hasClass('active')) {
            $('#side-li-patients').removeClass('active');
        }
        if ($('#side-li-settings').hasClass('active')) {
            $('#side-li-settings').removeClass('active');
        }
    },
    SET_PATIENTS_ACTIVE: function setAuthNFailed() {
        if ($('#side-li-panel').hasClass('active')) {
            $('#side-li-panel').addClass('active');
        }
        if ($('#side-li-doctors').hasClass('active')) {
            $('#side-li-doctors').removeClass('active');
        }
        if (!($('#side-li-patients').hasClass('active'))) {
            $('#side-li-patients').addClass('active');
        }
        if ($('#side-li-settings').hasClass('active')) {
            $('#side-li-settings').removeClass('active');
        }
    },
    SET_SETTINGS_ACTIVE: function setAuthNFailed() {
        if ($('#side-li-panel').hasClass('active')) {
            $('#side-li-panel').removeClass('active');
        }
        if ($('#side-li-doctors').hasClass('active')) {
            $('#side-li-doctors').removeClass('active');
        }
        if (!($('#side-li-patients').hasClass('active'))) {
            $('#side-li-patients').addClass('active');
        }
        if ($('#side-li-settings').hasClass('active')) {
            $('#side-li-settings').removeClass('active');
        }
    }
}