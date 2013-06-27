using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Management;
using System.DirectoryServices;

namespace NetworkBrowserLib
{
    public class Computer : INotifyPropertyChanged
    {

        public Computer()
        {//ctor

        }

        public Computer(string name, string domainName)
        {//ctor
            this.Name = name;
            this.DomainName = domainName;
        }

        private bool _isCenter;
        public Boolean IsCenter
        {
            get
            {
                return _isCenter;
            }
            set
            {
                _isCenter = value;
            }
        }

        private string _name;
        public String Name
        {
            get
            {
                this.GetLocalComputerName();
                return _name;
            }

            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }

        }

        private string _domainName;
        public String DomainName
        {
            get
            {
                this.GetLocalComputerName();
                return _domainName;
            }
            set
            {
                _domainName = value;
                NotifyPropertyChanged("DomainName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public void GetLocalComputerName()
        { 
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;

            String query_command = "SELECT * FROM Win32_ComputerSystem";
            ManagementScope msc = new ManagementScope("\\root\\cimv2");

            SelectQuery select_query = new SelectQuery(query_command);

            query = new ManagementObjectSearcher(msc, select_query);
            queryCollection = query.Get();
            
            foreach (ManagementObject management_object in queryCollection)
	        {                
                this._domainName = (string)management_object["Domain"] ; 
                this._name = (string)management_object["Name"];
	        }

        }//end method

    }
}
