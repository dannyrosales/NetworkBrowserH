using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Management;
using System.DirectoryServices;
using System.ComponentModel;
using System.Diagnostics;

namespace NetworkBrowserLib
{
    public class Network : ObservableCollection<Computer>
    {
        private Computer _computer;
        public Network() : base()
        {//ctor

            this._computer = new Computer();

            this._listOfComputerNames = new List<String>();
            this._listOfComputers = new List<DirectoryEntry>();

            RetrieveComputerNames();
        }

        private List<DirectoryEntry> _listOfComputers;
        public List<DirectoryEntry> ListOfComputers
        {
            get
            {
                return _listOfComputers;
            }
            set
            {
                _listOfComputers = value;                
            }
        }

        private List<string> _listOfComputerNames;
        public List<string> ListOfComputerNames
        {
            get
            {
                //_listOfComputerNames = RetrieveComputerNames();
                
                return _listOfComputerNames;
            }
            set
            {
                _listOfComputerNames = value;
            }
        }

        public int ComputerCount
        {
            get
            {
                return GetComputerCount();
            }
        }

        private int GetComputerCount()
        {
            return this.ListOfComputers.Count;
        }   

        private void RetrieveComputerNames()
        {
            //query for all AD directory entries
            DirectoryEntry domainEntry = new DirectoryEntry("WinNT://" + _computer.DomainName);

            //add the 'computer' filter
            domainEntry.Children.SchemaFilter.Add("computer");


            foreach (var item in domainEntry.Children)
            {
                DirectoryEntry de = (DirectoryEntry)item;
                
                _listOfComputers.Add(de);
                _listOfComputerNames.Add(de.Name);
                                          
            }

            //return ListOfComputerNames;
        }



    }
}
