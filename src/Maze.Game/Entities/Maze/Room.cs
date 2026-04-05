using Maze.Game.Common.ExtensionMethods;
using Maze.Game.Common.SavingLoading;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Maze.Game.Entities
{
    public class Room
    {
        // There are between 1 and 4 passages on each room. This is a predefined, immutale amount, so the passages collection can be a plain array.
        public Passage[] passages;

        // Numbers of treasures and threats in each room are mutable over the course of the game, therefore the List object is more appropriate than an array.
        public List<Treasure> Treasures { get; set; }

        public List<Threat> Threats { get; set; }

        public int TotalItemCount
        {
            get
            {
                return Treasures.Count + Threats.Count;
            }
        }

        public Room()
        {
            Threats = new List<Threat>();
            Treasures = new List<Treasure>();
        }

        public void GeneratePassages(int numPassages, bool hasExitPassage, Random rand)
        {
            passages = new Passage[numPassages];

            // Randomise the directions, but each direction can only be used once.
            var directionsList = Enum.GetValues(typeof(PassageDirections)).Cast<PassageDirections>().ToList();
            directionsList.Shuffle(rand);

            for (int i = 0; i < passages.Length; i++)
            {
                passages[i] = new Passage(false, directionsList[i]);
            }

            if (hasExitPassage)
            {
                int exitPassage = rand.Next(0, passages.Length);
                passages[exitPassage].isExit = true;
            }
        }

        public void GenerateTreasures(Random rand)
        {
            Treasure[] possibleTreasures = Deserialize.DeserializeFromJson<Treasure[]>(Path.Combine(AppContext.BaseDirectory, "Resources", "Treasures.json"));

            int maxNumTreasures = rand.Next(1, 4);

            for (int i = 0; i < maxNumTreasures; i++)
            {
                Treasure treasure = possibleTreasures.SelectRandom(rand);
                Treasures.Add(treasure);
            }
        }

        public void GenerateThreats(Random rand)
        {
            Threat[] possibleThreats = Deserialize.DeserializeFromJson<Threat[]>(Path.Combine(AppContext.BaseDirectory, "Resources", "Threats.json"));

            int maxNumThreats = rand.Next(1, 4);

            for (int i = 0; i < maxNumThreats; i++)
            {
                Threat threat = possibleThreats.SelectRandom(rand);
                Threats.Add(threat);
            }
        }

        public void AddDroppedCoin()
        {
            Treasures.Add(new Treasure()
            {
                Name = "Dropped Coin",
                TreasureValue = 1
            });
        }
    }
}
