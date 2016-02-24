using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExercicioThreads
{
	class Program
	{
		static int contador, tamanho, max, menor;
		static int[] vetor1;

		static void ThreadMenor()
		{
			menor = vetor1[0];
			for (int i = 0; i < tamanho; i++)
			{
				if (vetor1[i] < menor)
				{
					menor = vetor1[i];
				}
			}
		}

		static void ThreadMaior()
		{
			max = vetor1[0];
			for (int i = 0; i < tamanho; i++)
			{
				if (vetor1[i] > max)
				{
					max = vetor1[i];
				}
			}
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Digite o tamango do vetor !");
			tamanho = int.Parse(Console.ReadLine());
			vetor1 = new int[tamanho];
			Console.WriteLine("Seu vetor é de tamanho " + tamanho);

			for (int i = 0; i < tamanho; i++)
			{
				Console.WriteLine("Insira um número na posição " + i);
				int numero = int.Parse(Console.ReadLine());
				vetor1[i] = numero;
			}

			Thread t1 = new Thread(ThreadMaior);
			Thread t2 = new Thread(ThreadMenor);
			t1.Start();
			t2.Start();
			t1.Join();
			t2.Join();

			Console.WriteLine("O maior do vetor é : " + max);
			Console.WriteLine("O menor do vetor é : " + menor);
			Console.ReadLine();

		}
	}
}
