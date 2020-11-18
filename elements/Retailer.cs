using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public class Retailer{

    [XmlAttribute]
    public String Id { get; set; }="1";

    
    public List<Document> Documents{get; set;}

    public Retailer(){
        this.Documents=new List<Document>();
    }
}