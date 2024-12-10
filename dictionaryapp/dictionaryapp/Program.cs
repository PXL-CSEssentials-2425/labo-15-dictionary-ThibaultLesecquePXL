using System.Runtime.CompilerServices;
using System.Text;

Dictionary<string, int> rankingDict = new Dictionary<string, int>();
bool isActive = true;

Console.WriteLine("Welkom bij het Klassement Beheer Systeem!");
Console.WriteLine("Kies een optie uit het menu:\n");
Console.WriteLine("1.Toon het klassement");
Console.WriteLine("2. Zoek de score van een deelnemer");
Console.WriteLine("3. Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe");
Console.WriteLine("4. Toon de gemiddelde score");
Console.WriteLine("5. Toon de deelnemer met de hoogste score");
Console.WriteLine("6. Stop het programma");

while (isActive)
{
    Console.Write("\nMaak uw keuze: ");

    switch (Console.ReadLine())
    {
        case "1":
            ShowRanking();
            break;
        case "2":
            ShowScore();
            break;
        case "3":
            AddParticipant();
            break;
        case "4":
            ShowAverage();
            break;
        case "5":
            ShowHighscore();
            break;
        case "6":
            QuitApplication();
            isActive = false;
            break;
        default:
            Console.WriteLine("Foutieve input!\n");
            break;
    }
}

void ShowRanking()
{
    Console.WriteLine("Klassement: ");

    if (rankingDict.Count > 0)
    {
        foreach (var item in rankingDict)
        {
            Console.WriteLine($"- {item.Key}: {item.Value} punten");
        }
    }
    else
    {
        Console.WriteLine("Het klassement is momenteel leeg!");
    }
}

void ShowScore()
{
    Console.Write("Geef de naam van een deelnemer: ");
    string inputName = Console.ReadLine();
    if (rankingDict.TryGetValue(inputName, out int inputPoints))
    {
        Console.WriteLine($"{inputName} heeft {inputPoints} punten.");
    }
    else
    {
        Console.WriteLine($"{inputName} staat niet in het klassement.");
    }
}

void AddParticipant()
{
    Console.Write("Geef de naam van een deelnemer: ");
    string inputName = Console.ReadLine();
    Console.Write("Geef de nieuwe score: ");
    int.TryParse(Console.ReadLine(), out int inputPoints);

    if (rankingDict.TryGetValue(inputName, out int tempScore))
    {
        rankingDict[inputName] = tempScore + inputPoints;
    }
    else
    {
        rankingDict.Add(inputName, inputPoints);
    }

    Console.WriteLine($"De score van {inputName} is bijgewerkt naar {rankingDict[inputName]} punten");
}

void ShowAverage()
{
    decimal tempSum = 0;
    foreach (var item in rankingDict)
    {
        tempSum += item.Value;
    }
    decimal average = tempSum / rankingDict.Count;
    Console.WriteLine($"De gemiddelde score van alle deelnemers is: {average} punten.");
}

void ShowHighscore()
{
    int maxValue = rankingDict.Values.Max();
    
    foreach (var item in rankingDict)
    {
        if (item.Value >= maxValue)
        {
            Console.WriteLine($"De deelnemer met de hoogste score is {item.Key} met {item.Value} punten.");
            return;
        }
    }
}

void QuitApplication()
{
    Console.Clear();
    Console.WriteLine("Bedankt voor het gebruiken van het Klassement Beheer Systeem. Tot ziens!");
    Console.ReadLine();
}