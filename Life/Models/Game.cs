using System.Collections.Generic;
using Life.Interfaces;

namespace Life.Models
{
    public class Game : IGame
    {
        public event IncommingGamer IncommingEvent;
        public event LeavingGamer LeavingEvent;
        private List<Gamer> allPersons = new List<Gamer>();

        public void AddPersonToOffice(Gamer gamer)
        {
            if (allPersons.Contains(gamer))
                return;
            allPersons.Add(gamer);
            FireIncommingEvent(gamer);
            this.IncommingEvent += gamer.Init;
            this.LeavingEvent += gamer.OnStoping;
        }

        public List<Gamer> GetAllPresentingPersons()
        {
            return allPersons;
        }

        public void OnSchedulerAction(ActionEventArg arg)
        {
            if (arg.ActionType == ActionType.ComeIn)
                AddPersonToOffice(arg.Gamer);
            if (arg.ActionType == ActionType.ComeOut)
                RemovePersonFromOffice(arg.Gamer);
        }

        public void RemovePersonFromOffice(Gamer gamer)
        {
            if (!allPersons.Contains(gamer))
                return;
            this.IncommingEvent -= gamer.OnStoping;
            this.LeavingEvent -= gamer.OnStoping;
            allPersons.Remove(gamer);
            FireLeavingEvent(gamer);
        }

        protected void FireIncommingEvent(Gamer gamer)
        {
            var e = IncommingEvent;
            if (e != null)
                e();
        }
        protected void FireLeavingEvent(Gamer gamer)
        {
            var e = LeavingEvent;
            if (e != null)
                e();
        }

    }
}