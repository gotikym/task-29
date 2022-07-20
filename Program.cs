using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        string userChoice;
        bool exit = false;
        string[] fullNames = { "Васильев Иван Петрович", "Макаров Максим Владимирович", "Мельников Евгений Михайлович", "Круглов Вадим Александрович", "Упаковкин Сосиска Молокович" };
        string[] workingPosition = { "Раб", "Слуга", "Советник", "Правитель", "Повелитель" };

        while (exit == false)
        {
            Console.WriteLine("Меню:\n1:Добавить досье\n2:Вывести все досье\n3:Удалить досье\n4:Поиск по фамилии\n5:Выход");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("введите инфонрмацию о новом сотруднике");
                    Console.WriteLine("фио: ");

                    arrayExpansion(ref fullNames);

                    Console.WriteLine("должность: ");

                    arrayExpansion(ref workingPosition);

                    Console.Clear();
                    break;

                case "2":

                    informationOutput(ref fullNames, ref workingPosition);

                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Введите номер досье, которое хотите удалить");
                    int numberDossier = Convert.ToInt32(Console.ReadLine()) - 1;

                    deleteInformation(ref fullNames, ref numberDossier);

                    deleteInformation(ref workingPosition, ref numberDossier);

                    Console.Clear();

                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Введите фамилию сотрудника, чтобы увидеть информацию о нём");
                    string lastName = Console.ReadLine();

                    searchDossier(ref fullNames, ref workingPosition, ref lastName);

                    break;

                case "5":

                    Console.Clear();

                    exit = true;
                    break;
            }
        }
    }

    static string[] arrayExpansion(ref string[] array)
    {
        string changer;
        changer = Console.ReadLine();
        string[] Expansion = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            Expansion[i] = array[i];
        }

        Expansion[Expansion.Length - 1] = changer;
        array = Expansion;
        return array;
    }

    static void informationOutput(ref string[] firstOutputArray, ref string[] secondOutputArray)
    {
        Console.Clear();

        for (int i = 0; i < firstOutputArray.Length; i++)
        {
            Console.Write(i + 1 + ":" + firstOutputArray[i] + "-" + secondOutputArray[i] + "\n");
        }

        Console.WriteLine("\nНажмите любую клавишу для продолжения");
        Console.ReadKey();
        Console.Clear();
    }

    static string[] deleteInformation(ref string[] reduction, ref int numberDossier)
    {
        string[] arrayReduction = new string[reduction.Length - 1];

        if (numberDossier == reduction.Length)
        {
            for (int i = 0; i < reduction.Length - 1; i++)
            {
                arrayReduction[i] = reduction[i];
            }
        }

        else
        {
            for (int i = 0; i < numberDossier; i++)
            {
                arrayReduction[i] = reduction[i];
            }

            for (int i = numberDossier; i < reduction.Length - 1; i++)
            {
                arrayReduction[i] = reduction[i + 1];
            }
        }

        reduction = arrayReduction;
        return reduction;
    }

    static void searchDossier(ref string[] fullNames, ref string[] workPisition, ref string lastName)
    {
        bool nameIsFound = false;

        for (int i = 0; i < fullNames.Length; i++)
        {
            if (fullNames[i].ToLower().Contains(lastName.ToLower()))
            {
                Console.WriteLine("Полное досье на " + lastName + " :" + fullNames[i] + " - " + workPisition[i]);
                nameIsFound = true;
            }
        }

        if (nameIsFound == false)
        {
            Console.WriteLine("Такого сотрудника у нас нет");
        }

        Console.WriteLine("\nНажмите любую клавишу для продолжения");
        Console.ReadKey();
        Console.Clear();
    }
}