var provider = new firebase.auth.GoogleAuthProvider();

var app = new Vue({
    el: '#logout-button',
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

var app2 = new Vue({
    el: '#logout-button',
    data:
    {
        seen: true
    },
    methods:
    {
        switchSeen: function () {
            seen = true;
        }
    }
});

firebase.auth().onAuthStateChanged(function (user) {
    if (user)
    {
        
    }
    else
    {
        location.href = window.location.origin + '/login';
    }
});