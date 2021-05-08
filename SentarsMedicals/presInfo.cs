using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentarsMedicals
{
    [FirestoreData]
    public class presInfo
    {
        
            [FirestoreProperty]
            public string channelNo { get; set; }
            [FirestoreProperty]
            public string date { get; set; }
            [FirestoreProperty]
            public string prescription { get; set; }
            [FirestoreProperty]
            public string problem { get; set; }
            [FirestoreProperty]
            public string userEmail { get; set; }
            [FirestoreProperty]
            public string username { get; set; }
         
          

        
    }
}
