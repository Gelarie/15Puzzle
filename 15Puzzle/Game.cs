using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    class Game
    {
        private int Side, Voidx = 0, Voidy = 0,firstNumber = 0, secondNumber = 0; 
        public int[,] Field;        
        
        
        public Game(params int[] values)
        { 
            int count = 0;
            bool existZero = false;

            try
            {
                if (!IsThisCorrectArray(values))
                {
                    throw new ArgumentException("Некорректные значения");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка:" + ex.Message);
            }

            try
            {
                if (!IsItIntegerSize(values.Length))
                {
                    throw new ArgumentException("Некорректный размер поля");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка:" + ex.Message);
            }  
                
            
               
           Side = (int)Math.Sqrt(values.Length);           
           Field=new int[Side, Side];

            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {                    
                    if (values[count] == 0)
                    {
                        Voidx = i;
                        Voidy = j;
                        Field[i, j] = values[count];
                        count++;
                        existZero = true;                        
                    }
                    else
                    {
                        Field[i, j] = values[count];
                        count++;                        
                    }
                }               
            }

            try
            {
                if (!existZero) throw new ArgumentException("В этих данных нет нуля");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            Print.PrintInfo(Field,Side);          
        }



        public int this[int x, int y]
        {
            get
            {
                return Field[x, y];
            }
            set
            {
                Field[x, y] = value;
            }
        }



        public int GetLocation(int value)
        {
            bool logic = false;
            int location;
            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (Field[i, j] == value)
                    {
                        logic = true;
                        firstNumber = i;
                        secondNumber = j;
                    }
                }
            }            
            try
            {
                if (!logic) throw new ArgumentException("Данное число " + value + " не удалось найти");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            location = firstNumber * Side + secondNumber + 1;
            Console.WriteLine("Число " + value + " находится в клетке № " + location);
            return location;
        }



        public void Shift(int value)
        {            
            GetLocation(value);          
            try
            {
                if (Math.Abs(firstNumber - Voidx) + Math.Abs(secondNumber - Voidy) == 1)
                {

                    Field[Voidx, Voidy] = Field[firstNumber, secondNumber];
                    Voidx = firstNumber;
                    Voidy = secondNumber;
                    Field[Voidx, Voidy] = 0;
                }
                else
                {
                    throw new ArgumentException("Данное число невозможно поменять местами с нулем");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            Print.PrintInfo(Field,Side);
        }



        private bool IsItIntegerSize(int size)
        {            
                    return ((Math.Sqrt(size) % 1) == 0);              
        }


        private bool IsThisCorrectArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int k = i + 1; k < array.Length; k++)
                {
                    if ((array[i] == array[k])||(array[k]>array.Length-1))
                    {
                        return false;
                    }                 
                }
            }
            return true;
        } 
    }
}
