using System.Collections.Generic;
using System.Linq;
using Life.Models;
namespace Life.BaseData
{
    class RecordBase
    {
        public List<Cell> cells = new List<Cell>();
        public void AddList(List<List<Cell>> listAll,string NamePlayer, string NamePlay)
        {
            using (var db = new DataModelContainer())
            {
                var play = new Play() { Toy= NamePlayer };
                db.PlaySet.Add(play);
                var player = new Player() { Name = NamePlay };
                db.PlayerSet.Add(player);
                Coords coord;
                for (int i = 0; i < listAll.Count; i++)
                {
                    for (int j = 0; j < listAll[i].Count; j++)
                    {
                        coord = new Coords() { CoordX = listAll[i][j].CoordX, CoordY = listAll[i][j].CoordY, Generation=i+1};
                        db.CoordsSet.Add(coord);
                    }
                }
                db.SaveChanges();
            }
        }

        public void RemoveList(string NamePlayer, string NamePlay)
        {            
            using (var db = new DataModelContainer())
            {
                foreach (var item in db.CoordsSet.Where(x => x.Play.Toy == NamePlayer && x.Play.Player.Name == NamePlay))
                {
                    db.CoordsSet.Remove(item);
                }
                foreach (var item in db.PlaySet.Where(x => x.Toy == NamePlayer))
                {
                    db.PlaySet.Remove(item);
                }
                db.SaveChanges();
                if (db.PlaySet.FirstOrDefault(x => x.Toy == NamePlayer) == null)
                {
                    foreach (var item in db.PlayerSet.Where(x => x.Name == NamePlay))
                    {
                        db.PlayerSet.Remove(item);
                    }
                }
                db.SaveChanges();
            }
    }

        public void TakeList(List<List<Cell>> listAll, string NamePlayer, string NamePlay)
        {
            using (var db = new DataModelContainer())
            {
                listAll = new List<List<Cell>>();
                for (int i = 1; ; i++)
                {
                    if (db.CoordsSet.FirstOrDefault(x => x.Generation == i && x.Play.Toy == NamePlayer && x.Play.Player.Name == NamePlay) != null)
                        foreach (var item in db.CoordsSet.Where(x => x.Generation == i && x.Play.Toy == NamePlayer && x.Play.Player.Name == NamePlay))
                        {
                            cells.Add(new Cell(item.CoordX, item.CoordY));
                        }
                    else break;
                    listAll.Add(cells);
                    cells = new List<Cell>();
                }
            }
        }
    }
}
