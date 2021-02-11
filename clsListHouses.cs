using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
   public class clsListHouses
    {
        private Dictionary<string, clsHouse> houseList;

        public clsListHouses()
        {
            houseList = new Dictionary<string, clsHouse>();
        }

        public int Quantity
        {
            get => houseList.Count;
        }

        public Dictionary<string, clsHouse>.ValueCollection Elements
        {
            get => houseList.Values;
        }

        public bool Exist(string id)
        {
            return houseList.ContainsKey(id);
        }
        public bool Add(clsHouse house)
        {
            if (Exist(house.RefCientId.ToString()) == false){
                houseList.Add(house.RefCientId.ToString(), house);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            return houseList.Remove(id);
        }

        public clsHouse Find(string id)
        {
            if(Exist(id) == true)
            {
                return houseList[id];
            }
            else
            {
                return null;
            }
        }

        public string Display()
        {
            string info = "\n========================\n";
            foreach(clsHouse elem in houseList.Values)
            {
                info += elem.DisplayHouse() + "\n-----------------\n";
            }
            return info;
        }








    }
}
