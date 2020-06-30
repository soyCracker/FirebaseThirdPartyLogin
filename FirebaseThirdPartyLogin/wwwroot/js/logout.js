var provider = new firebase.auth.GoogleAuthProvider();

var app = new Vue({
    el: '#logout-button',
    data: {
        logoutBtnSeen:true
    },
    methods:
    {
        logout: function () {
            firebase.auth().signOut().then(function ()
            {              
                // Sign-out successful.          
            }).catch(function (error) {
                // An error happened.
            });
        }
    }
});

firebase.auth().onAuthStateChanged(function (user) {
    if (!user)
    {
        location.href = window.location.origin + '/login';
    }
});