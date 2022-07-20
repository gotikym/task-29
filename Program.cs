using System;
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
            Console.Clear();
            Console.WriteLine("Меню:\n1:Добавить досье\n2:Вывести все досье\n3:Удалить досье\n4:Поиск по фамилии\n5:Выход");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":

                    AddDossier(ref fullNames, ref workingPosition);

                    break;

                case "2":

                    InformationOutput(fullNames, workingPosition);

                    break;

                case "3":

                    DeleteInformation(ref fullNames, ref workingPosition);

                    break;

                case "4":

                    SearchDossier(fullNames, workingPosition);

                    break;

                case "5":

                    Console.Clear();
                    exit = true;

                    break;
            }
        }
    }

    static void AddDossier(ref string[] fullNames, ref string[] workingPosition)
    {
        Console.Clear();
        Console.WriteLine("введите инфонрмацию о новом сотруднике");
        Console.WriteLine("фио: ");

        ExpandArray(ref fullNames);

        Console.WriteLine("Должность: ");

        ExpandArray(ref workingPosition);

    }
    static void ExpandArray(ref string[] array)
    {
        string changer;
        changer = Console.ReadLine();
        string[] expansionName = new string[array.Length + 1];

        for (int i = 0; i < array.Length; i++)
        {
            expansionName[i] = array[i];
        }

        expansionName[expansionName.Length - 1] = changer;
        array = expansionName;
    }

    static void InformationOutput(string[] firstOutputArray, string[] secondOutputArray)
    {
        Console.Clear();

        for (int i = 0; i < firstOutputArray.Length; i++)
        {
            Console.Write(i + 1 + ":" + firstOutputArray[i] + "-" + secondOutputArray[i] + "\n");
        }

        Console.WriteLine("\nНажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    static void DeleteInformation(ref string[] fullNames, ref string[] workingPosition)
    {
        Console.Clear();
        Console.WriteLine("Введите номер досье, которое хотите удалить");
        int numberDossier = Convert.ToInt32(Console.ReadLine()) - 1;

        ReduceArray(ref fullNames, numberDossier);

        ReduceArray(ref workingPosition, numberDossier);

    }
    static void ReduceArray(ref string[] reduction, int numberDossier)
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
    }

    static void SearchDossier(string[] fullNames, string[] workPisition)
    {
        Console.Clear();
        Console.WriteLine("Введите фамилию сотрудника, чтобы увидеть информацию о нём");
        string lastName = Console.ReadLine();
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
    }
}
