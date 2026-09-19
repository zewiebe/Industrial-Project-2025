using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial_Project_2025
{
    internal class Load
    {
        int id;
        private float quantity;
        private DateTime date;
        private Contract contract;

        public Load(int id, float quantity, DateTime date, Contract contract)
        {
            this.id = id;
            this.quantity = quantity;
            this.date = date;
            this.contract = contract;
        }
        public int GetId() => id;
        public int SetId(int newId) => id =newId;
        public float GetQuantity() => quantity;
        public void SetQuantity(float value) => quantity = value;

        public Contract GetContract() => contract;
        public void SetContract(Contract value) => contract = value;

        public DateTime GetDate() => date;
        public void SetDate(DateTime value) => date = value;

    }
}
