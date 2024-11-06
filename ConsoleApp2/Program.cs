using System;
class HelloWorld
{
    static void Main()
    {
        PuzzleGame z = new PuzzleGame();
        while (true)
        {
            if (z.CheckWin())
            {
                Console.WriteLine("Игра пройдена успешно");
                break;
            }
            Console.WriteLine("Игра начинается!!");
            z.PrintBoard();
            z.Move();
        }
    }
}
class PuzzleGame {
    private int[,] board;
    private int emptyRow;
    private int emptyCol;
    public PuzzleGame()
    {
        board = new int[4,4];
        initializeBoard();
        ShuffleBoard();
    }
    private void initializeBoard()
    {
        int num = 1;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                board[i,j] = (i == 3 && j == 3 )? 0 : num++;
            }
        }
        emptyRow = 3;// строка
        emptyCol = 3;// колонна
    }
    public void PrintBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i,j] == 0) 
                    Console.Write(" _ \t");
                else
                    Console.Write(board[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }
    public void Move()
    {
        char vibor;
        int temp;
        bool prover = true;
        while (prover)
        {
            Console.WriteLine("Выберите куда пойти?");
            vibor = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            switch (vibor)
            {
                case 'w':
                    if (emptyRow != 0)
                    {
                        temp = board[emptyRow - 1, emptyCol];
                        board[emptyRow - 1, emptyCol] = 0;
                        board[emptyRow, emptyCol] = temp;
                        prover = false;
                        emptyRow -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Движение вверх невозможно");
                    }
                    break;
                case 's':
                    if (emptyRow != 3)
                    {
                        temp = board[emptyRow + 1, emptyCol];
                        board[emptyRow + 1, emptyCol] = 0;
                        board[emptyRow, emptyCol] = temp;
                        prover = false;
                        emptyRow +=  1;
                    }
                    else
                    {
                        Console.WriteLine("Движение вниз невозможно");
                    }
                    break;
                case 'a':
                    if (emptyCol != 0)
                    {
                        temp = board[emptyRow, emptyCol - 1];
                        board[emptyRow, emptyCol - 1] = 0;
                        board[emptyRow, emptyCol] = temp;
                        prover = false;
                        emptyCol -= 1;
                    }
                    else
                    {
                        Console.WriteLine("Движение влево невозможно");
                    }
                    break;
                case 'd':
                    if (emptyCol != 3)
                    {
                        temp = board[emptyRow, emptyCol + 1];
                        board[emptyRow, emptyCol + 1] = 0;
                        board[emptyRow, emptyCol] = temp;
                        prover = false;
                        emptyCol += 1;
                    }
                    else
                    {
                        Console.WriteLine("Движение вправо невозможно");
                    }
                    break;
            }
        }
        prover = true;
    }
    public bool CheckWin()
    {
        int num = 1;
        int win = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i,j] == num || board[i, j] == 0)
                {
                    win++;
                }
                num++;
            }
        }
        if (win == 16)
            return true;
        else 
            return false;
    }
    public void ShuffleBoard()
    {
        Random rand = new Random();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                int temp = board[i, j];
                int newIndexI = rand.Next(4);
                int newIndexJ = rand.Next(4);

                board[i, j] = board[newIndexI, newIndexJ];
                board[newIndexI, newIndexJ] = temp;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (board[i, j] == 0)
                {
                    emptyRow = i;
                    emptyCol = j;
                }
            }
        }
    }
}
