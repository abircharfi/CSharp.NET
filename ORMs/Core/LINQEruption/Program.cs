using System.IO;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
//Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
// static void PrintEach(IEnumerable<dynamic> items, string msg = "")
// {
//     Console.WriteLine("\n" + msg);
//     foreach (var item in items)
//     {
//         Console.WriteLine(item.ToString());
//     }
// }

// The first eruption that is in Chile 

IEnumerable<Eruption> chilelocation = eruptions.Where(l => l.Location == "Chile");
foreach (Eruption item in chilelocation)
{ 

    System.Console.WriteLine(item);
    
}

// Find the first eruption from the "Hawaiian Is" location

Eruption Hawaiianlocation = eruptions.FirstOrDefault(l => l.Location == "Hawaiian Is");

System.Console.WriteLine(Hawaiianlocation);

// first eruption that is after the year 1900 AND in "New Zealand"

Eruption After1900 = eruptions.FirstOrDefault(y => y.Year < 1900);

System.Console.WriteLine(After1900);

//Find all eruptions where the volcano's elevation is over 2000

IEnumerable<Eruption> volcanoelevation = eruptions.Where(l => l.ElevationInMeters > 2000 );
foreach (Eruption item in volcanoelevation)
{ 

    System.Console.WriteLine(item);
    
}

// Find all eruptions where the volcano's name starts with "L"
char startLetter = 'L';
IEnumerable<Eruption> startwithL = eruptions.Where(l => l.Volcano.StartsWith(startLetter.ToString()) );


foreach (Eruption item in startwithL)
{ 

    Console.WriteLine(item);
    
}

Console.WriteLine($"the number of eruptions found is {startwithL.Count()}" );


// Find the highest elevation, and print only that integer

int highestelevation = eruptions.Max(e => e.ElevationInMeters);

Console.WriteLine(highestelevation);


// Use the highest elevation variable to find a print the name of the Volcano with that elevation. 


Eruption NameVar = eruptions.FirstOrDefault(e=> e.ElevationInMeters == highestelevation);

Console.WriteLine(NameVar.Volcano);

// Print all Volcano names alphabetically.

IEnumerable<Eruption> Alphabetic = eruptions.OrderBy(e => e.Volcano) ;

foreach (var item in Alphabetic)
{

    Console.WriteLine(item);
    
}

// Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.

IEnumerable<Eruption> Alphabetic = eruptions.Where(s=> s.Year < 1000).OrderBy(e => e.Volcano) ;


foreach (var item in Alphabetic)
{

    System.Console.WriteLine(item);
    
}


// BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.

IEnumerable<string> volcanoNamesBefore1000  = eruptions.Where(s=> s.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano); ;


foreach (var item in volcanoNamesBefore1000 )
{

    System.Console.WriteLine(item);
    
}

