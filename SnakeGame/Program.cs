using SnakeGame;

again:
int score = 0;

World world = new World();
Snake snake = new Snake();
Bait bait = new Bait();
world.SnakeWorld = world.CreateWorld();

while (true)
{
    //Console.Clear();
    Console.SetCursorPosition(0, 0);

    if (Console.KeyAvailable)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.RightArrow:
                if (snake.Direction != Direction.Left) snake.Direction = Direction.Right;
                break;
            case ConsoleKey.LeftArrow:
                if (snake.Direction != Direction.Right) snake.Direction = Direction.Left;
                break;
            case ConsoleKey.UpArrow:
                if (snake.Direction != Direction.Down) snake.Direction = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                if (snake.Direction != Direction.Up) snake.Direction = Direction.Down;
                break;
        }
    }

    world.SnakeWorld[snake.HeadRowPosition, snake.HeadColPosition].Indicator = "P" + "|" + snake.HeadRowPosition + "|" + snake.HeadColPosition;
    world.SnakeWorld[snake.HeadRowPosition, snake.HeadColPosition].Direction = snake.Direction;

    switch (snake.Direction)
    {
        case Direction.Right:
            snake.HeadColPosition++;
            break;
        case Direction.Left:
            snake.HeadColPosition--;
            break;
        case Direction.Up:
            snake.HeadRowPosition--;
            break;
        case Direction.Down:
            snake.HeadRowPosition++;
            break;
    }

    if (snake.HeadRowPosition == bait.BaitRowPosition && snake.HeadColPosition == bait.BaitColPosition)
    {
        snake.Size++;
        score++;

        world.SnakeWorld[bait.BaitRowPosition, bait.BaitColPosition].Shape = bait.Space;
        world.SnakeWorld[bait.BaitRowPosition, bait.BaitColPosition].Indicator = "S";

        bait.BaitRowPosition = bait.RegenerateBaitRowPos(world);
        bait.BaitColPosition = bait.RegenerateBaitColPos(world);

        while (world.SnakeWorld[bait.BaitRowPosition, bait.BaitColPosition].Indicator != "S")
        {
            bait.BaitRowPosition = bait.RegenerateBaitRowPos(world);
            bait.BaitColPosition = bait.RegenerateBaitColPos(world);
        }
    }
    else if (world.SnakeWorld[snake.HeadRowPosition, snake.HeadColPosition].Indicator == "W" ||
             world.SnakeWorld[snake.HeadRowPosition, snake.HeadColPosition].Indicator == "H" ||
             world.SnakeWorld[snake.HeadRowPosition, snake.HeadColPosition].Indicator.Contains("P") ||
             world.SnakeWorld[snake.HeadRowPosition, snake.HeadColPosition].Indicator == "T")
    {
        break;
    }
    else
    {
        world.SnakeWorld[snake.TailRowPosition, snake.TailColPosition].Shape = snake.Space;
        world.SnakeWorld[snake.TailRowPosition, snake.TailColPosition].Indicator = "S";

        if (world.SnakeWorld[snake.TailRowPosition, snake.TailColPosition].Direction == Direction.Up) snake.TailRowPosition--;
        else if (world.SnakeWorld[snake.TailRowPosition, snake.TailColPosition].Direction == Direction.Down) snake.TailRowPosition++;
        else if (world.SnakeWorld[snake.TailRowPosition, snake.TailColPosition].Direction == Direction.Left) snake.TailColPosition--;
        else if (world.SnakeWorld[snake.TailRowPosition, snake.TailColPosition].Direction == Direction.Right) snake.TailColPosition++;
    }

    world.UpdateWorld(world.SnakeWorld, snake, bait);
    world.DrawWorld(world.SnakeWorld);
    System.Threading.Thread.Sleep(70);
}

Console.Clear();
Console.WriteLine(String.Format("GAME OVER\nSCORE: {0}\nPRESS ESC to EXIT or PRESS ENTER and PLAY AGAIN", score));

if (Console.ReadKey().Key == ConsoleKey.Enter) goto again;
else if (Console.ReadKey().Key == ConsoleKey.Escape) Environment.Exit(0);