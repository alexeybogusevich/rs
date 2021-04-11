function setAuthNFailed() {
    document.getElementById('login-error-wrapper').style.display = 'block';
    document.getElementById('account-email-input').style.borderColor = 'red';
    document.getElementById('account-password-input').style.borderColor = 'red';
}

function clearAuthNFailed() {
    document.getElementById('login-error-wrapper').style.display = 'none';
    document.getElementById('account-email-input').style.borderColor = null;
    document.getElementById('account-password-input').style.borderColor = null;
}

