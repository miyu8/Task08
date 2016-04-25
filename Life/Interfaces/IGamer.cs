namespace Life.Interfaces
{
    public delegate void RunGame();
    public interface IGamer : ISchedulerListener
    {
        event RunGame runGame;
    }
}