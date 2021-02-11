using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinRemaxTaianaAntokhine
{
  public class clsListAgents
    {
        private Dictionary<string, clsAgent> agentList;

        public clsListAgents()
        {
            agentList = new Dictionary<string, clsAgent>();
        }

        public int Quantity
        {
            get => agentList.Count;
        }

        public Dictionary<string, clsAgent>.ValueCollection Elements
        {
            get => agentList.Values;
        }

        public bool Exist(string number)
        {
            return agentList.ContainsKey(number);
        }

        public bool Add(clsAgent agent)
        {
            if (Exist(agent.AgentId.ToString()) == false)
            {
                agentList.Add(agent.AgentId.ToString(), agent);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string number)
        {
            return agentList.Remove(number);
        }

        public clsAgent Find(string number)
        {
            if (Exist(number) == true)
            {
                return agentList[number];
            }
            else
            {
                return null;
            }
        }

        public string Display()
        {
            string info = "\n====================\n";
            foreach (clsAgent elem in agentList.Values)
            {
                info += elem.DisplayAgent() + "\n------------------\n";
            }
            return info;
        }
    }
}
















