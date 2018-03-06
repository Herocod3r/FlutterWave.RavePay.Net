FlutterWave.RavePay.Net
=======================

A .NET library for Flutterwave Ravepay payment gateway

<https://ci.appveyor.com/project/okezieokpara/flutterwave-ravepay-net/branch/mast>

The following services can be carried out with this library:

1.  Card Charge

2.  Account Charge

3.  Transaction Validation

 

### Card Charge

To successfully charge a user credit card, first make sure you have the
`PBFPubKey `that you got from the checkout button on your RavePay dashboard.
Then you use the `RaveCardCharge `class like so:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
var raveConfig = new RavePayConfig(<your-PBFPubKey>, false);
// The second(boolean) paramater toggles between live and test mode. The default value is false

var cardCharge = new RaveCardCharge(raveConfig);
   var cardParams = new CardChargeParams(recurringPbKey, "Okezie", "Okpara", "rave-test-card@mailinator.com",
                4556)
            {
                CardNo = "5438898014560229",
                Cvv = "789",
                Expirymonth = "09",
                Expiryyear = "19",
                TxRef = tranxRef
            };

// Alternatively you can create an instance of a card object.
 var debitCard = new Card("5438898014560229", "09", "19", "780");
//And use it like so:

  var cardParams = new CardChargeParams(recurringPbKey, "Okezie", "Okpara", "test-card@mailinator.com",
                4556, debitCard)
            {
                TxRef = tranxRef
            };

// And to make a charge request.
var chargeResponse = await cardCharge.Charge(cardParams);
// Then you can query the charge response. Especially to find the 'Suggested Auth' Property:
 if (chargeResponse .Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";

                // Since the suggested auth was 'pin' we make a second request. Sending the pin and otp.
                chargeResponse = cardCharge.Charge(cardParams).Result;
            }
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

After each transaction it is a nice idea to validate the status of the
transaction. For this purpose we will validate our last transaction. To validate
a transaction, you need the `txRef` value and `otp `of that transaction. Here is
an example:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        var raveConfig = new RavePayConfig(recurringPbKey, false);
        var cardCharge = new RaveCardCharge(raveConfig);
        var verifyResponse = await cardCharge.ValidateCharge(new CardValidateChargeParams(recurringPbKey, txRef, "12345"));
        // You can now query the response message and status of the transaction
         Trace.WriteLine($"Status: {verifyResponse.Status}");
         Trace.WriteLine($"Message: {verifyResponse.Message}");
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
