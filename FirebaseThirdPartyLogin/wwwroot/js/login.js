var provider = new firebase.auth.GoogleAuthProvider();

var app = new Vue({
    el: '#google-login',
    methods:
    {
        login: function () {
            firebase.auth().signInWithRedirect(provider);
            firebase.auth().getRedirectResult().then(function (result) {
                if (result.credential) {
                    // This gives you a Google Access Token. You can use it to access the Google API.
                    var token = result.credential.accessToken;
                }
                // The signed-in user info.
                var user = result.user;
            }).catch(function (error) {
                // Handle Errors here.
                var errorCode = error.code;
                var errorMessage = error.message;
                // The email of the user's account used.
                var email = error.email;
                // The firebase.auth.AuthCredential type that was used.
                var credential = error.credential;
            });
        }
    }
});

var app2 = new Vue({
    el: '#logout-button',
    data: {
        logoutBtnSeen:false
    }
});

firebase.auth().onAuthStateChanged(function (user) {
    if (user) {
        

        // User is signed in.
        console.log("Uid:" + user.uid);
        console.log("DisplayName:" + user.displayName);
        console.log("Email:" + user.email);
        console.log("EmailVerified:" + user.emailVerified);
        console.log("PhotoURL:" + user.photoURL);
        console.log("IsAnonymous:" + user.isAnonymous);

        firebase.auth().currentUser.getIdToken(true).then(function (idToken) {
            console.log("ID Token: ", idToken);
            console.log("test");

            var userData =
            {
                ['AccessToken']: idToken,
                ['Uid']: user.uid,
                ['DisplayName']: user.displayName,
                ['Email']: user.email,
                ['EmailVerified']: user.emailVerified,
                ['PhotoURL']: user.photoURL,
                ['IsAnonymous']: user.isAnonymous,
            };

            postData(window.location.origin + "/api/auth", userData)
        }).catch(function (error) {
            // Handle error

        });
    }
});

function postData(url, data) {
    axios.post(url, data)
        .then(res => {
            console.log(res);
            //跳轉回首頁
            //location.href = window.location.origin;
        })
        .catch(err => { console.log(err) })
}