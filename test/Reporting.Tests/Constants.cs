using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Tests
{
    internal class Constants
    {
        public const string JsonStringWithFullData =
@"{
  ""hotel"": {
  	""hotelID"": 7294,
    ""classification"": 5, 
    ""name"": ""Kempinski Bristol Berlin"", 
    ""reviewscore"": 8.3
  }, 
  ""hotelRates"": [
    {
      ""adults"": 2, 
      ""los"": 1, 
      ""price"": {
        ""currency"": ""EUR"", 
        ""numericFloat"": 116.1, 
        ""numericInteger"": 11610
      }, 
      ""rateDescription"": ""Unsere Classic Zimmer bieten Ihnen allen Komfort, den Sie von einem 5-Sterne-Hotel erwarten. Helle und freundliche Farben sorgen f\u00fcr ein angenehmes Ambiente, damit Sie Ihren Aufenthalt im Herzen Berlins voll und ganz genie\u00dfen k\u00f6nnen. 20m\u00b2. Doppelbett oder zwei separate Betten. Max. Kapazit\u00e4t: 2 Erwachsene oder 1 Erwachsener und 1 Kind.      "", 
      ""rateID"": ""-739857498"", 
      ""rateName"": ""Classic Zimmer - Fr\u00fchbucher Rate"", 
      ""rateTags"": [
        {
          ""name"": ""breakfast"", 
          ""shape"": false
        }
      ], 
      ""targetDay"": ""2016-03-15T00:00:00.000+01:00""
    }, 
    {
      ""adults"": 2, 
      ""los"": 1, 
      ""price"": {
        ""currency"": ""EUR"", 
        ""numericFloat"": 129, 
        ""numericInteger"": 12900
      }, 
      ""rateDescription"": ""Unsere Classic Zimmer bieten Ihnen allen Komfort, den Sie von einem 5-Sterne-Hotel erwarten. Helle und freundliche Farben sorgen f\u00fcr ein angenehmes Ambiente, damit Sie Ihren Aufenthalt im Herzen Berlins voll und ganz genie\u00dfen k\u00f6nnen. 20m\u00b2. Doppelbett oder zwei separate Betten. Max. Kapazit\u00e4t: 2 Erwachsene oder 1 Erwachsener und 1 Kind.      "", 
      ""rateID"": ""-740789668"", 
      ""rateName"": ""Classic Zimmer - Beste Flexible Rate"", 
      ""rateTags"": [
        {
          ""name"": ""breakfast"", 
          ""shape"": false
        }
      ], 
      ""targetDay"": ""2016-03-15T00:00:00.000+01:00""
    }
  ]
}";

        public const string JsonStringWithInvalidData =

@"{
  ""hotel"": {
  	""hotelID"": 7294,
    ""classification"": 5, 
    ""name"": ""Kempinski Bristol Berlin"", 
    ""reviewscore"": 8.3
  }, 
  ""hotelRates"": [
    {
      ""rateDescription"": ""Unsere Classic Zimmer bieten Ihnen allen Komfort, den Sie von einem 5-Sterne-Hotel erwarten. Helle und freundliche Farben sorgen f\u00fcr ein angenehmes Ambiente, damit Sie Ihren Aufenthalt im Herzen Berlins voll und ganz genie\u00dfen k\u00f6nnen. 20m\u00b2. Doppelbett oder zwei separate Betten. Max. Kapazit\u00e4t: 2 Erwachsene oder 1 Erwachsener und 1 Kind.      "", 
      ""rateID"": ""-739857498""
    }, 
    {
      ""rateDescription"": ""Unsere Classic Zimmer bieten Ihnen allen Komfort, den Sie von einem 5-Sterne-Hotel erwarten. Helle und freundliche Farben sorgen f\u00fcr ein angenehmes Ambiente, damit Sie Ihren Aufenthalt im Herzen Berlins voll und ganz genie\u00dfen k\u00f6nnen. 20m\u00b2. Doppelbett oder zwei separate Betten. Max. Kapazit\u00e4t: 2 Erwachsene oder 1 Erwachsener und 1 Kind.      "", 
      ""rateID"": ""-740789668"", 
      ""rateTags"": [
        {
          ""name"": ""lunch"", 
          ""shape"": true
        }
      ]
    }
  ]
}";
    }
}
