﻿using Newtonsoft.Json;

namespace Flutterwave.Ravepay.Net.Payments
{
    /// <summary>
    /// Represents the parameters sent to the API for token payment
    /// </summary>
   public class RaveTokenChargeParams: IChargeParams
    {
        public RaveTokenChargeParams(string firstName, string lastName, string email, string txRef, decimal amount)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            TxRef = txRef;
            Amount = amount;
        }
        /// <summary>
        /// This is a unique key generated for each button created on Rave’s dashboard. It starts with a prefix FLWSECK and ends with suffix X.
        /// </summary>
        [JsonProperty("SECKEY")]
        public string Seckey { get; set; }

        /// <summary>
        /// This is the embed_token property returned from the call to charge a card e.g."chargeToken":{"user_token":"0209","embed_token":"flw-t0-9f3aa69a806f6440fbb78cc9e8b2f135-k3n"}
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("PBFPubKey")]
        public string PbfPubKey { get; set; }
        /// <summary>
        /// This is the specified currency to charge the card in. (Defaults to NGN)
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// This is the pair country for the transaction with respect to the currency. See a list of Multicurrency support here Multicurrency Payments https://flutterwavedevelopers.readme.io/v1.0/docs/multicurrency-payments
        ///  (Defaults to NG)
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        /// <summary>
        /// This is the amount to be charged from card it is passed as - ("amount":10)
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// This is the unique reference, unique to the particular transaction being carried out. It is generated by the merchant for every transaction
        /// </summary>
        [JsonProperty("txRef")]
        public string TxRef { get; set; }
        /// <summary>
        /// This is the fingerpringt for the device being used. It can be generated using a library on whatever platform is being used.
        /// </summary>
        [JsonProperty("device_fingerprint")]
        public string DeviceFingerprint { get; set; }

        /// <summary>
        /// This is the email address of the customer
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// This is the phone number of the customer.
        /// </summary>
        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// This is the first name of the card holder or the customer.
        /// </summary>
        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// This is the last name of the card holder or the customer.
        /// </summary>
        [JsonProperty("lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// 		
        /// IP - Internet Protocol. This represents the current IP address of the customer carrying out the transaction.
        /// </summary>
        [JsonProperty("IP")]
        public string Ip { get; set; }

        /// <summary>
        /// This is a custom description added by the merchant.
        /// </summary>
        [JsonProperty("narration")]
        public string Narration { get; set; }


    }

}
