Dictionary<string,string> profile = new Dictionary<string,string>();
//Almost all the methods that exists with Lists are the same with Dictionaries
profile.Add("Name", "Speros");
profile.Add("Language", "PHP");
profile.Add("Location", "Greece");
Console.WriteLine("Instructor Profile");
Console.WriteLine("Name - " + profile["Name"]);
Console.WriteLine("From - " + profile["Location"]);
Console.WriteLine("Favorite Language - " + profile["Language"]);

foreach (var entry in profile)
{
    Console.WriteLine(entry.Key + " - " + entry.Value);
}


