using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial_Project_2025
{
    internal class Contract
    {
        private int contractId;
        private DateTime creationDate;
        private DateTime startDate;
        private DateTime endDate;
        private float price;
        private float priceBenchmark;
        private float quantity;
        private float received;
        private Business supplier;
        private Constants.Commodity commodity;
        private bool open;
        private bool isLate;

        // Constructor
        public Contract(int contractId, DateTime creationDate, DateTime startDate, DateTime endDate,
                         float price, float priceBenchmark, float quantity, float received,
                         Business supplier, Constants.Commodity commodity, bool open, bool isLate)
        {
            this.contractId = contractId;
            this.creationDate = creationDate;
            this.startDate = startDate;
            this.endDate = endDate;
            this.price = price;
            this.priceBenchmark = priceBenchmark;
            this.quantity = quantity;
            this.received = received;
            this.supplier = supplier;
            this.commodity = commodity;
            this.open = open;
            this.isLate = isLate;
        }

        public Contract()
        { }


        // Get and Set Methods
        public int GetContractId() => contractId;
        public void SetContractId(int value) => contractId = value;

        public DateTime GetCreationDate() => creationDate;
        public void SetCreationDate(DateTime value) => creationDate = value;

        public DateTime GetStartDate() => startDate;
        public void SetStartDate(DateTime value) => startDate = value;

        public DateTime GetEndDate() => endDate;
        public void SetEndDate(DateTime value) => endDate = value;

        public float GetPrice() => price;
        public void SetPrice(float value) => price = value;

        public float GetPriceBenchmark() => priceBenchmark;
        public void SetPriceBenchmark(float value) => priceBenchmark = value;

        public float GetQuantity() => quantity;
        public void SetQuantity(float value) => quantity = value;

        public float GetReceived() => received;
        public void SetReceived(float value) => received = value;

        public Business GetSupplier() => supplier;
        public void SetSupplier(Business value) => supplier = value;

        public Constants.Commodity GetCommodity() => commodity;
        public void SetCommodity(Constants.Commodity value) => commodity = value;

        public bool IsOpen() => open;
        public void SetOpen(bool value) => open = value;

        public bool IsLate() => isLate;
        public void SetLate(bool value) => isLate = value;

    }
}
