using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography.X509Certificates;

namespace WhiteOak.Problem
{
	public class Program
	{
		static readonly Stack<int> MinStack = new();

		static int min;

		static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				Push(3);
				Push(5);
				PrintMin();
				Push(2);
				Push(1);
				PrintMin();
				Pop();
				PrintMin();
			}
			else
			{
				Console.WriteLine("Please enter some initial integer numbers");

				string input = null;

				do
				{
					Console.WriteLine("Enter Po to 'Pop' or Pu to 'Push'... Type 'end' to quit");

					input = Console.ReadLine();

					switch (input.ToUpper())
					{
						case "PU":
							{
								Push(Int32.Parse(Console.ReadLine()));
								PrintMin();
							}
							break;
						case "PO":
							{
								Pop();
								PrintMin();
							}
							break;
					}
				} while (input.ToUpper() != "END");
			}
		}

		static void Pop()
		{
			if (MinStack.Count == 0)
			{
				Console.WriteLine("Stack is empty.");
				return;
			}

			int top = MinStack.Pop();

			if (top < min)
			{
				
				min = 2 * min - top;
			}

			Console.WriteLine($"Min => {min}");
			Console.WriteLine($"Top => {MinStack.Peek()}");
		}

		static void Push(int push)
		{
			Console.WriteLine($"Pushing {push} to the stack");

			if (MinStack.Count == 0)
			{
				min = push;
				MinStack.Push(push);
				return;
			}

			if (push < min)
			{
				MinStack.Push(2 * push - min);
				min = push;
			}
			else
				MinStack.Push(push);
		}

		static void PrintStack()
		{
			foreach (var stack in MinStack)
				Console.WriteLine(stack);
		}

		static void PrintMin()
		{
			if (MinStack.Count == 0)
				Console.WriteLine("Stack is empty");
			else
				Console.WriteLine($"Min element is {min}");
		
		}
	}
}