using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization; 
using System.Xml.Serialization;


namespace CouponsToHqs
{class Program

    {
        static void Main(string[] args)
  {
      Retailer Retailer=new Retailer();

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
    
    //Retailer.Documents=DocumentsList;
    LoyaltyDocuments LoyaltyDocuments=new LoyaltyDocuments();
    LoyaltyDocuments.Retailer=Retailer;

        
    WriteXML(LoyaltyDocuments);

    }
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


public class LoyaltyDocuments{

    
    [XmlAttribute]
    public String Action { get; set; }="I";

     
    public Retailer Retailer{get; set;}
}

public class Retailer{

    [XmlAttribute]
    public String Id { get; set; }="1";

    
    public List<Document> Documents{get; set;}

    public Retailer(){
        this.Documents=new List<Document>();
    }
}

    

public class Details{
    public String Type{ get ; set; }="3";
    public String Action{ get; set; }="0";
    public String Barcode{ get; set; }
    public String ID{ get; set; }
    public String IsUnique{ get; set; }="0";
    public String TriggerPromotionId{ get; set; }="0";
    public String Value{ get; set; }="0.0000";
    public String Qty{ get; set; }="1";
    public String TenderGroup{ get; set; }="1";
    public String BarcodeProgrammingId{ get; set; }="5";


    

}

public class ValidationRules{
    public String StartDate{ get; set; }
    public String EndDate{ get; set; }
    public String RedemptionType{ get; set; }="2";
    public String RedemptionLocation{ get; set; }="2";
    public String RedemptionMode{ get; set; }="1";
}

public class Document{
    public Details Details{ get; set; }
    public ValidationRules ValidationRules{ get; set; }

}




}
