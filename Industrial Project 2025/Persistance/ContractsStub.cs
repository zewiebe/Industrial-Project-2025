using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Industrial_Project_2025
{
    internal class ContractsStub
    {
        private List<Contract> contracts = new List<Contract>();
        private BusinessesStub businessesStub = new BusinessesStub();

        public ContractsStub()
        {
            Contract contract1 = new Contract(1, stringtoDateTime("01/01/2025"), stringtoDateTime("01/01/2025"), stringtoDateTime("02/04/2025"), 1500.0f, 1500.0f, 350.0f, 0.0f, businessesStub.getBusinessById(1), Constants.Commodity.Corn, true, true);
            Contract contract2 = new Contract(2, stringtoDateTime("17/02/2025"), stringtoDateTime("17/02/2025"), stringtoDateTime("31/03/2025"), 3200.0f, 3200.0f, 125.0f, 0.0f, businessesStub.getBusinessById(2), Constants.Commodity.Wheat, true, false);
            Contract contract3 = new Contract(3, stringtoDateTime("19/02/2025"), stringtoDateTime("19/02/2025"), stringtoDateTime("01/04/2025"), 2300.0f, 2300.0f, 330.0f, 0.0f, businessesStub.getBusinessById(3), Constants.Commodity.Soybean_Meal, true, false);
            Contract contract4 = new Contract(4, stringtoDateTime("28/02/2025"), stringtoDateTime("28/02/2025"), stringtoDateTime("02/04/2025"), 2200.0f, 2200.0f, 250.0f, 0.0f, businessesStub.getBusinessById(4), Constants.Commodity.Canola_Meal, true, false);
            Contract contract5 = new Contract(5, stringtoDateTime("27/03/2025"), stringtoDateTime("27/03/2025"), stringtoDateTime("03/04/2025"), 3000.0f, 3000.0f, 870.0f, 0.0f, businessesStub.getBusinessById(5), Constants.Commodity.Corn, true, false);
            Contract contract6 = new Contract(6, stringtoDateTime("05/03/2025"), stringtoDateTime("05/03/2025"), stringtoDateTime("05/04/2025"), 3500.0f, 3500.0f, 480.0f, 0.0f, businessesStub.getBusinessById(1), Constants.Commodity.Corn, true, false);
            Contract contract7 = new Contract(7, stringtoDateTime("12/03/2025"), stringtoDateTime("12/03/2025"), stringtoDateTime("10/04/2025"), 1270.0f, 1270.0f, 170.0f, 0.0f, businessesStub.getBusinessById(2), Constants.Commodity.Wheat, true, false);
            Contract contract8 = new Contract(8, stringtoDateTime("25/03/2025"), stringtoDateTime("25/03/2025"), stringtoDateTime("13/04/2025"), 1100.0f, 1100.0f, 90.0f, 0.0f, businessesStub.getBusinessById(3), Constants.Commodity.Soybean_Meal, true, false);
            Contract contract9 = new Contract(9, stringtoDateTime("27/03/2025"), stringtoDateTime("27/03/2025"), stringtoDateTime("15/04/2025"), 900.0f, 900.0f, 85.0f, 0.0f, businessesStub.getBusinessById(4), Constants.Commodity.Canola_Meal, true, false);
            Contract contract10 = new Contract(10, stringtoDateTime("27/03/2025"), stringtoDateTime("27/03/2025"), stringtoDateTime("23/04/2025"), 700.0f, 700.0f, 35.0f, 0.0f, businessesStub.getBusinessById(5), Constants.Commodity.Corn, true, false);

            contracts.Add(contract1);
            contracts.Add(contract2);
            contracts.Add(contract3);
            contracts.Add(contract4);
            contracts.Add(contract5);
            contracts.Add(contract6);
            contracts.Add(contract7);
            contracts.Add(contract8);
            contracts.Add(contract9);
            contracts.Add(contract10);
        }

        private DateTime stringtoDateTime(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", null);
        }

        public List<Contract> getContracts()
        {
            return contracts;
        }

        public Contract getContractById(int id)
        {
            foreach (Contract contract in contracts)
            {
                if (contract.GetContractId() == id)
                {
                    return contract;
                }
            }
            return null;
        }

        public void addContract(Contract contract)
        {
            contracts.Add(contract);
        }

        public void removeContract(Contract contract)
        {
            contracts.Remove(contract);

        }

        public void removeContract(int id)
        {
            foreach (Contract contract in contracts)
            {
                if (contract.GetContractId() == id)
                {
                    contracts.Remove(contract);
                    return;
                }
            }
        }

        public void updateContract(Contract contract)
        {
            foreach (Contract c in contracts)
            {
                if (c.GetContractId() == contract.GetContractId())
                {
                    c.SetCreationDate(contract.GetCreationDate());
                    c.SetStartDate(contract.GetStartDate());
                    c.SetEndDate(contract.GetEndDate());
                    c.SetPrice(contract.GetPrice());
                    c.SetPriceBenchmark(contract.GetPriceBenchmark());
                    c.SetQuantity(contract.GetQuantity());
                    c.SetReceived(contract.GetReceived());
                    c.SetSupplier(contract.GetSupplier());
                    c.SetCommodity(contract.GetCommodity());
                    c.SetOpen(contract.IsOpen());
                    c.SetLate(contract.IsLate());
                    return;
                }
            }
        }

        public int getContractCount()
        {
            return contracts.Count;
        }
    }
}
