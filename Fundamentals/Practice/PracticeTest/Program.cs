List<string> bikes = new List<string>();
//Use the Add function in a similar fashion to push
bikes.Add("Kawasaki");
bikes.Add("Triumph");
bikes.Add("BMW");
bikes.Add("Moto Guzzi");
bikes.Add("Harley Davidson");
bikes.Add("Suzuki");
//Accessing a generic list value is the same as you would an array
Console.WriteLine(bikes[2]); //Prints "BMW"
Console.WriteLine("The current manufacturers we have seen are:");
for (var idx = 0; idx < bikes.Count; idx++)
{
    Console.WriteLine("-" + bikes[idx]);
}
// Insert a new item between a specific index
bikes.Insert(2, "Yamaha");
//Removal from Generic List
//Remove is a lot like Javascript array pop, but searches for a specified value
//In this case we are removing all manufacturers located in Japan
bikes.Remove("Suzuki");
//bikes.Remove("Yamaha");
bikes.RemoveAt(0); //RemoveAt has no return value however
//The updated list can then be iterated through using a foreach loop
Console.WriteLine("List of Non-Japanese Manufacturers:");
foreach (string manu in bikes)
{
    Console.WriteLine("-" + manu);
}
