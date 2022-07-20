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

                    ArrayExpansion(ref fullNames, ref workingPosition);

                    break;

                case "2":

                    InformationOutput(ref fullNames, ref workingPosition);

                    break;

                case "3":

                    DeleteInformation(ref fullNames, ref workingPosition);

                    break;

                case "4":

                    SearchDossier(ref fullNames, ref workingPosition);

                    break;

                case "5":

                    Console.Clear();

                    exit = true;
                    break;
            }
        }
    }

    static void ArrayExpansion(ref string[] arrayName, ref string[] arrayPosition)
    {
        Console.Clear();
        Console.WriteLine("введите инфонрмацию о новом сотруднике");
        Console.WriteLine("фио: ");
        string changerName;
        changerName = Console.ReadLine();
        string[] expansionName = new string[arrayName.Length + 1];

        for (int i = 0; i < arrayName.Length; i++)
        {
            expansionName[i] = arrayName[i];
        }

        expansionName[expansionName.Length - 1] = changerName;
        arrayName = expansionName;

        Console.WriteLine("должность: ");
        string changerPosition;
        changerPosition = Console.ReadLine();
        string[] expansionPosition = new string[arrayPosition.Length + 1];

        for (int i = 0; i < arrayPosition.Length; i++)
        {
            expansionPosition[i] = arrayPosition[i];
        }

        expansionPosition[expansionPosition.Length - 1] = changerPosition;
        arrayPosition = expansionPosition;        
    }

    static void InformationOutput(ref string[] firstOutputArray, ref string[] secondOutputArray)
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

    static void DeleteInformation(ref string[] reductionName, ref string[] reductionPosition)
    {
        Console.Clear();
        Console.WriteLine("Введите номер досье, которое хотите удалить");
        int numberDossier = Convert.ToInt32(Console.ReadLine()) - 1;

        string[] arrayReductionName = new string[reductionName.Length - 1];

        if (numberDossier == reductionName.Length)
        {
            for (int i = 0; i < reductionName.Length - 1; i++)
            {
                arrayReductionName[i] = reductionName[i];
            }
        }

        else
        {
            for (int i = 0; i < numberDossier; i++)
            {
                arrayReductionName[i] = reductionName[i];
            }

            for (int i = numberDossier; i < reductionName.Length - 1; i++)
            {
                arrayReductionName[i] = reductionName[i + 1];
            }
        }

        reductionName = arrayReductionName;

        string[] arrayReductionPosition = new string[reductionPosition.Length - 1];

        if (numberDossier == reductionPosition.Length)
        {
            for (int i = 0; i < reductionPosition.Length - 1; i++)
            {
                arrayReductionPosition[i] = reductionPosition[i];
            }
        }

        else
        {
            for (int i = 0; i < numberDossier; i++)
            {
                arrayReductionPosition[i] = reductionPosition[i];
            }

            for (int i = numberDossier; i < reductionPosition.Length - 1; i++)
            {
                arrayReductionPosition[i] = reductionPosition[i + 1];
            }
        }

        reductionPosition = arrayReductionPosition;
    }

    static void SearchDossier(ref string[] fullNames, ref string[] workPisition)
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
