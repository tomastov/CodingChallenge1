using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenge_1
{
    class Program
    {
        int[] sequence; // sequence of instructions
        int length; // length of the sequence
        int numInstr = 5; // number of available instructions
        int direction = 1; // 1 means to the right, -1 means to the left
        int position = 0; // current position in the sequence

        void ReadSequence()
        {
            Console.WriteLine("Enter a sequence of instructions: ");
            string[] seq = Console.ReadLine().Split();
            length = seq.Length;

            sequence = new int [length];
            for(int i = 0; i < length; i++)
            {
                sequence[i] = Convert.ToInt32(seq[i]);
            }

        }

        int GetPrev(int position, int direction)
        {
            return (position - direction + length) % length;
        }

        // Increments given position of sequence by a given value
        void ChangeValue(int position, int value)
        {
            sequence[position] = (sequence[position] + value + numInstr) % numInstr;
        }

        void ChangeDir()
        {
            direction *= (-1);
        }

        // Moves to the next position in the sequence
        void Move()
        {
            position = (position + direction + length) % length;
        }

        void ProcessInstructions()
        {
            while (true)
            {
                int instruction = sequence[position];
                int prevPos = GetPrev(position, direction);

                if(instruction == 0)
                {
                    break;
                }

                switch (instruction)
                {
                    case 2:
                        ChangeValue(prevPos, 1);
                        break;
                    case 3:
                        ChangeValue(prevPos, -1);
                        break;
                    case 4:
                        ChangeDir();
                        break;
                }

                Move();
            }
        }

        void PrintSequence()
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(sequence[i]);
                Console.Write(" ");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Program CodingChallenge1 = new Program();
            CodingChallenge1.ReadSequence();
            CodingChallenge1.ProcessInstructions();
            CodingChallenge1.PrintSequence();
        }
    }
}
