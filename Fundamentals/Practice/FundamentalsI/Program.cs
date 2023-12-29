//Loop that prints all values from 1-255

for (int i = 1; i < 256; i++)
{
Console.WriteLine(i);
}
// loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
for (int i = 1; i <= 100 ; i++)
{
 if (i % 3 == 0 || i % 5 == 0){
    Console.WriteLine(i);
 }
}
//loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5

for (int i = 1; i <= 100 ; i++)
{
if (i % 3 == 0 ){
    Console.WriteLine("Fizz");
 }
 if (i % 5 == 0 ){
    Console.WriteLine("Buzz");
 }
 if (i % 3 == 0 && i % 5 == 0){
    Console.WriteLine("FizzBuzz");
 }
}

// while to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5

int i = 1 ;
while (i <= 100)
{
  if (i % 3 == 0 ){
    Console.WriteLine("Fizz");
 }
 if (i % 5 == 0 ){
    Console.WriteLine("Buzz");
 }
 if (i % 3 == 0 && i % 5 == 0){
    Console.WriteLine("FizzBuzz");
 }
 i++ ;  
} 
