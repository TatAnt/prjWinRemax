using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
  public  class clsHouse
    {
        private int houseId;
        private string location;
        private decimal price;
        private int age;
        private int livingSpace;
        private int bedroom;
        private int bathroom;
        private int garage;
        private bool pool;
        private bool basement;
        private string houseType; //   chalet, castle,singleFamily, bungalow,cottage, cabin,    mobileHome
        private string roofType; //  flat,    mansard,  hip,   openCable,   boxCable,   pyramid
        private string status;
        private int refCientId;
        //listDate?
       // private string referToClient; //or referToAgent? 

        public clsHouse()
        {
            this.houseId = this.refCientId = 0;
            this.location = this.status = this.houseType = this.roofType = "undefined";
            this.price = 0.0M;
            this.age = this.livingSpace = this.bedroom = this.bathroom = this.garage = 0;
            this.pool = this.basement = false;
        }

        public clsHouse(int houseId, string location, decimal price, int age, int livingSpace, int bedroom, int bathroom, int garage, bool pool, bool basement, string houseType, string roofType, string status, int refCientId)
        {
            this.houseId = houseId;
            this.location = location;
            this.price = price;
            this.age = age;
            this.livingSpace = livingSpace;
            this.bedroom = bedroom;
            this.bathroom = bathroom;
            this.garage = garage;
            this.pool = pool;
            this.basement = basement;
            this.houseType = houseType;
            this.roofType = roofType;
            this.status = status;
            this.refCientId = refCientId;
        }

        public int HouseId { get => houseId; set => houseId = value; }
        public string Location { get => location; set => location = value; }
        public decimal Price { get => price; set => price = value; }
        public int Age { get => age; set => age = value; }
        public int LivingSpace { get => livingSpace; set => livingSpace = value; }
        public int Bedroom { get => bedroom; set => bedroom = value; }
        public int Bathroom { get => bathroom; set => bathroom = value; }
        public int Garage { get => garage; set => garage = value; }
        public bool Pool { get => pool; set => pool = value; }
        public bool Basement { get => basement; set => basement = value; }
        public string HouseType { get => houseType; set => houseType = value; }
        public string RoofType { get => roofType; set => roofType = value; }
        public string Status { get => status; set => status = value; }
        public int RefCientId { get => refCientId; set => refCientId = value; }

        public void RegisterHouse(int houseId, string location, decimal price, int age, int livingSpace, int bedroom, int bathroom, int garage, bool pool, bool basement, string houseType, string roofType, int refCientId)
        {
            this.houseId = houseId;
            this.location = location;
            this.price = price;
            this.age = age;
            this.livingSpace = livingSpace;
            this.bedroom = bedroom;
            this.bathroom = bathroom;
            this.garage = garage;
            this.pool = pool;
            this.basement = basement;
            this.houseType = houseType;
            this.roofType = roofType;
            this.refCientId = refCientId;
            this.status = "active";
        }

        public decimal CalculateSalesCommission()
        {
           return this.price * 0.05M;
        }
        public string DisplayHouse()
        {
            string info = "House ID: " + this.HouseId +
                          "\nLocation: " + this.Location +
                          "\nAsking price: " + this.Price +
                          "\nAge: " + this.Age +
                          "\nLiving space: " + this.LivingSpace +
                          "\nNumber of bedrooms: " + this.Bedroom +
                          "\nNumber of bathrooms: " + this.Bathroom +
                          "\nGarage: " + this.Garage +
                          "\nPool: " + this.Pool +
                          "\nBasement: " + this.Basement +
                          "\nType of the House: " + this.HouseType +
                          "\nType of the Roof: " + this.RoofType +
                          "\nClent Number: " + refCientId + "\n";


                return info;
        }












    }



}
