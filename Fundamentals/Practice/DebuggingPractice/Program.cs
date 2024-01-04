//Challenge 1
bool amProgrammer = true;
int Age = 27;
List<string> Names = new List<string>();
Names.Add("Monica");
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
MyDictionary.Add("Hi there", "0");
// This is a tricky one! Hint: look up what a char is in C#
string MyName = "MyName";
// Challenge 2
List<int> Numbers = new List<int>() {2,3,6,7,1,5};
for(int i = Numbers.Count-1 ; i >= 0; i--)
{
    Console.WriteLine(Numbers[i]);
}
//Challenge 3
List<int> MoreNumbers = new List<int>() {12,7,10,3,9};
foreach(int i in MoreNumbers)
{
    Console.WriteLine(i);
}
// Challenge 4
List<int> EvenMoreNumbers = new List<int> {3,6,9,12,14};
for (int i = 0; i < EvenMoreNumbers.Count; i++)
{
    if(EvenMoreNumbers[i] % 3 == 0)
    {
        EvenMoreNumbers[i] = 0;
    }
   
}
// Challenge 5
What can we learn from this error message?

char[] MyString = "superduberawesome".ToCharArray();

for (int i = 0; i < MyString.Length; i++)
{
    if (i== 6){
     MyString[i] = 'p'; 
    }  
}

// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new Random();
int randomNum = rand.Next(13);
if(randomNum == 12)
{
    Console.WriteLine("Hello");
}

