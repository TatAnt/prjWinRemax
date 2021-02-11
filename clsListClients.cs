using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
   public class clsListClients
    {
        private Dictionary<string, clsClient> clientList;

        public clsListClients()
        {
            clientList = new Dictionary<string, clsClient>();
        }

        public int Quantity
        {
            get => clientList.Count;
        }

        public Dictionary<string, clsClient>.ValueCollection Elements
        {
            get => clientList.Values;
        }

        public bool Exist(string number)
        {
            return clientList.ContainsKey(number);
        }


        public bool Add(clsClient client)
        {
            if(Exist(client.ClientId.ToString()) == false)
            {
                clientList.Add(client.ClientId.ToString(), client);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string number)
        {
            return clientList.Remove(number);
        }

        public clsClient Find(string number)
        {
            if(Exist(number) == true)
            {
                return clientList[number];
            }
            else
            {
                return null;
            }
        }

        public string Display()
        {
            string info = "\n====================\n";
            foreach(clsClient elem in clientList.Values)
            {
                info += elem.DisplayClient() + "\n------------------\n";
            }
            return info;
        }




    }
}
