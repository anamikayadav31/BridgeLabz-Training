 using System;
 class Operators{
	 public static void Main(string[] args){
		 int a=5;
		 int b=8;
		 //Arithmetic operators
		 Console.WriteLine(a+b);//addition 
		 Console.WriteLine(a-b);//substraction
		 Console.WriteLine(a*b);//multiplication
		 Console.WriteLine(a/b);//divide
	     Console.WriteLine(a%b);//modulo
		 
		 //Assignment Operators
		 Console.WriteLine(a=b);//assigns b to a
		 Console.WriteLine(a+=b);//first add b to a and then assign the value of a to b
		 Console.WriteLine(a-=b);//first substract b to a and then assign the value of a to b
		 Console.WriteLine(a*=b);//first multiply b to a and then assign the value of a to b
		 Console.WriteLine(a/=b);//first divide b to a and then assign the value of a to b
		 Console.WriteLine(a%=b);//first modulo b to a and then assign the value of a to b
		 
		 //Relational operator
		 Console.WriteLine(a==b);//its compare both operands value if values are same it return true else false
		 Console.WriteLine(a!=b);//its compare both operands value if values are same it return false else true
		 Console.WriteLine(a>b);//its compare both operands value if a is greater than b it return true else false
		 Console.WriteLine(a<b);//its compare both operands value if b is greater than a it return true else false
		 Console.WriteLine(a>=b);//its compare both operands value if a is greater than equals to b it return true else false
		 Console.WriteLine(a<=b);//its compare both operands value if b is greater than equals to a it return true else false
		 
		 //Logical operators
		 bool x=true;
		 bool y= false;
		 Console.WriteLine(x&&y);//false,return true if  both operands are true
		 Console.WriteLine(x||y);//true,return true if any one operand is true
		 Console.WriteLine(!x);//it return false;
		 
		 //Unary Operators
		 Console.WriteLine(+b);//pre increament 
		 Console.WriteLine(-b);//pre decreament 
		 Console.WriteLine(++a);//pre increament 
		 Console.WriteLine(a++);//post increament 
		 Console.WriteLine(--a);//pre decreament 
		 Console.WriteLine(a--);//post decreament 
		 
		 //ternary operator
		 int c=a>b?a:b;//return b's value because a>b condition is false
		 Console.WriteLine(c);
		 
		 //is operator
		 object e = "Hello";
         if (e is string){//chaeck which type of value e stores ,e stores a string so condition is true
             Console.WriteLine("e is a string");//print e is a string 
		}


	 }
 }

		 
		 
		 
		
		 
		 
		  