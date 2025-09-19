Console.WriteLine("Labb 1 - Hitta tal i sträng med tecken\r\n");

Console.WriteLine("Skriv in en text som innehåller minst tre siffror: ");

string userInput = Console.ReadLine();
Console.WriteLine();

List<(int start, int length)> piecesOfUserInput = new List<(int, int)>();

for (int i = 0; i < userInput.Length - 1; i++)
{
    for (int j = i + 1; j < userInput.Length; j++)
    {
        string pieceToCheck = userInput.Substring(i, j - i + 1);

        if (pieceToCheck[0] != pieceToCheck[pieceToCheck.Length - 1])
            continue;

        if (pieceToCheck.Length < 2)
            continue;

        string middleOfPieceToCheck = pieceToCheck.Substring(1, pieceToCheck.Length - 2);
        if (middleOfPieceToCheck.Contains(pieceToCheck[0]))
            continue;

        if (!pieceToCheck.All(char.IsDigit))
            continue;

        piecesOfUserInput.Add((i, pieceToCheck.Length));


    }
}

foreach (var piece in piecesOfUserInput)
{
    int startOfPiece = piece.start;
    int endOfPiece = startOfPiece + piece.length - 1;

    for (int i = 0; i < userInput.Length; i++)
    {
        if (i >= startOfPiece && i <= endOfPiece)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        Console.Write(userInput[i]);
    }

    Console.WriteLine();
    Console.ResetColor();
}

long total = 0;
foreach (var piece in piecesOfUserInput)
{
    string part = userInput.Substring(piece.start, piece.length);
    long sumOfPiece = long.Parse(part);

    total += sumOfPiece;
}

Console.WriteLine();
Console.WriteLine($"Total = {total}");



