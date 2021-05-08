using Google.Cloud.Firestore;

namespace SentarsMedicals
{
    [FirestoreData]
    public class docinfo

    {   [FirestoreProperty]
        public string NIC { get; set; }
        [FirestoreProperty]
        public string Fname { get; set; }
        [FirestoreProperty]
        public string Lname { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string ContactNo { get; set; }
        [FirestoreProperty]
        public string Sarea { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
        [FirestoreProperty]
        public string Cpassword { get; set; }
        [FirestoreProperty]
        public string About { get; set; }
        [FirestoreProperty]
        public string Photo{ get; set; }
        [FirestoreProperty]
        public string Date { get; set; }

    }
}