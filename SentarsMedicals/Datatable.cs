using Google.Cloud.Firestore;
using System.Data;

namespace SentarsMedicals
{
    internal class Datatable : DataTable
    {
        private CollectionReference collectionReference;

        public Datatable(CollectionReference collectionReference)
        {
            this.collectionReference = collectionReference;
        }
    }
}