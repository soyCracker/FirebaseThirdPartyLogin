# FirebaseThirdPartyLogin

FirebaseThirdPartyLogin _Layout.cshtm firebaseConfig change to yours  
```
var firebaseConfig =
        {
            apiKey: "yours",
            authDomain: "yours",
            databaseURL: "yours",
            projectId: "yours",
            storageBucket: "yours",
            messagingSenderId: "yours",
            appId: "yours",
            measurementId: "yours"
        };
```
  
FirebaseAuthEntity FirebaseAuthDBContext.cs UseSqlServer change to yours
```C#
optionsBuilder.UseSqlServer("yours");
```
