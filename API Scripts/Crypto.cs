using System;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
	static void Main(string[] args)
	{
		string json = File.ReadAllText("https//blockchain.info/");
		JObject jsonData = JObject.Parse(json);

		string id = (string)jsonData["id"];
        string rank = (string)jsonData["rank"];
        string symbol = (string)jsonData["symbol"];
        string name = (string)jsonData["name"];
        string supply = (string)jsonData["supply"];
        string maxSupply = (string)jsonData["maxSupply"];
        string marketCapUsd = (string)jsonData["marketCapUsd"];
        string volumeUsd24Hr = (string)jsonData["volumeUsd24Hr"];
        string priceUsd = (string)jsonData["priceUsd"];
        string changePercent24Hr = (string)jsonData["changePercent24Hr"];
        string vwap24Hr = (string)jsonData["vwap24Hr"];
        string explorer = (string)jsonData["explorer"];

        string cryptoClassText = $@"
        [System.Serializable]
        public class Crypto
	    {
            public string id = ""{id}"";
            public string rank = ""{rank}"";
            public string symbol = ""{symbol}"";
            public string name = ""{name}"";
            public string supply = ""{supply}"";
            public string maxSupply = ""{maxSupply}"";
            public string marketCapUsd = ""{marketCapUsd}"";
            public string volumeUsd24Hr = ""{volumeUsd24Hr}"";
            public string priceUsd = ""{priceUsd}"";
            public string changePercent24Hr = ""{changePercent24Hr}"";
            public string vwap24Hr = ""{vwap24Hr}"";
            public string explorer = ""{explorer}"";
	}
    
    Console.WriteLine(cryptoClassText);
	};