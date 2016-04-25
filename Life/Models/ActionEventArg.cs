namespace Life.Models
{
    public enum ActionType
    {
        ComeIn,
        ComeOut
    }

    public class ActionEventArg
    {
        public Gamer Gamer { get; private set; }
        public ActionType ActionType { get; private set; }
        public ActionEventArg(Gamer gamer, ActionType actionType)
        {
            Gamer = gamer;
            ActionType = actionType;
        }
    }
}