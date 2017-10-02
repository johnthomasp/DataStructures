using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TIME COMPLEXITY 
//Best is 0(1)
//Average is 0(1)
//Worst is 0(n) 

namespace Stack
{

    public class Stack
    {
        private int[] content;
        private int size;
        private int top;

        public int Size
        {
            get { return this.size; }
        }

        public Stack()
        {
            top = -1;
            size = 1;
            content = new int[size];
        }

        public void push(int data)
        {
            if (top >= size - 1)
            {
                resizeStack();
            }
            content[++top] = data;
        }

        public object pop()
        {
            if (top < 0)
                return null;
            return content[top--];
        }

        public void resizeStack()
        {
            int[] temp = content;
            size = size * 2;
            content = new int[size];

            for (int i = 0; i <= top; i++)
            {
                content[i] = temp[i];
            }
        }

        public bool isEmpty()
        {
            return (top == -1);
        }

        public object Top()
        {
            return content[top];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack stk = new Stack();
            stk.push(40);
            stk.push(30);
            stk.push(20);
            stk.push(10);

            for (int i = 0; i <= stk.Size; i++)
            {
                object result = stk.pop();
                Console.WriteLine(result == null ? "NULL" : result);
            }
            Console.ReadLine();
        }
    }
}