//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Text;


////reverse a stack using recursion
//namespace BridgeLabzTraining
//{
//    internal class StackReverse
//    {
//        static void Main(string[] args)
//        {
//            CustomStack stack = new CustomStack(5);
//            stack.push(1);
//            stack.push(2);
//            stack.push(3);
//            stack.push(4);
//            stack.push(5);
//            Console.WriteLine("original stack-");
//            stack.print();
//            stack.reverse();
//            Console.WriteLine("stack after reverse-");
//            stack.print();


//        }
//    }
//    class CustomStack
//    {
//        private int[] arr;
//        private int top;
//        private int len;

//        public CustomStack(int length)
//        {
//            len = length;
//            arr = new int[length];
//            top = -1;
//        }
//        public bool isEmpty()
//        {
//            return top == -1;
//        }
//        public bool isFull()
//        {
//            return top == len - 1;

//        }
//        public void push(int value)
//        {
//            arr[top++] = value;


//        }
//        public int pop()
//        {
//            return arr[top--];
//        }

//        public void print()
//        {
//            for (int i = 0; i < arr.Length; i++)
//            {
//                Console.WriteLine(arr[i] + " ");
//            }
//        }

//        public void reverse()
//        {
//            if (isEmpty())
//            {
//                return;
//            }
//            int temp = pop();
//            reverse();
//            insert(temp);



//        }
//        public void insert(int value)
//        {
//            if (isEmpty())
//            {
//                push(value);
//                return;
//            }
//            int temp = pop();
     //         insert(value);
//            push(temp);


//        }




//    }


//}
