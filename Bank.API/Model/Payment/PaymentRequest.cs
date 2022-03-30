using System;

namespace Bank.API.Model.Payment
{
    public class PaymentRequest
    {

        public Card Card { get; set; }
        public Double Amount { get; set; }
        public int Currency { get; set; }
    }

    public class Card
    {
        public string CardNumber { get; set; }
        public String Expiry { get; set; }
        public int CVV { get; set; }
    }

}
