
using System.Xml.XPath;
using System.Net.Http.Headers;
using System.Data;
using System.Runtime.CompilerServices;
int[] arrayInt = new int[] {0,1,2,3,4,5,6,7,8,9};

string[] arrayString = new string[] { "Tim", "Martin", "Nikki","Sara"};

bool[] arrayBool = new bool [] {true,false,true,false,true,false,true,false,true,false};

List<string> IceCreamFlavors = new List<string>();

IceCreamFlavors.Add("Straweberry");
IceCreamFlavors.Add("ChocoBanana");
IceCreamFlavors.Add("Kinder");
IceCreamFlavors.Add("vanilla");
IceCreamFlavors.Add("Oreo");

Console.WriteLine(IceCreamFlavors.Count);
Console.WriteLine(IceCreamFlavors[2]);
IceCreamFlavors.RemoveAt (2);


Dictionary<string,string> dictionary = new Dictionary<string,string>();

for (int i = 0; i < arrayString.Length; i++)
        {
            dictionary[arrayString[i]] = IceCreamFlavors[i];
        }

        foreach (var item in dictionary)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }





