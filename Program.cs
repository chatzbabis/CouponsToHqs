using System;
using System.IO;

namespace CouponsToHqs
{class Program

    {
        static void Main(string[] args)
  {
      Retailer Retailer=new Retailer();

    //read values from csv file and generate objects
       using(var reader = new StreamReader(@"C:\Users\chatz\OneDrive\Έγγραφα\GitHub\CouponsToHqs\tests.csv"))
    {
    
        while (!reader.EndOfStream)
        {
            Document Document = new Document();
            Details Details = new Details();
            ValidationRules ValidationRules= new ValidationRules();
            var line = reader.ReadLine();
            var values = line.Split(';');

            Details.Barcode=values[0];
            Details.ID=values[1];
            ValidationRules.StartDate=values[2];
            ValidationRules.EndDate=values[3];
            Document.Details=Details;
            Document.ValidationRules=ValidationRules;
            Retailer.Documents.Add(Document);  
        }
    }
  
    foreach (var Document in Retailer.Documents)
        {
            Console.WriteLine(Document.Details.Barcode);
            Console.WriteLine(Document.ValidationRules.StartDate);
             Console.WriteLine(Document.ValidationRules.EndDate);
             Console.WriteLine(" ");
        }
    
    LoyaltyDocuments LoyaltyDocuments=new LoyaltyDocuments();
    LoyaltyDocuments.Retailer=Retailer;
   
    WriteXML(LoyaltyDocuments);
    }

    //Serialize object and create xml
    public static void WriteXML(LoyaltyDocuments LoyaltyDocuments)  
    {  
        System.Xml.Serialization.XmlSerializer writer =
            new System.Xml.Serialization.XmlSerializer(typeof(LoyaltyDocuments));  
  
        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";  
        System.IO.FileStream file = System.IO.File.Create(path);  
  
        writer.Serialize(file, LoyaltyDocuments);  
        file.Close();  
    }

    }

}
