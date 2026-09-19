
namespace Industrial_Project_2025
{
    internal class Business
    {
        private int _id;
        private string name;
        private string address;
        private string email;
        private string phoneNumber;
        private List<int> ratings;

        public Business(int id, string name, string address, string email, string phoneNumber)
        {
            this._id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.ratings = new List<int>();
        }

        public Business()
        {
            this.ratings = new List<int>();
        }

        public int GetId() => _id;
        public void SetId(int value) => _id = value;
        public string GetName() => name;
        public void SetName(string value) => name = value;

        public string GetAddress() => address;
        public void SetAddress(string value) => address = value;

        public string GetEmail() => email;
        public void SetEmail(string value) => email = value;

        public string GetPhoneNumber() => phoneNumber;
        public void SetPhoneNumber(string value) => phoneNumber = value;

        public List<int> GetRatings() => ratings;
        public void AddRating(int rating) => ratings.Add(rating);

        public double GetAverageRating()
        {
            if (ratings.Count == 0)
            {
                return 0;
            }

            double sum = 0;
            foreach (int rating in ratings)
            {
                sum += rating;
            }
            return sum / ratings.Count;
        }
    }
}