function checkAuthorize() {
    if (sessionStorage.getItem("tokenInfo") !== null && sessionStorage.getItem("tokenInfo").length != 0)
        return true;
    else
        return false;
}

function showAuthBlock(visible) {
    if (visible === true) {
        $("[class*='auth']").hide();
        $("[class*='authed']").show();
    }
    else {
        $("[class*='auth']").show();
        $("[class*='authed']").hide();
    }
}

function getUserType(type) {
    return sessionStorage.getItem('userType');
}

function showUserBlock() {
    if(getUserType() == 0) {
        $("[class*='worker']").show();
        $("[class*='employer']").hide();
    }
    else if (getUserType() == 1) {
        $("[class*='employer']").show();
        $("[class*='worker']").hide();
    }
}

$(function () {
    showAuthBlock(checkAuthorize());
    showUserBlock();

    $('#mainmenuItemLogout').click(function(e) {
        sessionStorage.removeItem('tokenInfo');
        sessionStorage.removeItem('userType');
        window.location.replace("index.html");
    });
});