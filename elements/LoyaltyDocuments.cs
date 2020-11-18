
using System;
using System.Xml.Serialization;

public class LoyaltyDocuments{

    
    [XmlAttribute]
    public String Action { get; set; }="I";

     
    public Retailer Retailer{get; set;}
}