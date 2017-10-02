 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TIME COMPLEXITY 
//Best is 0(1)
//Average is 0(1)
//Worst is 0(n) 

namespace Queue
{
    public class Queue
    {
        private object[] content;
        private int front;
        private int rear;
        private int size;
        private int count;


        public Queue()
        {
            front = -1;
            rear = -1;
            size = 3;
            count = 0;
            content = new object[size];
        }

        public void enqueue(object data)
        {
            if (isFull())
            {
                resizeQueue();
            }
            content[++rear] = data;
            count++;
        }

        public object dequeue()
        {
            if (rear > front)
            {
                return content[++front];
                count--;
            }
            return null;
        }

        private void resizeQueue()
        {
            object[] temp = content;
            size = size * 2;
            content = new object[size];

            for (int i = 0; i <= temp.Length-1; i++)
            {
                content[i] = temp[i];
            }
        }

        public bool isFull()
        {
            return (rear + 1 >= size);
        }

        public int Size
        {
            get { return this.size; }
        }

        public int Count
        {
            get { return this.count; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue que = new Queue();
            que.enqueue(10);
            que.enqueue(20);
            que.enqueue(30);
            que.enqueue(40);

            for (int i = 0; i <= que.Count; i++)
            {
                object result = que.dequeue();
                Console.WriteLine(result == null ? "NULL" : result);
            }
            Console.ReadLine();
        }
    }
}