using Life.Models;

namespace Life.Interfaces
{
    public interface ISchedulerListener
    {
        void OnSchedulerAction(ActionEventArg arg);
    }
}