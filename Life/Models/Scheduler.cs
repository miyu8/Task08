using Life.Interfaces;

namespace Life.Models
{
    class Scheduler : IScheduler
    {
        public event SchedulerActionHandler SchedulerAction;

        public void StartEmulation()
        {
            Gamer[] gamer =
            {
            };
        }

        protected void FireSchedulerActionEvent(Gamer gamer, bool isCommingIn)
        {
            var e = SchedulerAction;
            if (e != null)
                e(new ActionEventArg(gamer, isCommingIn ? ActionType.ComeIn : ActionType.ComeOut));
        }
    }
}