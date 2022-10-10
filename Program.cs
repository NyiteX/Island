Island island = new();

island.PrintMas2D();
Console.WriteLine("\nОстровов найдено: " + island.Proverka());

class MyArray
{
    protected int[,]? mas2D;

    public void PrintMas2D()
    {
        for (int i = 0; i < mas2D.GetLength(0); i++)
        {
            for (int u = 0; u < mas2D.GetLength(1); u++)
                Console.Write(mas2D[i, u] + " ");
            Console.WriteLine();
        }
    }
}

class Island : MyArray
{   
    public Island(int x = 5, int y = 5)
    {
        mas2D = new int[x, y];
        Rand();
    }
    public void Rand()
    {
        Random rand = new Random();
        for (int i = 0; i < mas2D.GetLength(0); i++)
            for (int u = 0; u < mas2D.GetLength(1); u++)
                mas2D[i, u] = rand.Next(2);
    }
    public int Proverka()
    {
        int kol = 0;
        int[,] tmp = new int[mas2D.GetLength(0),mas2D.GetLength(1)];
        tmp = mas2D;

        for (int i = 0; i < tmp.GetLength(0); i++)
            for (int u = 0; u < tmp.GetLength(1); u++)
                if(tmp[i, u] == 1)
                {
                    kol++;
                    Recursia(tmp, i, u);
                }
        return kol;
    }
    void Recursia(int[,] mas2D, int i, int u)
    {
        if (i < 0 || u<0 || i >= mas2D.GetLength(0) || u >= mas2D.GetLength(1) || mas2D[i, u] == 0)
            return;
        mas2D[i, u] = 0;

        Recursia(mas2D, i, u + 1);
        Recursia(mas2D, i + 1, u);
        Recursia(mas2D, i, u - 1);
        Recursia(mas2D, i - 1, u);
    }
}