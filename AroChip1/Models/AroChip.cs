using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AroChip1.Models
{
    public class PaymentOptions
    {
        public Card card { get; set; }
        public List<Card> existingCards { get; set; }
        public decimal Total { get; set; }

        public PaymentOptions(int total)
        {
            card = new Card();
            existingCards = Card.ExampleCards();
            Total = total/100;
        }
    }

    public class Card
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }

        public static List<Card> ExampleCards()
        {
            List<Card> list = new List<Card>();
            list.Add(new Card { CardName = "Wilbur Townsend", CardExpiryDate = "07/13", CardNumber = "45**-****-****-*563" });
            list.Add(new Card { CardName = "Thomas Horrobin", CardExpiryDate = "07/14", CardNumber = "45**-****-****-*454" });
            list.Add(new Card { CardName = "Tyrone B", CardExpiryDate = "02/13", CardNumber = "45**-****-****-*253" });
            return list;
        }
    }

    public class AroChipOrder
    {
        public Dictionary<Item, int> items { get; set; }

        public AroChipOrder()
        {
            items = new Dictionary<Item, int>();
            foreach (Item i in Item.GetAroStoreItems())
            {
                items.Add(i, 0);
            }
        }

        public decimal GetOrderTotal()
        {
            decimal total = 0m;
            foreach (KeyValuePair<Item,int> i in items)
            {
                total += i.Key.price * i.Value;
            }
            return total;
        }
    }

    public class Item
    {
        public static List<Item> GetAroStoreItems()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item("Chips", 2m));
            items.Add(new Item("Burger", 4.5m));
            items.Add(new Item("Fish", 2.5m));
            items.Add(new Item("CrumbberFish", 2.5m));
            items.Add(new Item("Doenut", 1m));
            return items;
        }

        public string name { get; set; }
        public decimal price { get; set; }

        public Item(string n, decimal p)
        {
            name = n;
            price = p;
        }
    }
}