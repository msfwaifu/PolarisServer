﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolarisServer.Party
{
    class Party
    {
        public string name;
        private List<Client> members;
        private Client host;

        public Party(string name, Client host)
        {
            this.name = name;
            this.host = host;
            addClientToParty(host);
        }

        public void addClientToParty(Client c)
        {
            members.Add(c);
            //TODO do stuff like send the "add to party" packet.
        }

        public void removeClientFromParty(Client c)
        {
            if(!members.Contains(c))
            {
                Logger.WriteWarning("[PTY] Client {0} was trying to be removed from {1}, but he was never in {1}!", c.User.Username, name);
                return;
            }

            members.Remove(c);
            //TODO do stuff like send the "remove from party" packet.
        }

        public bool hasClientInParty(Client c)
        {
            return members.Contains(c);
        }

        public Client getPartyHost()
        {
            return host;
        }

        public int getSize()
        {
            return members.Count;
        }

        public List<Client> getMembers()
        {
            return members;
        }

    }
}