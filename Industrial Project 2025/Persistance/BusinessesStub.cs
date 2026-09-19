using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial_Project_2025
{
    internal class BusinessesStub
    {
        private List<Business> businesses = new List<Business>();

        public BusinessesStub()
        {
            Business business1 = new Business(1, "Cedar Creek", "305 Main st, Steinbach, MB R5G 1R1", "ilovesoy@cedarcreek.ca", "2043461010");
            Business business2 = new Business(2, "Tranquil Ranch", "66 Chancellors Cir, Winnipeg, MB R3T 2N2", "cornisthebest@tranquilranch.ca", "2043802837");
            Business business3 = new Business(3, "Chuckleberry Acres", "300 Portage Ave, Winnipeg, MB R3C 5S4", "wheatsucks@chuckleberryacres.ca", "2043801235");
            Business business4 = new Business(4, "Whispering Pine Farms", "231 Main St, Steinbach, MB R5A 1B4", "wheatrocks@whisperingpinefarms", "2043460283");
            Business business5 = new Business(5, "Blossom Hill Farm", "1 Forks Market Rd, Winnipeg, MB R3C 4L9", "canola@blossomhillfarm.ca", "2043469349");
            businesses.Add(business1);
            businesses.Add(business2);
            businesses.Add(business3);
            businesses.Add(business4);
            businesses.Add(business5);
        }

        public List<Business> getBusinessses()
        {
            return businesses;
        }

        public List<string> getBusinessNames()
        {
            List<string> businessNames = new List<string>();
            foreach (Business business in businesses)
            {
                businessNames.Add(business.GetName());
            }
            return businessNames;
        }

        public Business getBusinessById(int id)
        {
            foreach (Business business in businesses)
            {
                if (business.GetId() == id)
                {
                    return business;
                }
            }
            return null;
        }

        public Business getBusinessByName(string name)
        {
            foreach (Business business in businesses)
            {
                if (business.GetName() == name)
                {
                    return business;
                }
            }
            return null;
        }

        public void addBusiness(Business business)
        {
            businesses.Add(business);
        }

        public void removeBusiness(int id)
        {
            foreach (Business business in businesses)
            {
                if (business.GetId() == id)
                {
                    businesses.Remove(business);
                    return;
                }
            }
        }

        public void updateBusiness(Business business)
        {
            foreach (Business b in businesses)
            {
                if (b.GetId() == business.GetId())
                {
                    b.SetName(business.GetName());
                    b.SetAddress(business.GetAddress());
                    b.SetEmail(business.GetEmail());
                    b.SetPhoneNumber(business.GetPhoneNumber());
                    return;
                }
            }
        }

        public int getBusinessCount()
        {
            return businesses.Count;
        }
    }
}
