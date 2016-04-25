using System.Collections.Generic;
using Life.Models;

namespace Life.Interfaces
{
    public delegate void IncommingGamer();
    public delegate void LeavingGamer();
    public interface IGame : ISchedulerListener
    {
        event IncommingGamer IncommingEvent;
        event LeavingGamer LeavingEvent;

        void AddPersonToOffice(Gamer gamer);
        void RemovePersonFromOffice(Gamer gamer);
        List<Gamer> GetAllPresentingPersons();
    }
}