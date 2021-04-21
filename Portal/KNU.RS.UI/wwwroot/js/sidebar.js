window.blazorSidebarExtensions = {
    SET_PANEL_ACTIVE: function() {
        $('#side-li-panel').addClass('active');
        $('#side-li-doctors').removeClass('active');
        $('#side-li-patients').removeClass('active');
        $('#side-li-settings').removeClass('active');
    },
    SET_DOCTORS_ACTIVE: function() {
        $('#side-li-panel').removeClass('active');
        $('#side-li-doctors').addClass('active');
        $('#side-li-patients').removeClass('active');
        $('#side-li-settings').removeClass('active');
    },
    SET_PATIENTS_ACTIVE: function() {
        $('#side-li-panel').removeClass('active');
        $('#side-li-doctors').removeClass('active');
        $('#side-li-patients').addClass('active');
        $('#side-li-settings').removeClass('active');
    },
    SET_SETTINGS_ACTIVE: function() {
        $('#side-li-panel').removeClass('active');
        $('#side-li-doctors').removeClass('active');
        $('#side-li-patients').removeClass('active');
        $('#side-li-settings').addClass('active');
    }
}